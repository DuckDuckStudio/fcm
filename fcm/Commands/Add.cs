using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Add
    {
        /// <summary>
        /// 添加参数中的每个有趣的内容到 fun.txt 中
        /// </summary>
        /// <param name="funs">那些需要添加进去的有趣的内容</param>
        /// <returns>退出代码</returns>
        internal static int AddFun(string[] funs)
        {
            bool isAdded = false;
            List<string> funFile = [.. File.ReadAllLines(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8)];

            foreach (string fun in funs)
            {
                if (funFile.Contains(fun))
                {
                    AnsiConsole.MarkupLine($"{Print.MSHead.Warning} {Markup.Escape(fun)} {Strings.IsAlreadyInFunTxt}");
                    continue;
                }
                else
                {
                    isAdded = true;
                    funFile.Add(fun);
                    AnsiConsole.MarkupLine($"{Print.MSHead.Success} {string.Format(Strings.HasBeenAddedToFunTxt, Markup.Escape(fun))}");
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
