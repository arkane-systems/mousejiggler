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
- 也可以随时按下 <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>J</kbd> 切换晃动状态

支持模式：Normal、Zen、Circle、Linear。

## 命令行参数

- `-j, --jiggle`：启动时启用晃动
- `-m, --minimized`：启动时最小化
- `-o, --mode <mode>`：指定模式
- `-r, --random`：启用随机间隔
- `-s, --seconds <seconds>`：设置间隔秒数
- `-d, --distance <distance>`：设置距离倍率
- `-g, --settings`：启动时显示设置
- `-l, --respect-locked-state`：锁定工作站时暂停晃动
- `--stop-jiggling`：通知正在运行的实例停止晃动，然后退出（不会启动应用程序）
- `--version`：显示版本
- `-?, -h, --help`：显示帮助

## 定时停止

Mouse Jiggler 没有内置的定时停止功能——Windows 任务计划程序已经能很好地完成这件事，`--stop-jiggling` 让它可以干净地驱动：它会找到正在运行的实例，通知它取消勾选“启用晃动”，然后退出，不会另外启动一个实例。如果没有正在运行的实例，它什么都不做，并以非零状态退出。

例如，每天 17:00 停止晃动：

```
schtasks /create /tn "Stop Mouse Jiggler" /tr "\"C:\Path\To\MouseJiggler.exe\" --stop-jiggling" /sc daily /st 17:00
```

## 说明

本文件为中文使用说明，英文原版文档请参考 `README.md`。
