using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrayApplication
{
    class Words
    {
        private Random rand;

        /// <summary>
        /// Constructor initializes the arrays with predefined words
        /// </summary>
        public Words()
        {
            Adjective = new string[] { "TCP", "HTTP", "SDD", "RAM", "GB", "CSS", "SSL", "AGP", "SQL", "FTP", "PCI", "AI", "ADP", "RSS", "XML", "EXE", "COM", "HDD", "THX", "SMTP", "SMS", "USB", "PNG", "PHP", "UDP", "TPS", "RX", "ASCII", "CD-ROM", "CGI", "CPU", "DDR", "DHCP", "BIOS", "IDE", "IP", "MAC", "MP3", "AAC", "PPPoE", "SSD", "SDRAM", "VGA", "XHTML", "Y2K", "GUI", "HEX", "DATABASE" };
            Noun = new string[] { "auxiliary", "primary", "back-end", "digital", "open-source", "virtual", "cross-platform", "redundant", "online", "haptic", "multi-byte", "bluetooth", "wireless", "1080p", "neural", "optical", "solid state", "mobile", "unicode", "backup", "high speed", "56k", "analog", "fiber optic", "central", "visual", "ethernet" };
            Noun2 = new string[] { "driver", "protocol", "bandwidth", "panel", "microchip", "program", "port", "card", "array", "interface", "system", "sensor", "firewall", "hard drive", "pixel", "alarm", "feed", "monitor", "application", "transmitter", "bus", "circuit", "capacitor", "matrix", "address", "form factor", "array", "mainframe", "processor", "antenna", "transistor", "virus", "malware", "spyware", "network", "internet" };
            Verb = new string[] { "back up", "bypass", "hack", "override", "compress", "copy", "navigate", "index", "connect", "generate", "quantify", "calculate", "synthesize", "input", "transmit", "program", "reboot", "parse", "shut down", "inject", "transcode", "encode", "attach", "disconnect", "network" };
            action = new string[] { "backing up", "bypassing", "hacking", "overriding", "compressing", "copying", "navigating", "indexing", "connecting", "generating", "quantifying", "calculating", "synthesizing", "inputting", "transmitting", "programming", "rebooting", "parsing", "shutting down", "injecting", "transcoding", "encoding", "attaching", "disconnecting", "networking" };
            Constructs = new string[] { "If we {3} the {2}, we can get to the {0} {2} through the {1} {0} {2}!", "We need to {3} the {1} {0} {2}!", "Try to {3} the {0} {2}, maybe it will {3} the {1} {2}!", "You can't {3} the {2} without {4} the {1} {0} {2}!", "Use the {1} {0} {2}, then you can {3} the {1} {2}!", "The {0} {2} is down, {3} the {1} {2} so we can {3} the {0} {2}!", "{4} the {2} won't do anything, we need to {3} the {1} {0} {2}!", "I'll {3} the {1} {0} {2}, that should {3} the {0} {2}!", "My {0} {2} is down, our only choice is to {3} and {3} the {1} {2}!", "They're inside the {2}, use the {1} {0} {2} to {3} their {2}!", "Send the {1} {2} into the {2}, it will {3} the {2} by {4} its {0} {2}!" };
            rand = new Random();
        }

        public readonly string[] Adjective;
        public readonly string[] Noun;
        public readonly string[] Noun2;
        public readonly string[] Verb;
        public readonly string[] action;
        public readonly string[] Constructs;

        /// <summary>
        /// construct the sentence from 6 words
        /// </summary>
        /// <returns>constructed sentence</returns>
        public string ConstructSentence()
        {
            string word1 = getWord("Adjective");
            word1 = capitalize(word1);
            string word2 = getWord("Noun");
            string word3 = getWord("Noun2");
            string word4 = getWord("Verb");
            string word5 = getWord("action");
            string construct = getWord("Constructs");
            // "Use the {1} {0} {2}, then you can {3} the {1} {2}!"
            return String.Format(construct, word1, word2, word3, word4, word5);
        }

        /// <summary>
        /// get random word from array
        /// </summary>
        /// <param name="arrayName">name of the array to get the word from</param>
        /// <returns>random word from array</returns>
        private string getWord(string arrayName)
        {
            switch (arrayName)
            {
                case "Adjective":
                    return Adjective[rand.Next(0, Adjective.Length - 1)];
                case "Noun":
                    return Noun[rand.Next(0, Noun.Length - 1)];
                case "Noun2":
                    return Noun2[rand.Next(0, Noun2.Length - 1)];
                case "Verb":
                    return Verb[rand.Next(0, Verb.Length - 1)];
                case "action":
                    return action[rand.Next(0, action.Length - 1)];
                case "Constructs":
                    return Constructs[rand.Next(0, Constructs.Length - 1)];
                default:
                    return "Something went wrong";
            }
        }

        /// <summary>
        /// Capitalize the first letter of the word
        /// </summary>
        /// <param name="word">word to capitalize</param>
        /// <returns>word with the first letter capitalized</returns>
        private string capitalize(string word)
        {
            char capitalLetter = ' ';
            string newWord = "";

            capitalLetter = Convert.ToChar(word.Substring(0, 1));
            newWord = capitalLetter.ToString().ToUpper() + word.Substring(1);
            return newWord;
        }
    }
}
