using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal static class Sort
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
                    return 2;
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
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.SuccessfullySorted, Markup.Escape(filePath))}");
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {string.Format(Strings.AnExceptionOccurredWhenSortingFile, Markup.Escape(filePath))} {Markup.Escape(ex.Message)}");
                }
            }

            return isSorted ? 0 : 1;
        }
    }
}
