using fcm.Resources;
using Spectre.Console;

namespace fcm.Commands
{
    internal class Help
    {
        /// <summary>
        /// 显示 fcm 的帮助信息
        /// </summary>
        /// <returns>退出代码，必定为 0</returns>
        internal static int ShowHelp()
        {
            Table table = new Table()
                .ShowRowSeparators()
                .Border(TableBorder.MinimalHeavyHead)
                .Title(Strings.AvailableCommands);

            table.AddColumn(new TableColumn(Strings.Command).NoWrap())
                 .AddColumn(Strings.Purpose)
                 .AddColumn(Strings.Parameters)
                 .AddColumn(Strings.Example);

            table.AddRow(
                    $"get / random / {Strings.NoArguments}",
                    Strings.RandomlyOutputAnInterestingContent,
                    "/",
                    "fcm get"
                ).AddRow(
                    "add / append",
                    Strings.AddAnInterestingContent,
                    Strings.ContentToBeAdded,
                    "fcm add \"快写啊死手\""
                ).AddRow(
                    "remove / del / delete",
                    Strings.RemoveAnInterestingContent,
                    Strings.ContentToBeRemoved,
                    "fcm remove \"If you can.\""
                ).AddRow(
                    "search / find",
                    Strings.SearchContentBasedOnTheSpecifiedKeyword,
                    Strings.SearchKeyword,
                    "fcm search \"让我搜搜\""
                ).AddRow(
                    "list",
                    Strings.ListAllInterestingContent,
                    "/",
                    "fcm list"
                ).AddRow(
                    "import",
                    Strings.ImportTheContentsOfTheSpecifiedFile,
                    Strings.ThePathOfTheFileToBeImported,
                    "fcm import fun.txt"
                ).AddRow(
                    "export",
                    Strings.ExportAllContentToTheSpecifiedFile,
                    Strings.ThePathOfTheFileToBeExportedTo,
                    "fcm export backup.txt"
                ).AddRow(
                    "edit / open",
                    Strings.OpenFunTxt,
                    "/",
                    "fcm open"
                ).AddRow(
                    "dep / ded / dup",
                    Strings.RemoveDuplicateLinesFromTheContent,
                    Strings.TheLocationOfTheFileThatNeedToBeDeduplicated_LeaveBlankForTheDefaultLocation,
                    "fcm dep fun.txt"
                ).AddRow(
                    "--version",
                    Strings.ShowVersionInformation,
                    "/",
                    "fcm --version"
                ).AddRow(
                    "--help",
                    Strings.ShowThisHelpTable,
                    "/",
                    "fcm --help"
                );

            AnsiConsole.Write(table);
            return 0;
        }
    }
}
