# Skitscript Types (.NET Standard) [![License](https://img.shields.io/github/license/skitscript/types-dotnetstandard.svg)](https://github.com/skitscript/types-dotnetstandard/blob/master/license) [![Renovate enabled](https://img.shields.io/badge/renovate-enabled-brightgreen.svg)](https://renovatebot.com/) ![Nuget](https://img.shields.io/nuget/v/Skitscript.Types.DotNetStandard)

A set of .NET Standard types representing the entities in a Skitscript document.

## Installation

### Dependencies

This is a NuGet package.  It targets .NET Standard 2.0 or newer on the following
operating systems:

- Ubuntu 20.04
- Ubuntu 18.04
- macOS 11 (Big Sur)
- macOS 10.15 (Catalina)
- Windows Server 2022
- Windows Server 2019
- Windows Server 2016

### Install

```bash
dotnet add {project name} package Skitscript.Types.DotNetStandard
```

## Usage

Use the types within in your own projects:

```csharp
using Skitscript.Types.DotNetStandard;
```

- [Skitscript.Types.DotNetStandard.Identifier](./Skitscript.Types.DotNetStandard/Identifier.cs)
- [Skitscript.Types.DotNetStandard.Run](./Skitscript.Types.DotNetStandard/Run.cs)
