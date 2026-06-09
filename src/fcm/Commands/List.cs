using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class List
    {
        /// <summary>
        /// 读取并显示 fun.txt 中的所有内容。
        /// </summary>
        /// <returns>退出代码，文件不存在返回 1，读取成功（无论是否为空）返回 0</returns>
        internal static int ShowAllFun()
        {
            if (!Files.CheckFunTxt())
            {
                return 1;
            }

            string content = File.ReadAllText(Files.FUN_TXT_PATH, System.Text.Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(content))
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Hint} {Strings.FunTxtIsEmpty}");
                return 0;
            }
            else
            {
                Console.WriteLine(content);
                return 0;
            }
        }
    }
}
