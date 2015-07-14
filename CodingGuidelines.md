# Introduction #

In order for the source code to be consistently formatted despite contributor, we need to follow some style conventions. These conventions are inspired by Mono's [coding guidelines](http://mono-project.com/Coding_Guidelines) and Microsoft's [design guidelines](http://msdn.microsoft.com/en-us/library/ms229042.aspx), so they should be used as a secondary reference, but the rules on this page take precedence.

# Guidelines #

## Naming ##

  * Use standard C# naming conventions.
  * Use **PascalCasing** for all public members and **camelCasing** for all private.
  * Avoid using `_` and -.
  * If additional private field indication is needed in addition to the casing, use the **this** keyword.

## Indentation ##

Mono use 8-space indentation, but this creates a lot of whitespace. 4-space indentation is the default setting in both Visual Studio and MonoDevelop, and due to this fact a more natural choice for the preferred indentation style in the monoxna source code.

## Spaces ##

Use a space before an opening parenthesis for method declaration, loops and tests but not before function calls, like this:

```
void Call (string param) {}
Call(param);
index[0];
if (true) ...
while (true) ...
for (...) ...
```

This again differs slightly from Mono's setup but stays more true to Visual Studio's standard setup.

## Brackets ##

Brackets should be placed on a new line for methods, loops and tests:

```
Method ()
{
    for (int i=0; i<10; i++)
    {
        ...
    }

    if (true)
    {
        ...
    }
}
```

Properties have their opening brackets on the same line. This applies to multiline **get** and **set** methods as well.

```
int Property {
    get { ... }
    set { ... }
}
int Property {
    get {
        ...
    }
    set {
        ...
    }
}
```

## Regions ##

Create regions around logical member groupings like Constructors, Properties and so on. The regions can also be named according to accessibility eg Public Methods.