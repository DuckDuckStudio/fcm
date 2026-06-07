using fcm.Resources;
using Spectre.Console;

namespace fcm.Functions
{
    internal class Files
    {
        /// <summary>
        /// fun.txt 的所在位置
        /// (~/.config/DuckStudio/fcm/fun.txt)
        /// </summary>
        internal static readonly string FUN_TXT_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".config",
            "DuckStudio",
            "fcm",
            "fun.txt"
        );

        /// <summary>
        /// 检查 fun.txt 是否存在，如果不存在则尝试创建新的 fun.txt
        /// </summary>
        /// <returns>是否存在或创建成功</returns>
        internal static bool CheckFunTxt(bool createNewOne = false)
        {
            if (File.Exists(FUN_TXT_PATH))
            {
                return true;
            }
            else if (createNewOne)
            {
                try
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Warning} {Strings.FunTxtNotFoundANewOneWillBeCreated}");
                    string? dir = Path.GetDirectoryName(FUN_TXT_PATH);
                    if (!string.IsNullOrEmpty(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    File.Create(FUN_TXT_PATH).Close();
                    return true;
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.AnExceptionOccurredWhileCreatingTheNewFuntxt}: [red]{Markup.Escape(ex.Message)}[/]");
                    return false;
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.FunTxtNotFound}");
                return false;
            }
        }
    }
}
