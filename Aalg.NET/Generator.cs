using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aalg.NET
{
    public class Generator
    {
        private readonly Random random = new Random();
        private IList<string[]> phrases;
        private string newLine;

        public Generator(Stream input, string newLine)
        {
            this.newLine = newLine;
            InitializePhrases(input);
        }

        private void InitializePhrases(Stream input)
        {
            TextReader regels = new StreamReader(input);

            phrases = new List<string[]>();
            string[] phrase;
            while ((phrase = ReadPhrase(regels)) != null)
            {
                // Add the phrase to the list
                phrases.Add(phrase);
            }
        }

        public string GetRandomPhrasePart(int part)
        {
            return phrases[random.Next(phrases.Count)][part];
        }

        public string GenerateStrophe()
        {
            return String.Format("{0} {1}{5}{2} {3} {4}{5}",
                GetRandomPhrasePart(0), GetRandomPhrasePart(1),
                GetRandomPhrasePart(0), GetRandomPhrasePart(1), GetRandomPhrasePart(2),
                newLine);
        }

        /// <summary>
        /// Read a phrase (consisting of 3 parts)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private string[] ReadPhrase(TextReader reader)
        {
            string[] phrase = new string[3];
            for (int i = 0; i < 3; i++)
            {
                if ((phrase[i] = reader.ReadLine()) == null)
                {
                    return null;
                }
            }

            return phrase;
        }
    }
}
