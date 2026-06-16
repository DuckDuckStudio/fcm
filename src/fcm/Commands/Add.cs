using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal static class Add
    {
        /// <summary>
        /// 添加参数中的每个有趣的内容到 fun.txt 中
        /// </summary>
        /// <param name="funs">那些需要添加进去的有趣的内容</param>
        /// <returns>退出代码</returns>
        internal static int AddFun(string[] funs)
        {
            if (funs.Length == 0)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.PleaseTellMeWhatYouWantToAdd}");
                return -1;
            }

            if (!Files.CheckFunTxt(createNewOne: true))
            {
                return 1;
            }

            List<string> funFile = [.. File.ReadAllLines(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8)];

            bool isAdded = false;
            foreach (string fun in funs)
            {
                string normalizedfun = fun.Replace("\n", "\\n");
                if (funFile.Contains(normalizedfun))
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Warning} {Markup.Escape(normalizedfun)} {Strings.IsAlreadyInFunTxt}");
                }
                else
                {
                    isAdded = true;
                    funFile.Add(normalizedfun);
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.HasBeenAddedToFunTxt, Markup.Escape(normalizedfun))}");
                }
            }

            if (isAdded)
            {
                File.WriteAllLines(Files.FUN_TXT_PATH, funFile, System.Text.Encoding.UTF8);
            }

            return 0;
        }
    }
}
