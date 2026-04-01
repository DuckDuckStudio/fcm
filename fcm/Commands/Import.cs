using fcm.Resources;
using fcm.Functions;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Import
    {
        internal static int ImportFun(string[] paths)
        {
            if (paths.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.PleaseTellMeWhichFileYouWantToImport}");
                return 1;
            }

            if (!Files.CheckFunTxt(createNewOne: true))
            {
                return 1;
            }

            List<string> mergedLines = [];
            mergedLines.AddRange(File.ReadAllLines(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8));

            foreach (string path in paths)
            {
                if (!File.Exists(path))
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format(Strings.DoesNotExist, Markup.Escape(path))}");
                    continue;
                }

                mergedLines.AddRange(File.ReadAllLines(path, System.Text.Encoding.UTF8));
                mergedLines = Deduplicate.ContentDeduplicate(mergedLines);
                AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.SuccessfullyImported, Markup.Escape(path))}");
            }

            File.WriteAllLines(Files.FUN_TXT_PATH, mergedLines, System.Text.Encoding.UTF8);
            return 0;
        }
    }
}
