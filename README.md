mousejiggler
============

Mouse Jiggler is a very simple piece of software whose sole function is to "fake" mouse input to Windows, and 
jiggle the mouse pointer back and forth.

Useful for avoiding screensavers or other things triggered by idle detection that, for whatever reason, you 
can't turn off any other way; or as a quick way to stop a screensaver activating during an installation or 
when monitoring a long operation without actually having to muck about with the screensaver settings.

Operation
=========

Simply run the MouseJiggle.exe included in the release .zip file. Check the "Enable jiggle?" checkbox to start
jiggling the mouse pointer; uncheck it to stop. The jiggle is slight enough that you should be able to use the
computer normally even with jiggling enabled.

The 'Zen jiggle?' checkbox enables a mode in which the pointer is jiggled 'virtually' - the system believes it
to be moving and thus screen saver activation, etc., is prevented, but the pointer does not actually move.

To minimize Mouse Jiggler to the system tray, click the button marked with a green, down-pointing arrow.

If you want to start the Mouse Jiggler with jiggling already enabled, run the MouseJiggle.exe with either the
-j or --jiggle command-line switch.

The "-z" / "--zen" command-line switch forces zen jiggling to be enabled for the current (and future) invocations
of MouseJiggler.

(Added in 1.5+): The "-m" / "--minimized" command-like switch tells MouseJiggler to start already minimized.

That's it. Enjoy!
