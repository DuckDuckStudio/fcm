using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Deduplicate
    {
        /// <summary>
        /// 对指定的内容去重
        /// </summary>
        /// <param name="content">内容数组</param>
        /// <returns>去重后的内容数组</returns>
        internal static string[] ContentDeduplicate(string[] content)
        {
            HashSet<string> seen = [];
            List<string> deduplicatedContent = [];
            foreach (string line in content)
            {
                if (seen.Add(line))
                {
                    deduplicatedContent.Add(line);
                }
            }
            return [.. deduplicatedContent];
        }

        /// <summary>
        /// 对指定的内容去重
        /// </summary>
        /// <param name="content">内容列表</param>
        /// <returns>去重后的内容列表</returns>
        internal static List<string> ContentDeduplicate(List<string> content)
        {
            HashSet<string> seen = [];
            List<string> deduplicatedContent = [];
            foreach (string line in content)
            {
                if (seen.Add(line))
                {
                    deduplicatedContent.Add(line);
                }
            }
            return deduplicatedContent;
        }

        /// <summary>
        /// 对多个指定的文件去重
        /// </summary>
        /// <param name="filePaths">多个文件路径数组</param>
        /// <returns>退出代码</returns>
        internal static int FilesDeduplicate(string[] filePaths)
        {
            if (filePaths.Length == 0)
            {
                if (Files.CheckFunTxt())
                {
                    filePaths = [Files.FUN_TXT_PATH];
                }
                else
                {
                    return 1;
                }
            }

            bool isDeduplicated = false;
            foreach (string filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format(Strings.DoesNotExist, Markup.Escape(filePath))}");
                    continue;
                }

                try
                {
                    File.WriteAllLines(
                        filePath,
                        ContentDeduplicate(
                            File.ReadAllLines(filePath)
                        )
                    );

                    isDeduplicated = true;
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.SuccessfullyDeduplicatedFor, Markup.Escape(filePath))}");
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format(Strings.AnExceptionOccurredWhenDeduplicatingFile)} {Markup.Escape(ex.Message)}");
                }
            }

            if (isDeduplicated)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
