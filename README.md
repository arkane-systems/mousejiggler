mousejiggler
============

Mouse Jiggler is a very simple piece of software whose sole function is to "fake" mouse input to Windows, and jiggle the mouse pointer back and forth.

Useful for avoiding screensavers or other things triggered by idle detection that, for whatever reason, you can't turn off any other way; or as a quick way to stop a screensaver activating during an installation or when monitoring a long operation without actually having to muck about with the screensaver settings.

Installation
============

The easiest means of installing Mouse Jiggler is using Chocolatey, although bare releases continue to be available:

`choco install mouse-jiggler`

In the 2.0 release, Chocolatey installation supports installation without requiring administrative rights.

Operation
=========

Simply run the MouseJiggle.exe included in the release .zip file. Check the "Jiggling?" checkbox to start jiggling the mouse pointer; uncheck it to stop. The jiggle is slight enough that you should be able to use the computer normally even with jiggling enabled.

Check the "Settings..." checkbox to reveal the settings; these should be relatively self-explanatory. The 'Zen jiggle?' checkbox enables a mode in which the pointer is jiggled 'virtually' - the system believes it to be moving and thus screen saver activation, etc., is prevented, but the pointer does not actually move. This, however, may not work with a few applications which chose to implement their own idle detection.

To minimize Mouse Jiggler to the notification area, click the down-arrow button.

These settings are remembered from session to session. They can also be overridden by command-line options; for details, run `MouseJiggler -h`.

The `-j` command-line switch tells Mouse Jiggler to commence jiggling immediately on startup.

Features That Will Not Be Implemented
=====================================

This is a list of feature requests which I've decided won't be implemented in Mouse Jiggler for one reason or another, along with what those reasons are, just for reference:

 * Autorun on startup (because that's what the Startup group, Task Scheduler, etc. are for; it's inelegant to duplicate system facilities in a minimal app).
 * Timed startup/shutdown (again, Task Scheduler is for this).

Support
=======

Mouse Jiggler is a free product provided without warranty or support.
