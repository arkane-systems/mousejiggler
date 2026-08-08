# Mouse Jiggler（简体中文说明）

Mouse Jiggler 是一个通过模拟鼠标输入来避免系统进入空闲状态的小工具。

## 安装

可以使用 Winget 或 Chocolatey：

- `winget install ArkaneSystems.MouseJiggler`
- `choco install mouse-jiggler --version=3.0.0`

也可以从发布页下载压缩包：

- https://github.com/arkane-systems/mousejiggler/releases

## 基本用法

运行 `MouseJiggler.exe` 后：

- 勾选“启用晃动”开始晃动
- 取消勾选停止晃动
- 勾选“设置...”可展开设置面板

支持模式：Normal、Zen、Circle、Linear。

## 命令行参数

- `-j, --jiggle`：启动时启用晃动
- `-m, --minimized`：启动时最小化
- `-o, --mode <mode>`：指定模式
- `-r, --random`：启用随机间隔
- `-s, --seconds <seconds>`：设置间隔秒数
- `-d, --distance <distance>`：设置距离倍率
- `-g, --settings`：启动时显示设置
- `--version`：显示版本
- `-?, -h, --help`：显示帮助

## 说明

本文件为中文使用说明，英文原版文档请参考 `README.md`。
