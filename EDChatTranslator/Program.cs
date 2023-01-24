using System;
using System.Collections.Generic;
using System.Linq;
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

        internal static void Main()
        {
            Console.Title = "ED Chat Translator";
            Console.WriteLine("Please input the language code you want to translate to:");
            languageCode = Console.ReadLine();
            Console.WriteLine($"Language code is set to {languageCode}, translation has started.");

            JournalScanner js = new JournalScanner();

            if (!_handlersSet)
            {
                //JournalScanner.ReceiveTextHandler += JournalScanner_ReceiveTextHandler;
                //JournalScanner.SendTextHandler += JournalScanner_SendTextHandler;
                //JournalScanner.UnknownEventHandler += JournalScanner_UnknownEventHandler;
                JournalScanner.OnEventHandler += JournalScanner_OnEventHandler;
                JournalScanner.OnErrorHandler += JournalScanner_OnErrorHandler;
                _handlersSet = true;
            }

            string input = "";

            while (true)
            {
                js.TimerScan();
                Console.ForegroundColor = ConsoleColor.Gray;

                DateTime end = DateTime.Now;
                Thread.Sleep(1000);

                bool brk = false;
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    ConsoleKey key = consoleKeyInfo.Key;
                    char character = ((char)key);
                    if ((character >= 'a' && character <= 'z') || 
                        (character >= 'A' && character <= 'Z') ||
                        character == ':')
                        input = $"{input}{character}";
                    if (character == '\b')
                        input = $"{input.Substring(0, input.Length - 1)}";
                    ClearLine();
                    Console.Write($"{input}");
                    brk = consoleKeyInfo.Key == ConsoleKey.Q;

                    if (brk)
                        Console.WriteLine("Quitting...");

                    if (consoleKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && consoleKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift) && consoleKeyInfo.Key == ConsoleKey.R)
                    {
                        Main();
                        return;
                    }
                    else if (consoleKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && consoleKeyInfo.Key == ConsoleKey.R)
                    {
                        Console.WriteLine("Re-reading journal...");
                        js.ReRead();
                    }
                }
                
                if (brk) break;
            }
        }

        private static void ClearLine()
        {

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
            else return;

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
            Console.WriteLine(FormatMessage(timestamp, received, from, message));
            Console.ForegroundColor = received ? ConsoleColor.Green : ConsoleColor.Blue;
            Console.WriteLine(FormatMessage(timestamp, received, from, translatedMessage));
        }

        private static string FormatMessage(DateTime timestamp, bool received, string from, string message)
        {
            string s = MessageFormat.Replace("__TIMESTAMP__", timestamp.ToString("HH:mm:ss")).Replace("__DIRECTION__", (received ? "<<<" : ">>>")).Replace("__FROM__", from).Replace("__MESSAGE__", message);
            return s;
        }

        private static string Translate(string? v)
        {
            if (v == null) return null;

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
