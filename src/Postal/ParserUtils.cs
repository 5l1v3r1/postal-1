﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Postal
{
    static class ParserUtils
    {
        /// <summary>
        /// Headers are of the form "(key): (value)" e.g. "Subject: Hello, world".
        /// The headers block is terminated by an empty line.
        /// </summary>
        public static void ParseHeaders(TextReader reader, Action<string, string> useKeyAndValue)
        {
            string line;
            while (string.IsNullOrWhiteSpace(line = reader.ReadLine()))
            {
                // Skip over any empty lines before the headers.
            }

            var headerStart = new Regex(@"^\s*[A-Za-z]");
            do
            {
                if (!headerStart.IsMatch(line)) break;

                var index = line.IndexOf(':');
                if (index <= 0) break;

                var key = line.Substring(0, index).ToLowerInvariant().Trim();
                var value = line.Substring(index + 1).Trim();
                useKeyAndValue(key, value);
            } while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()));
        }
    }
}
