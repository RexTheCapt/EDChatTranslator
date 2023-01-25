using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using EdTools;

namespace EDChatTranslator
{
    internal class Program
    {
        private static string? languageCode;
        private readonly static string MessageFormat = "[__TIMESTAMP__] __DIRECTION__ __FROM__ : __MESSAGE__";
        private static bool _handlersSet = false;
        private static string input = "";
        private static JournalScanner js = new JournalScanner();
        private static bool enableGoogleTranslate = true;
        private static bool showAllEvents = false;

        internal static void Main()
        {
            Console.Title = "ED Chat Translator";
            Console.WriteLine("Please input the language code you want to translate to:");
            languageCode = Console.ReadLine();
            Console.WriteLine($"Language code is set to {languageCode}, translation has started.");


            if (!_handlersSet)
            {
                //JournalScanner.ReceiveTextHandler += JournalScanner_ReceiveTextHandler;
                //JournalScanner.SendTextHandler += JournalScanner_SendTextHandler;
                //JournalScanner.UnknownEventHandler += JournalScanner_UnknownEventHandler;
                JournalScanner.OnEventHandler += JournalScanner_OnEventHandler;
                JournalScanner.OnErrorHandler += JournalScanner_OnErrorHandler;
                _handlersSet = true;
            }

            while (true)
            {
                js.TimerScan();
                Console.ForegroundColor = ConsoleColor.Gray;

                DateTime end = DateTime.Now;
                Thread.Sleep(100);

                bool brk = false;
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    ConsoleKey key = consoleKeyInfo.Key;
                    char character = consoleKeyInfo.KeyChar;
                    if ((character >= 'a' && character <= 'z') || 
                        (character >= 'A' && character <= 'Z') ||
                        character == ':' || character == ' ' || character == '/')
                        input = $"{input}{character}";
                    if (character == '\b' && input.Length > 0)
                        input = $"{input.Substring(0, input.Length - 1)}";
                    ClearLine();
                    Console.Write($"{input}");

                    if (character != '\r') continue;

                    if (input.StartsWith("/"))
                    {
                        DoCommand(input);
                        continue;
                    }

                    if (input.IndexOf(':') != 2)
                    {
                        ClearLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("Requires language code! Example: \"en:<message>\"");
                        continue;
                    }

                    string toTranslate = input;

                    string languageCode = toTranslate.Substring(0, toTranslate.IndexOf(":"));
                    toTranslate = toTranslate.Substring(toTranslate.IndexOf(":") + 1);

                    if (string.IsNullOrWhiteSpace(toTranslate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("The message is empty.");
                        continue;
                    }

                    input = $"{languageCode}:";

                    WriteLine($"{languageCode} || {toTranslate} || {toTranslate.Length}");

                    string translated = Translate(languageCode, toTranslate);
                    WriteLine(translated);
                }

                if (brk) break;
            }
        }

        private static void DoCommand(string command)
        {
            var split = command.Trim().Substring(1).ToLower().Split(' ');
            input = "";

            if (split[0].Equals("rescan"))
            {
                if (split.Length > 1 && split[1].Equals("false"))
                    enableGoogleTranslate = false;
                
                int lines = js.CountLines();

                DateTime timer = DateTime.Now.AddSeconds(3);

                while (timer > DateTime.Now)
                {
                    WriteLine($"Re-scanning {lines} lines in {timer - DateTime.Now}", false);
                }
                
                js.ReRead();
                js.TimerScan();

                if (split.Length > 1 && split[1].Equals("false"))
                    enableGoogleTranslate = true;
            }
            else if (split[0].Equals("events"))
            {
                showAllEvents = !showAllEvents;
                if (showAllEvents)
                    WriteLine("Showing all events.");
                else
                    WriteLine("Hiding all events.");
            }
        }

        private static void WriteLine(string text) => WriteLine(text, true);
        private static void WriteLine(string text, bool newline)
        {
            ClearLine();
            Console.Write($"{text}{(newline ? "\n" : "")}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(input);
        }

        private static void ClearLine()
        {
            StringBuilder sb = new();

            while (sb.Length < Console.WindowWidth)
                sb.Append(" ");

            Console.CursorLeft = 0;
            Console.Write(sb.ToString());
            Console.CursorLeft = 0;
        }

        private static void JournalScanner_OnErrorHandler(object? sender, EventArgs e)
        {
            var eargs = (JournalScanner.OnErrorArgs)e;
        }

        private static void JournalScanner_OnEventHandler(object? sender, EventArgs e)
        {
            var eargs = (JournalScanner.OnEventArgs)e;
            if (eargs.FirstRun) return;

            JsonClass.Root root = eargs.OnEvent;

            string _event = root._event;
            int direction = 0;
            DateTime timestamp = root.timestamp;
            string from;
            bool received;
            string? message = root.Message;

            if (_event.Equals("ReceiveText"))
                direction++;
            else if (_event.Equals("SendText"))
                direction--;
            else
            {
                if (showAllEvents)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine($"[{timestamp}] {_event}");
                }
                return;
            }

            if (direction == 0) return;

            if (direction == -1)
            {
                string? to = root.To;
                bool? sent = root.Sent;
                from = "me";
                received = false;

                if (sent == null) return;
                if (!(bool)sent) return;
            }
            else if (direction == 1)
            {
                string? channel = root.Channel;
                from = root.From;
                received = true;

                if (channel == null) return;
                if (channel.Equals("npc")) return;
            }
            else return;
            
            string translatedMessage = Translate(message);

            Console.ForegroundColor = received ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            WriteLine(FormatMessage(timestamp, received, from, message));
            Console.ForegroundColor = received ? ConsoleColor.Green : ConsoleColor.Blue;
            WriteLine(FormatMessage(timestamp, received, from, translatedMessage));
        }

        private static string FormatMessage(DateTime timestamp, bool received, string from, string message)
        {
            string s = MessageFormat.Replace("__TIMESTAMP__", timestamp.ToString("HH:mm:ss")).Replace("__DIRECTION__", (received ? "<<<" : ">>>")).Replace("__FROM__", from).Replace("__MESSAGE__", message);
            return s;
        }

        private static string? Translate(string toTranslate) => Translate(languageCode, toTranslate); 
        private static string? Translate(string? languageCode, string? v)
        {
            if (v == null) return null;
            if (!enableGoogleTranslate) return null;

            var toLanguage = languageCode;//English
            var fromLanguage = "auto";//Deutsch
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={System.Web.HttpUtility.UrlEncode(v)}";
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(url).Result;
                try
                {
                    int length = result.IndexOf("\"", 4, StringComparison.Ordinal) - 4;
                    string fix = result.Substring(4, length);
                    return fix;
                }
                catch
                {
                    return "Error";
                }
            }
        }
    }
}
