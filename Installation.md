# Introduction #

This page describe the process of the setting up the Mono.Xna development environment. The environment is available [here](http://code.google.com/p/monoxna/source/checkout).

# Dependencies #

Mono.Xna is dependent on Tao Framework and the NUnit libraries. The versions referenced in the projects are supplied in ./lib/. To allow for single solution the assemblies should be installed into the GAC instead of referenced directly.

## Linux ##

### Ubuntu users! ###
Ubuntu 9.10 has all dependences in default repository! You can install them in two ways.

**First one** _(quick)_ is using Terminal:
Open Terminal.
Programs -> Accessories -> Terminal
Copy and past next 2 lines separately (second is longer, but it should be in one line)
```
sudo apt-get update
sudo apt-get install libtaoframework-devil1.6-cil libtaoframework-openal1.1-cil libtaoframework-sdl1.2-cil libdevil1c2 libtaoframework-opengl3.0-cil libnunit2.4-cil monodevelop monodevelop-nunit
```
If you are asked for approval just type "Y" and press "Enter"


**Second** is using Synaptic:
Go to System -> Administration -> Synaptic
Tick following packets
```
- libtaoframework-devil1.6-cil
- libtaoframework-openal1.1-cil
- libtaoframework-opengl3.0-cil
- libtaoframework-sdl1.2-cil
- libdevil1c2
- libnunit2.4-cil
- monodevelop
- monodevelop-nunit
```

MonoDevelop should be fine with all references except NUnit.

**INFO:** NUnit in Ubuntu 9.10 is still 2.4.7 (2.4.8 expected), but you should add new reference from your GAC in test project for unit testing.


### Manual approach ###
This approach has been tested in Ubuntu 9.04 and openSUSE 11.1.

Run the following commands in the ./lib/ directory to install the Tao assemblies
utilized in the project:

```
sudo gacutil -i -package taoframework-2.1.0 taoframework-2.1.0/Tao.Sdl.dll
sudo gacutil -i -package taoframework-2.1.0 taoframework-2.1.0/Tao.OpenGl.dll
sudo gacutil -i -package taoframework-2.1.0 taoframework-2.1.0/Tao.DevIl.dll
```

Copy the taoframework-2.1.0.pc file from ./lib/ to /usr/lib/pkgconfig to make the assemblies available under Packages in MonoDevelop. If they don't show up you can try manually copying them into /usr/lib/mono/taoframework-2.1.0, and remember to reload MonoDevelop.

The NUnit library version 2.4.8 is the default version in the current stable Mono, but Ubuntu only offers packages for 2.4.7. The following commands can be used to install the correct version.

```
sudo gacutil -i -package nunit-2.4.8 nunit-2.4.8/nunit.core.dll
sudo gacutil -i -package nunit-2.4.8 nunit-2.4.8/nunit.core.interfaces.dll
sudo gacutil -i -package nunit-2.4.8 nunit-2.4.8/nunit.framework.dll
```

Copy the nunit-2.4.8.pc file to /usr/lib/pkgconfig to finish up.

Scripts will eventually be added to make the installation easier.

## Windows ##
Download the Tao.Framework 2.1.0:
[Tao.Framework 2.1.0 Setup Windows](http://sourceforge.net/projects/taoframework/files/The%20Tao%20Framework/2.1.0/taoframework-2.1.0-setup.exe/download)

Start the Tao.Framework-Setup.

Download NUnit installer version 2.4.8: [NUnit-Installer 2.4.8](http://sourceforge.net/projects/nunit/files/NUnit%20Version%202/NUnit-2.4.8-net-2.0.msi/download)

Start the NUnit installer.

## Mac OS X ##

We need contributers with Apple computer.

# MonoDevelop & Visual Studio Solution #

The solution file in the root directory is all that is needed for development in MonoDevelop 2.0. The Visual Studio support needs testing.

The solution contain the MonoDevelop.Xna addin, so to be able to build in Visual Studio, either the dependencies has to be install, or the project has to be skipped during build.