using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Export
    {
        internal static int ExportFunTxt(string[] paths)
        {
            if (paths.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.PleaseTellMeWhereYouWantToExportTo}");
                return 1;
            }

            if (!Files.CheckFunTxt())
            {
                return 1;
            }

            foreach (string path in paths)
            {
                try
                {
                    File.Copy(Files.FUN_TXT_PATH, path, true);
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.SuccessfullyExportedFunTxtTo, path)}");
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.AnExceptionOccurredWhileExportingFunTxt} {Markup.Escape(ex.Message)}");
                    return 1;
                }
            }

            return 0;
        }
    }
}
