#region header

// MouseJiggle - AssemblyInfo.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.
// 
// Created: 2013-08-24 12:41 PM

#endregion

using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle ("MouseJiggle")]
[assembly: AssemblyDescription (@"A utility to continuously jiggle the mouse pointer to prevent screen saver activation.

Tick the 'Enable jiggle?' checkbox to begin jiggling the mouse; untick it to stop. The 'Zen jiggle?' checkbox enables a mode in which the pointer is jiggled 'virtually' - the system believes it to be moving and thus screen saver activation, etc., is prevented, but the pointer does not actually move."
    )]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("Arkane Systems")]
[assembly: AssemblyProduct ("MouseJiggle")]
[assembly: AssemblyCopyright ("Copyright © Alistair J. R. Young 2007-2013")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible (false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid ("e1fc2039-43a7-4843-8a43-8f896c257adc")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion ("1.6.0.0")]
[assembly: AssemblyFileVersion ("1.6.0.0")]
[assembly: NeutralResourcesLanguage ("en-US")]
