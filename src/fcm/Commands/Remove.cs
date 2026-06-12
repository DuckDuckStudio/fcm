using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal static class Remove
    {
        /// <summary>
        /// 从 fun.txt 中移除参数中的每个有趣的内容。
        /// </summary>
        /// <param name="funs">那些需要移除的有趣的内容</param>
        /// <returns>退出代码</returns>
        internal static int RemoveFun(string[] funs)
        {
            if (funs.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.PleaseTellMeWhatYouWantToRemove}");
                return -1;
            }
            
            bool isRemoved = false;
            List<string> funFile = [.. File.ReadAllLines(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8)];

            foreach (string fun in funs)
            {
                string normalizedfun = fun.Replace("\n", "\\n");
                if (funFile.Contains(normalizedfun))
                {
                    isRemoved = true;
                    funFile.RemoveAll(line => line == normalizedfun);
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.HasBeenRemovedFromFunTxt, Markup.Escape(normalizedfun))}");
                }
                else
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Warning} {Markup.Escape(normalizedfun)} {Strings.IsNotInFunTxt}");
                }
            }

            if (isRemoved)
            {
                File.WriteAllLines(Files.FUN_TXT_PATH, funFile, System.Text.Encoding.UTF8);
            }

            return 0;
        }
    }
}
