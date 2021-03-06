<p align="center">
  <a href="https://github.com/HamletTanyavong/Physics.NET">
    <img src="https://api.nuget.org/v3-flatcontainer/physics.net/0.1.1-alpha.1/icon" alt="Physics.NET logo" width="128" height="128">
  </a>
</p>

<h1 align="center">Physics.NET</h1>
<p align="center">
    Physics.NET is a class library for solving basic problems encountered in Quantum Field Theory, Electrodynamics, General Relativity, and Statistical Mechanics.
</p>

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square&logo=appveyor)](http://choosealicense.com/licenses/mit/)
[![NuGet](https://img.shields.io/nuget/vpre/Physics.NET?style=flat-square&logo=appveyor)](https://www.nuget.org/packages/Physics.NET/absoluteLatest)

## Table of contents

- [About](#about)
- [Intstallation](#installation)
- [Examples](examples)

## About

This library contains methods used to solve basic physics problems and also contains some common mathematical operations.[^1] Natural and SI units are supported though the former is preferred.
[^1]: This project is in developement and not yet ready for release.

## Installation

This package is available from [nuget](https://www.nuget.org/packages/Physics.NET/) and can be installed in [.NET Interactive](https://github.com/dotnet/interactive) notebooks with the following command:
```csharp
#r "nuget:Physics.NET"
```
Specify a version number to get a specific version of the package.
```csharp
#r "nuget:Physics.NET,0.1.1-alpha.1"
```

## Examples

### General Relativity

Here, we specify spacetime around an object of mass `m` and a contravariant four-vector at a specified location. The index is set to `mu`. With the method `Lower`, we can lower the index and save the result. This result is the value of the field at the point `a` in the form of a covariant four-vector. 

```csharp
m = 5.972e24;
FourVector<Spherical, U> a = new(0, 1, 0, 0);
a.SetIndex(0, "mu");

var b = a.Lower("mu", Metric.Schwarzschild, m);
```
