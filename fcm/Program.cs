namespace fcm
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string tool;
            string[] toolArgs;

            if (args.Length > 0)
            {
                tool = args[0].ToLowerInvariant();
                toolArgs = [.. args.Skip(1)];
            }
            else
            {
                tool = "";
                toolArgs = [];
            }

            // 分发给工具处理
            switch (tool)
            {
                case "get":
                case "radom":
                case "": // 默认
                    return fcm.Commands.Get.GetFun();
                case "add":
                case "append":
                    return fcm.Commands.Add.AddFun(toolArgs);
                case "remove":
                case "del":
                case "delete":
                    return fcm.Commands.Remove.RemoveFun(toolArgs);
                case "search":
                case "find":
                    return fcm.Commands.Search.SearchFun(toolArgs);
                case "list":
                    return fcm.Commands.List.ShowAllFun();
                case "import":
                    return fcm.Commands.Import.ImportFun(toolArgs);
                case "export":
                    return fcm .Commands.Export.ExportFunTxt(toolArgs);
                case "open":
                case "edit":
                    return fcm.Commands.Open.OpenFun();
                case "dep":
                case "ded":
                case "dup":
                    return fcm.Commands.Deduplicate.FilesDeduplicate(toolArgs);
                case "--version":
                    return fcm.Commands.Version.ShowVersion();
                default:
                    return fcm.Commands.Help.ShowHelp();
            }
        }
    }
}
