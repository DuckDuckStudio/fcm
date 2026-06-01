using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Sort
    {
        internal static int FilesSort(string[] filePaths)
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

            bool isSorted = false;
            foreach (string filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format(Strings.DoesNotExist, Markup.Escape(filePath))}");
                    continue;
                }

                try
                {
                    string[] fileLines = File.ReadAllLines(filePath);
                    Array.Sort(fileLines);
                    File.WriteAllLines(filePath, fileLines);

                    isSorted = true;
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format("成功对 {0} 排序", Markup.Escape(filePath))}");
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format("对 {0} 排序时出现异常:", Markup.Escape(filePath))} {Markup.Escape(ex.Message)}");
                }
            }

            if (isSorted)
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
