using fcm.Functions;
using fcm.Resources;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace fcm.Commands
{
    internal class Search
    {
        /// <summary>
        /// 依据指定的关键词搜索有趣的内容
        /// </summary>
        /// <param name="keywords">指定的关键词数组</param>
        /// <returns></returns>
        internal static int SearchFun(string[] keywords)
        {
            if (keywords.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.PleaseTellMeWhatYouWantToSearch}");
                return 1;
            }


            string[] filteredKeywords = [.. keywords.Where(k => !string.IsNullOrWhiteSpace(k)).Distinct()];
            Array.Sort(filteredKeywords, (x, y) => y.Length.CompareTo(x.Length));
            if (filteredKeywords.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.NoValidKeywords}");
                return 1;
            }

            Table table = new Table().ShowRowSeparators()
                                     .Border(TableBorder.Simple)
                                     .HideHeaders()
                                     .AddColumn("结果");

            foreach (string line in File.ReadLines(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (!filteredKeywords.All(k => line.Contains(k.Replace("\n", "\\n"))))
                {
                    continue;
                }

                string escapedLine = Markup.Escape(line);
                string pattern = string.Join("|", filteredKeywords.Select(keyword => Regex.Escape(Markup.Escape(keyword))));
                string result = Regex.Replace(escapedLine, pattern, match => $"[blue]{match.Value}[/]");
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine($"{Print.MSHead.Success} 共找到 {table.Rows.Count} 个内容。");
            return 0;
        }
    }
}
