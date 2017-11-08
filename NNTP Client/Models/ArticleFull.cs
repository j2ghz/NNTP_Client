using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NNTP_Client.Models
{
    public class ArticleFull
    {
        public ArticleFull(IEnumerable<string> data)
        {
            var dataList = data as IList<string> ?? data.ToList();
            var dict = new Dictionary<string,string>();
            foreach (var kvp in JoinAndReSplit(dataList.Skip(1).TakeWhile(s => !string.IsNullOrWhiteSpace(s)))
                .Select(ExtractKeyValue))
            {
                if(dict.ContainsKey(kvp.Key))continue;
                dict.Add(kvp.Key,kvp.Value);
            }
            Headers = dict;
            Message = string.Join(Environment.NewLine, dataList.SkipWhile(s => !string.IsNullOrWhiteSpace(s)));
        }

        public string Message { get; }
        public string From => Headers["From"];
        public string Subject => Headers["Subject"];
        public string Date => Headers["Date"];
        public IReadOnlyDictionary<string, string> Headers { get; }

        private static KeyValuePair<string, string> ExtractKeyValue(string data)
        {
            var index = data.IndexOf(": ", StringComparison.Ordinal);
            return new KeyValuePair<string, string>(data.Substring(0, index), data.Substring(index + 2));
        }

        private static IEnumerable<string> JoinAndReSplit(IEnumerable<string> data)
        {
            var temp = "";
            foreach (var s in data)
                if (Regex.IsMatch(s, @"^\S+: "))
                {
                    if (!string.IsNullOrWhiteSpace(temp))
                        yield return temp;
                    temp = s;
                }
                else
                {
                    temp += s;
                }
        }
    }
}