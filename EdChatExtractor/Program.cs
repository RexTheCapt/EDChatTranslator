using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EdTools;

namespace EdChatExtractor
{
    internal class Program
    {
        private static string? currentCommander = null;
        private static string exportDirectory = $"{DateTime.Now.Year}\\{DateTime.Now.Month}\\{DateTime.Now.Day}\\{DateTime.Now.Hour}\\{DateTime.Now.Minute}\\{DateTime.Now.Second}\\";

        internal static void Main(string[] args)
        {
            JournalScanner journalScanner = new JournalScanner();

            JournalScanner.OnEventHandler += JournalScanner_OnEventHandler;

            if (!Directory.Exists(exportDirectory))
                Directory.CreateDirectory(exportDirectory);

            journalScanner.ScanAll();

            foreach (ChannelWriter cw in channelWriters)
            {
                cw.Dispose();
            }

            Console.WriteLine($"Extracted to \"{Path.GetFullPath(exportDirectory)}\"");
        }


        private static void JournalScanner_OnEventHandler(object? sender, EventArgs e)
        {
            JournalScanner.OnEventArgs eArgs = (JournalScanner.OnEventArgs)e;
            JsonClass.Root onEvent = eArgs.OnEvent;
            
            switch (onEvent._event)
            {
                case "SendText":
                    JournalScanner_SendTextHandler(sender, onEvent);
                    break;
                case "ReceiveText":
                    JournalScanner_ReceiveTextHandler(sender, onEvent);
                    break;
                case "LoadGame":
                    JournalScanner_LoadGameHandler(sender, onEvent);
                    break;
            }
        }

        private static void JournalScanner_SendTextHandler(object? sender, JsonClass.Root _event)
        {
            if (_event.To == null || _event.Message == null)
                return;

            if (currentCommander == null)
                currentCommander = "---";

            EdMessage m = new(_event.timestamp, currentCommander, EdMessage.Direction.Sending, _event.To, _event.Message);

            ExtractMessage(m);

            Console.WriteLine(m);
        }

        private static void JournalScanner_ReceiveTextHandler(object? sender, JsonClass.Root _event)
        {
            if (_event.From == null || _event.Message == null || _event.Channel == null || _event.Channel.Equals("NPC", StringComparison.OrdinalIgnoreCase))
                return;

            if (currentCommander == null)
                currentCommander = "---";

            string channel = _event.Channel;
            if (_event.Channel.Equals("player"))
                channel = _event.From;

            EdMessage m = new(_event.timestamp, _event.From, EdMessage.Direction.Receiving, channel, _event.Message);
            
            ExtractMessage(m);

            Console.WriteLine(m);
        }

        private static List<ChannelWriter> channelWriters = new();
        private static void ExtractMessage(EdMessage message)
        {
            ChannelWriter? found = channelWriters.Find(x => x.Channel.Equals(message.channel));

            if (found == null)
            {
                ChannelWriter cw = new(message.channel, exportDirectory);
                channelWriters.Add(cw);
                found = cw;
            }

            found.Write($"[{message.timestamp}] {message.cmdr} \t {message.directionString} \t {message.message}");
        }

        private static void JournalScanner_LoadGameHandler(object? sender, JsonClass.Root _event)
        {
            currentCommander = _event.Commander;
        }
    }
}
