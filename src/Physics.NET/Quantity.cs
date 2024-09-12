// <copyright file="Quantity.cs" company="Physics.NET">
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

#pragma warning disable IDE0032

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Physics.NET;

/// <summary>Represents a physical quantity.</summary>
/// <typeparam name="TNumber">The type that represents the value.</typeparam>
/// <typeparam name="TSystemOfMeasurement">The system of measurement to use.</typeparam>
public readonly record struct Quantity<TNumber, TSystemOfMeasurement>
    where TNumber : IComplex<TNumber>
    where TSystemOfMeasurement : ISystemOfMeasurement<TSystemOfMeasurement>
{
    private readonly TNumber _value;
    private readonly TSystemOfMeasurement _units;

    public Quantity()
    {
        _value = TNumber.Zero;
        _units = TSystemOfMeasurement.Dimensionless;
    }

    public Quantity(TNumber value)
    {
        _value = value;
        _units = TSystemOfMeasurement.Dimensionless;
    }

    public Quantity(TNumber value, TSystemOfMeasurement units)
    {
        _value = value;
        _units = units;
    }

    /// <summary>The value of the quantity.</summary>
    public readonly TNumber Value => _value;

    /// <summary>The units of the quantity.</summary>
    public readonly TSystemOfMeasurement Units => _units;

    /// <summary>Check that the units of the quantity are valid.</summary>
    /// <param name="units">The units to check against.</param>
    /// <exception cref="InvalidUnitsException">Thrown when the quantity's units do not match the specified units.</exception>
    [Conditional("UNITS")]
    public void VerifyUnits(in TSystemOfMeasurement units)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            if (!Vector128.EqualsAll(
                Unsafe.As<TSystemOfMeasurement, Vector128<ulong>>(ref Unsafe.AsRef(in _units)),
                Unsafe.As<TSystemOfMeasurement, Vector128<ulong>>(ref Unsafe.AsRef(in units))))
            {
                throw new InvalidUnitsException($"The units of the quantity are invalid.");
            }
        }
        else
        {
            if (!_units.Equals(units))
            {
                throw new InvalidUnitsException($"The units of the quantity are invalid.");
            }
        }
    }
}
