# Fun Content Manager

> <p style="text-align: center"><a href="/README.md">简体中文</a></p>

Manage fun content.

## Install

[When the pull request for new version is published](https://github.com/microsoft/winget-pkgs/issues?q=type%3Apr%20author%3ADuckDuckStudio%20%22DuckStudio.FCM%22), you can install it via winget:  

```shell
winget install --id DuckStudio.FCM -s winget -e
```

<details>
<summary>Linux</summary>

### Linux

> I use [WSL2 Ubuntu](https://ubuntu.com/desktop/wsl) + [fish shell](https://fishshell.com/) + [bash](http://www.gnu.org/software/bash).  
> You can use ANY editor you like, not just limited to [nano](https://www.nano-editor.org/).  
> Before continuing, please [install the .NET 10 SDK](https://learn.microsoft.com/zh-cn/dotnet/core/install/linux).

#### Clone repository

```shell
git clone https://github.com/DuckDuckStudio/fcm.git # Add the "-b <version>" parameter to specify the version
cd fcm/
```

#### Compiles FCM

> [!TIP]
> You DON'T necessarily have to strictly follow the examples given here; you can refer to the [`dotnet publish` command documentation](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish) to combine new command.

The example here uses the Release build configuration, specifying the target operating system as Linux, single file, and self-contained runtime.

```shell
dotnet publish fcm --configuration Release --os linux -p:PublishSingleFile=true --self-contained
```

#### Add to PATH

> Please replace the path in the code with the path to your actual publish folder.

For fish:
```shell
nano ~/.config/fish/config.fish
# Add the following code
# set -gx PATH "/path/to/repo/fcm/fcm/bin/Release/net10.0/linux-x64/publish/" $PATH
```

For bash:
```bash
nano ~/.bashrc
# Add the following code
# export PATH="/path/to/repo/fcm/fcm/bin/Release/net10.0/linux-x64/publish/:$PATH"
```

Then reload the configuration with the `source` command.

</details>

## Usage

You can start by importing the [fun.txt file](/fun.txt) from the repository.
```shell
# Assuming you have already cloned and cd into the repository directory
fcm import fun.txt
```

Then get a random one:
```shell
# No parameters is equivalent to fcm get
fcm
```

For more help information, please run `fcm --help`.

## License

This program is licensed under the [Apache License 2.0](https://github.com/DuckDuckStudio/fcm/blob/main/LICENSE.txt).

### Dependencies

This program would not be possible without the following projects:
Thank you to the open source community!

| Package | License |
|---------|---------|
| [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/) | MIT License |
| [DuckStudio.CatFood](https://www.nuget.org/packages/DuckStudio.CatFood) | Apache License 2.0 |

For the license files related to these dependencies, please see [NOTICE.md](https://github.com/DuckDuckStudio/fcm/blob/main/NOTICE.md).
