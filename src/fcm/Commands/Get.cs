using fcm.Functions;
using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Get
    {
        /// <summary>
        /// 随机获取一个好玩的
        /// </summary>
        /// <returns>退出代码</returns>
        internal static int GetFun()
        {
            // 神奇的鸡蛋织纱机会将白色和蛋黄融为一体这不神奇吗点击的链接我简历获取一个获取一个获取一个

            if (!Files.CheckFunTxt())
            {
                return 1;
            }


            // 这里使用蓄水池抽样算法（Reservoir Sampling），和 ReadAllLines 后随机的区别在于
            // 内存这里只存被选中的行（空间复杂度 O(1)），而 ReadAllLines 存整个文件（空间复杂度 O(N)）
            // 两者时间上差不多
            Random random = new();
            string? selectedLine = null;
            int lineCount = 0;

            using (StreamReader reader = new(Files.FUN_TXT_PATH))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    if (random.Next(lineCount) == 0)
                    {
                        selectedLine = line;
                    }
                }
            }

            // 理论上如果一行都没有，就一定不会选择某行，selectedLine 就一定是 null
            // 这里加进来只是为了消除 CS8602
            if ((lineCount == 0) || (selectedLine is null))
            {
                AnsiConsole.WriteLine($"{Print.MSHead.Error} {Strings.FunTxtIsEmpty}");
                return 1;
            }

            Console.WriteLine(selectedLine.Replace("\\n", "\n"));
            return 0;
        }
    }
}
