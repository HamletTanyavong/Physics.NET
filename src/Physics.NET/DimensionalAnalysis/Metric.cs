﻿// <copyright file="Metric.cs" company="Physics.NET">
// Physics.NET
// https://github.com/HamletTanyavong/Physics.NET
//
// MIT License
//
// Copyright (c) 2024-present Hamlet Tanyavong
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>

using System.Runtime.InteropServices;
using Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.BaseUnits;

namespace Physics.NET.DimensionalAnalysis;

/// <summary>
/// Represents the <i>International System of Units</i>, the <i>Metric system</i>, as coordinated by the <see href="https://www.bipm.org">International Bureau of Weights and Measurements</see>.
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly record struct Metric
    : ISystemOfMeasurement<Metric>,
      IBaseUnits<Metric, Second, Meter, Kilogram, Ampere, Kelvin, Mole, Candela, Radian>
{
    /// <inheritdoc cref="ISystemOfMeasurement{T}.Dimensionless"/>
    public static readonly Metric Dimensionless = new();

    public Metric() { }

    //
    // Interface Implementations
    //

    static Metric ISystemOfMeasurement<Metric>.Dimensionless => Dimensionless;

    //
    // Base Units
    //

    public readonly Second Time { get; init; } = new();
    public readonly Meter Length { get; init; } = new();
    public readonly Kilogram Mass { get; init; } = new();
    public readonly Ampere Current { get; init; } = new();
    public readonly Kelvin Temperature { get; init; } = new();
    public readonly Mole Amount { get; init; } = new();
    public readonly Candela Intensity { get; init; } = new();
    public readonly Radian Angle { get; init; } = new();
}
