mousejiggler
============

Mouse Jiggler is a very simple piece of software whose sole function is to "fake" mouse input to Windows, and jiggle the mouse pointer back and forth.

Useful for avoiding screensavers or other things triggered by idle detection that, for whatever reason, you can't turn off any other way; or as a quick way to stop a screensaver activating during an installation or when monitoring a long operation without actually having to muck about with the screensaver settings.

Why You Should Not Use This
===========================

This is not a tool for sneaking past your IT department.

Mouse Jiggler is easily detectable by any decent monitoring software. This is because these days decent monitoring software can pick up anything that doesn't use rootkit-style techniques to hide, and frankly, we have enough problems with false positives detecting Mouse Jiggler as malware without going down that road.

Basically, if you're looking for something to sneak past your IT department or monitoring software written by anyone who's even half awake, you don't want software. You want hardware. Now, you could buy one of the commercial dedicated mouse jigglers that police departments, etc., use to prevent computers from going idle, automatically logging out, and otherwise inconveniencing law enforcement, but instead, I suggest you buy yourself a Raspberry Pi Pico, and follow the instructions here:

https://www.tomshardware.com/how-to/diy-mouse-jiggler-raspberry-pi-pico

to make yourself a nice convenient little plug-in.

Installation
============

The easiest means of installing Mouse Jiggler is using Chocolatey:

`choco install mouse-jiggler`

Bare releases continue to be available at right for installation without administrative permissions, although the .NET 10 Desktop runtime must be installed first.

Please note that due to a compatibility issue with the Chocolatey shims, running Mouse Jiggler via the shim does not display command-line help or the Mouse Jiggler version when the -h/--help/-? or --version switches are used. To do so, Mouse Jiggler must be invoked directly. To easily discover the location of the original Mouse Jiggler executable for this purpose, run:

`mousejiggler --shimgen-log`

Portable Version
----------------

A portable version of Mouse Jiggler (i.e., one which does not require the .NET runtime, and so can be installed on locked-down corporate machines that don't have it installed) is available on the [releases page](https://github.com/arkane-systems/mousejiggler), as MouseJiggler-portable.zip. Just unzip and go.

**DO NOT USE THIS VERSION IF YOU HAVE ANY OTHER ALTERNATIVE.**

Let me put it to you this way. _Standard_ Mouse Jiggler, at the time of writing, is a single executable a mite under 1 MB in size. _Portable_ Mouse Jiggler is a folder of executables summing to approximately **134 MB**, for one of the most trivial applications imaginable, after all the assorted trimming-and-compressing magic is done. It's a bloated behemoth. If there is _any_ possibility that you will _ever_ run any other app that uses the .NET runtime, you are much better off installing that and the regular version.

The only reason this exists is for those poor sods whose IT department makes it impossible to do that, and may their deities have mercy on their souls.

Operation
=========

Simply run the MouseJiggle.exe included in the release .zip file. Check the "Jiggling?" checkbox to start jiggling the mouse pointer; uncheck it to stop. The jiggle is slight enough (by default) that you should be able to use the computer normally even with jiggling enabled.

Check the "Settings..." checkbox to reveal the settings; these should be relatively self-explanatory. The jiggle mode dropdown allows you to select from different jiggling modes. These include:

* Normal: the pointer is jiggled back and forth diagonally.
* Zen: the pointer is jiggled 'virtually' - the system believes it to be moving and thus screen saver activation, etc., is prevented, but the pointer does not actually move. This, however, may not work with a few applications which chose to implement their own idle detection.
* Circle: the pointer is jiggled in a circular pattern.
* Linear: the pointer is jiggled back and forth horizontally.

Other settings permit you to adjust the jiggle interval, the distance multiplier of the jiggle up to 120 (_not_ a direct pixel value; note that high multipliers will make it difficult to use the mouse to turn off jiggling), and whether the timer is randomized (i.e., whether the interval between jiggles is constant or random within a range from one second to the selected interval). 

To minimize Mouse Jiggler to the notification area, click the down-arrow button.

These settings are remembered from session to session. They can also be overridden by command-line options:

```
Usage:
  MouseJiggler [options]

Options:
  -j, --jiggle               Start with jiggling enabled.
  -m, --minimized            Start minimized. [default: False]
  -o, --mode <mode>          Start with the specified jiggle mode (Normal, Zen, Circle, Linear). [default: Normal]
  -r, --random               Start with random timer enabled. [default: False]
  -s, --seconds <seconds>    Set number of seconds for the jiggle interval. [default: 60]
  -d, --distance <distance>  Set the multiplier for the jiggle distance. [default: 1]
  -g, --settings             Start with settings panel displayed.
  --version                  Show version information
  -?, -h, --help             Show help and usage information
```

The `-j` command-line switch tells Mouse Jiggler to commence jiggling immediately on startup. Neither this nor '-g' are persistent.

Bugs
====

When installed using Chocolatey, command-line help may not be displayed properly. See "installation" above.

Features That Will Not Be Implemented
=====================================

This is a list of feature requests which I've decided won't be implemented in Mouse Jiggler for one reason or another, along with what those reasons are, just for reference:

 * Autorun on startup (because that's what the Startup group, Task Scheduler, etc. are for; it's inelegant to duplicate system facilities in a minimal app).
 * Concealment features (from as simple as changed icons or names, to more complex schemes¹).
 * Timed startup/shutdown (again, Task Scheduler is for this).

 1. Look. I know that a lot of folks use this to deal with annoying monitor-your-employees software, and with that motive, I have every sympathy. However, the more I add features that smell malware-ish, the more likely it is that the app will be flagged as malware by antivirus software, and the more likely it is that users will have trouble getting it installed and running. Also, not to put too fine a point on it, but anything I can add that doesn't qualify as *actual* malware is only going to give you a false sense of security. If you're going to end up being fired for running unauthorized anti-monitoring software, I'd much rather it wasn't because you thought I told you'd be safe.

Support
=======

Mouse Jiggler is a free product provided without warranty or support.

Usage Limitations
=================

As per our new license terms, Mouse Jiggler is not to be used by any agency of the United States government, or by any employee of the United States government while engaged in their employment, or on any system owned or controlled by the United States government, or by any entity doing business with the United States government in a manner that would subject Mouse Jiggler or its developers to any regulations or laws governing software used by the United States government.

I regret the necessity of this, but given the United States governments' recent incredible disregard for private property and the obligations of contracts, I have no desire to either (a) get any of it on me, or (b) encourage the belief that such behavior comes without consequence.

I apologize to any users who are affected by this, but I hope you understand the reasons for it.
