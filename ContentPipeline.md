# Introduction #

This page contains the development plan and status of the content pipeline implementation.

# Development #

Present the development plans and the status of implementation.

## MonoDevelop addin ##

The first thing that is going to need attention is the MonoDevelop addin. This will hopefully make the development must more enjoyable than the tedious: build with VS, run with Mono.Xna.

Development have been started in the MonoDevelop.Xna project, but there has been a number of issues getting the desired functionality:
  * MonoDevelop don't by default allow nested projects that are not part of the parent solution. The default command handler chain require the parent solution to be set in the projects, and the only way to set it is to add it to the solution.
  * XNA solution files (.sln) contain a weird reference to the nested content project without actually referencing it like a normal project. The good news is that this reference seems to be inactive (VS doesn't complain or change appearance if the reference is removed, and the reference doesn't appear to re-added after saves).
  * The nested content project have been implemented as a DotNetProjectSubtype which don't in the current version of MD support alternative filename extensions other than the default .csproj. The solution could be to implement the project as a Project subtype, but this would require rewriting much of the functionality already provided by implementing as DotNetProjectSubtype. An alternative suggested by lluis was to go around the standard save/load pipeline. There are an alternative way of loading which support specifying the filename manually, but I can't find a corresponding save method.

As of now the MD addin adds support for the project type of both XNA project and nested content project. The nested content projects do not have the proper extension but is visible under the parent XNA project like it should. The addin also has support for two custom file types (Xml and Sprite). Content file properties have same three fields available in VS (Name, Importer and Processor).

## Class Library ##

The stubs have been created for the entire content pipeline, but so far no implementations have been started. Specific todo tasks related to the content pipeline class library will start appearing once the MD addin is operational to ensure that they easily can be tested