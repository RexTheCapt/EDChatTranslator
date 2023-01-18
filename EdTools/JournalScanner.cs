using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdTools
{
    public class JournalScanner
    {
        public DateTime LastEventTime { get; private set; }
        public DateTime LastProcessedEventTime { get; private set; }
        public DateTime LastWriteTime { get; private set; }
        public bool FirstRun { get => _firstRun; private set { _firstRun = value; } }
        private bool _firstRun = true;
        private string _journalPath;
        private static JournalScanner? _instance = null;

        public JournalScanner()
        {
            if (_instance != null) throw new Exception("Can only exist one journal scanner!");

            _journalPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Saved Games\\Frontier Developments\\Elite Dangerous";
        }

        /// <summary>
        /// Run the journalscanner
        /// </summary>
        public void Tick()
        {
            TimerScan();
        }

        public void ScanAll()
        {
            string[] journals = Directory.GetFiles(_journalPath, "Journal.*.log").OrderBy(x => (new FileInfo(x)).LastWriteTime).ToArray();

            foreach (string s in journals)
                TimerScan(s);
        }

        public JournalScanner(string journalPath)
        {
            _journalPath = journalPath;
        }

        public void TimerScan(object? sender, System.EventArgs e) => TimerScan();
        public void TimerScan() => TimerScan(sendEventsOnFirstRun: true, overrideFile: null);
        public void TimerScan(string overrideFile) => TimerScan(sendEventsOnFirstRun: true, overrideFile: overrideFile);
        public void TimerScan(bool sendEventsOnFirstRun = true, string? overrideFile = null)
        {
            string newest = "";
            DateTime currentWriteTime = DateTime.MinValue;

            if (overrideFile == null)
                foreach (string f in Directory.GetFiles(_journalPath, "Journal.*.log"))
                {
                    FileInfo fi = new FileInfo(f);

                    if (fi.LastWriteTime > currentWriteTime)
                    {
                        currentWriteTime = fi.LastWriteTime;
                        newest = f;
                    }
                }

            if (LastWriteTime != currentWriteTime || overrideFile != null)
            {
                if (overrideFile != null)
                    newest = overrideFile;

                var fs = new FileStream(newest, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (var reader = new StreamReader(fs))
                    while (!reader.EndOfStream)
                    {
                        string? read = reader.ReadLine();

                        if (read == null) continue;
                        JsonClass.Root? _event;

                        try
                        {
                            _event = JsonConvert.DeserializeObject<JsonClass.Root>(read);
                        } catch (Exception e)
                        {
                            OnError(new OnErrorArgs(_event: JsonConvert.DeserializeObject<JObject>(read), e, journal: newest, firstRun: FirstRun));
                            continue;
                        }

                        if (_event != null)
                        {
                            DateTime currentEventDateTime = _event.timestamp;
                            if (currentEventDateTime >= LastEventTime && currentEventDateTime != LastProcessedEventTime || overrideFile != null)
                            {
                                if (!sendEventsOnFirstRun && FirstRun && overrideFile == null)
                                    goto SkipEventSend;

                                OnEvent(new OnEventArgs(_event: _event, journal: newest, firstRun: FirstRun));

                            SkipEventSend:
                                if (overrideFile == null)
                                    LastEventTime = currentEventDateTime;
                            }
                        }
                    }
            }

            FirstRun = false;

            LastProcessedEventTime = LastEventTime;
        }

        public void ReRead()
        {
            LastEventTime = DateTime.MinValue;
            LastWriteTime = DateTime.MinValue;
        }

        public static event EventHandler OnEventHandler;

        protected virtual void OnEvent(OnEventArgs e)
        {
            EventHandler handler = OnEventHandler;
            handler?.Invoke(this, e);
        }

        public class OnEventArgs : System.EventArgs
        {
            public OnEventArgs(JsonClass.Root _event, string journal, bool firstRun)
            {
                OnEvent = _event;
                this.FirstRun = firstRun;
                this.Journal = journal;
            }

            /// <summary>
            /// <para>timestamp</para>
            /// <para>event</para>
            /// </summary>
            public JsonClass.Root OnEvent { get; private set; }
            public string Journal { get; private set; }
            public bool FirstRun { get; private set; }
        }

        public static event EventHandler OnErrorHandler;

        protected virtual void OnError(OnErrorArgs e)
        {
            EventHandler handler = OnErrorHandler;
            handler?.Invoke(this, e);
        }

        public void Dispose()
        {
            _instance = null;
            _journalPath = "";
        }

        public class OnErrorArgs : System.EventArgs
        {
            public OnErrorArgs(JObject? _event, Exception exception, string journal, bool firstRun)
            {
                OnError = _event;
                this.FirstRun = firstRun;
                this.Journal = journal;
                this.Exception = exception;
            }

            /// <summary>
            /// <para>timestamp</para>
            /// <para>event</para>
            /// </summary>
            public JObject? OnError { get; private set; }
            public string Journal { get; private set; }
            public bool FirstRun { get; private set; }
            public Exception Exception { get; private set; }
        }
    }
}
