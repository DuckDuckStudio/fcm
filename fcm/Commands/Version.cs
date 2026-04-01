using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Version
    {
        internal const string VERSION = "2026.3.30.1547";

        /// <summary>
        /// 显示 fcm 的版本信息
        /// </summary>
        /// <returns>退出代码，必定为 0</returns>
        internal static int ShowVersion()
        {
            AnsiConsole.MarkupLine($"{Strings.FunContentManagerVersion} [green]{VERSION}[/] by [link=https://duckduckstudio.github.io/yazicbs.github.io/]鸭鸭「カモ」[/]");
            return 0;
        }
    }
}
