# Maui Controls
A library of images for .Net Maui.

## Necessity of this Library
Note:
1. Projects that directly reference other projects build the resources directly into themselves.
2. To include images in Maui NuGet packages, a specific setup is required to ensure they are packaged.
3. The setup to include images directly into a project is different from the NuGet setup.
4. You cannot use both setups in the same project or attempting the build will generate an error that a resource has been included twice.

Because of this, there does not seem to be a way to reference a project for testing, then build a NuGet package of the project while including the images in both the testing code and NuGet package.

## Requirements

DigitalProduction.Maui.Images 1.2.0 and later require .NET 10. Version 1.1.0 is the final .NET 9 release and is no longer maintained. Build with the .NET 10 SDK, its default C# 14 language version, and corresponding MAUI platform workloads.
