using fcm.Resources;
using fcm.Functions;
using Spectre.Console;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace fcm.Commands
{
    internal class Open
    {
        /// <summary>
        /// 在 Linux 上打开文件的一些工具。
        /// </summary>
        private static readonly string[] LINUX_TOOLS = ["xdg-open", "nano", "vim", "code"];

        /// <summary>
        /// 打开指定的文件
        /// </summary>
        /// <param name="filePath">需要打开的文件的路径</param>
        /// <exception cref="FileNotFoundException"></exception>
        internal static int OpenFun()
        {
            if (!Files.CheckFunTxt(createNewOne: true))
            {
                return 1;
            }

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(
                        new ProcessStartInfo
                        {
                            FileName = $"\"{Files.FUN_TXT_PATH}\"",
                            UseShellExecute = true,
                        }
                    )?.WaitForExit();
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    for (int i = 0; i < LINUX_TOOLS.Length; i++)
                    {
                        try
                        {
                            Process.Start(
                                new ProcessStartInfo
                                {
                                    FileName = LINUX_TOOLS[i],
                                    Arguments = $"\"{Files.FUN_TXT_PATH}\"",
                                    UseShellExecute = false
                                }
                            )?.WaitForExit();

                            break;
                        }
                        catch
                        {
                            if (i == (LINUX_TOOLS.Length - 1))
                            {
                                throw;
                            }
                        }
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start(
                        new ProcessStartInfo
                        {
                            FileName = "open",
                            Arguments = $"\"{Files.FUN_TXT_PATH}\"",
                            UseShellExecute = true
                        }
                    )?.WaitForExit();
                }
                else
                {
                    throw new PlatformNotSupportedException($"我不知道在 {RuntimeInformation.OSDescription} 上怎么打开文件...");
                }

                return 0;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"{Print.MSHead.Error} {Strings.AnExceptionOccurredWhileOpeningFunTxt} {Markup.Escape(ex.Message)}");
                return 1;
            }
        }
    }
}
