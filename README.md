# 有趣的内容管理器

> <p style="text-align: center"><a href="/docs/en/README.md">English</a></p>

管理你的有趣的内容。

## 安装

[当更新拉取请求发布后](https://github.com/microsoft/winget-pkgs/issues?q=type%3Apr%20author%3ADuckDuckStudio%20%22DuckStudio.FCM%22)，你可以通过 winget 安装:  

```shell
winget install --id DuckStudio.FCM -s winget -e
```

<details>
<summary>Linux</summary>

### Linux

> 我使用 [WSL2 Ubuntu](https://ubuntu.com/desktop/wsl) + [fish shell](https://fishshell.com/) + [bash](http://www.gnu.org/software/bash)。  
> 你可以使用任意你喜欢的编辑器而不只限于 [nano](https://www.nano-editor.org/)。  
> 在继续前，请先[安装 .NET 10 SDK](https://learn.microsoft.com/zh-cn/dotnet/core/install/linux)。

#### 克隆仓库

```shell
git clone https://github.com/DuckDuckStudio/fcm.git # 添加 "-b <版本号>" 参数指定版本
cd fcm/
```

#### 生成项目

> [!TIP]  
> 你不一定要严格按照这里给出的示例，参阅 [`dotnet publish` 命令文档](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)可以组合出新的命令。

这里的示例使用 Release 生成配置，指定目标操作系统 linux，单文件，自包含运行时。

```shell
dotnet publish fcm --configuration Release --os linux -p:PublishSingleFile=true --self-contained
```

#### 添加到 PATH

> 请将代码中的路径替换为你实际发布文件夹的路径。  

对于 fish:
```shell
nano ~/.config/fish/config.fish
# 添加以下代码
# set -gx PATH "/path/to/repo/fcm/fcm/bin/Release/net10.0/linux-x64/publish/" $PATH
```

对于 bash:
```bash
nano ~/.bashrc
# 添加以下代码
# export PATH="/path/to/repo/fcm/fcm/bin/Release/net10.0/linux-x64/publish/:$PATH"
```

然后用 `source` 命令重新加载配置。

</details>

## 使用

你可以先导入一份仓库中的 [fun.txt](/fun.txt):  
```shell
# 假设你已经克隆并 cd 进仓库目录
fcm import fun.txt
```

然后随机一条看看:  
```shell
# 不加参数等效于 fcm get
fcm
```

有关更多帮助信息，请运行 `fcm --help` 查看。

## 许可

本程序使用 [Apache License 2.0](https://github.com/DuckDuckStudio/fcm/blob/main/LICENSE.txt)。

### 依赖

本程序的实现离不开这些项目，感谢开源社区！

| 包 | 许可证 |
|-----|-----|
| [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/) | MIT License |
| [DuckStudio.CatFood](https://www.nuget.org/packages/DuckStudio.CatFood) | Apache License 2.0 |

有关这些依赖的许可文件，请参见 [NOTICE.md](https://github.com/DuckDuckStudio/fcm/blob/main/NOTICE.md)。
