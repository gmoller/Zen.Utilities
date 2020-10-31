# Zen.Utilities

An amalgamation of various helper routines for use in my software.

Nuget package download: https://www.nuget.org/packages/Zen.Utilities/0.1.4

# Example
To use:

    CallContext<string>.SetData("GlobalContext", "Hi!");
    var context = CallContext<string>.GetData("GlobalContext");

    Assert.AreEqual("Hi!", context);
    
# Developer
Written by Greg Moller (greg.moller@gmail.com)

# License
Licensed under the MIT License. See the LICENCE file for more information.
