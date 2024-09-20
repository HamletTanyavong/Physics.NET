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

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Physics.NET;

/// <summary>Represents a physical quantity.</summary>
/// <typeparam name="TNumber">The type that represents the value.</typeparam>
/// <typeparam name="TSystemOfMeasurement">The system of measurement to use.</typeparam>
[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly record struct Quantity<TNumber, TSystemOfMeasurement>
    where TNumber : IComplex<TNumber>, IDifferentiableFunctions<TNumber>
    where TSystemOfMeasurement : ISystemOfMeasurement<TSystemOfMeasurement>
{
    internal readonly TNumber _value;
    internal readonly Dimensions _dimensions;

    public Quantity()
    {
        _value = TNumber.Zero;
        _dimensions = Dimensions.Dimensionless;
    }

    public Quantity(TNumber value)
    {
        _value = value;
        _dimensions = Dimensions.Dimensionless;
    }

    public Quantity(TNumber value, Dimensions dimensions)
    {
        _value = value;
        _dimensions = dimensions;
    }

    /// <summary>The value of the quantity.</summary>
    public readonly TNumber Value => _value;

    /// <summary>The dimensions of the quantity.</summary>
    public readonly Dimensions Dimensions => _dimensions;

    /// <inheritdoc cref="ISystemOfMeasurement{T}.Name"/>
    public readonly string Units => TSystemOfMeasurement.Name;

    /// <summary>Check that the dimensions of the quantity are valid.</summary>
    /// <param name="dimensions">The dimensions to check against.</param>
    /// <exception cref="DimensionalAnalysisException">Thrown when the quantity's dimensions do not match the specified dimensions.</exception>
    [Conditional("DIMENSIONS")]
    public void VerifyDimensions(in Dimensions dimensions)
    {
        if (!Vector128.EqualsAll(
            Unsafe.As<Dimensions, Vector128<ulong>>(ref Unsafe.AsRef(in _dimensions)),
            Unsafe.As<Dimensions, Vector128<ulong>>(ref Unsafe.AsRef(in dimensions))))
        {
            throw new DimensionalAnalysisException($"The dimensions of the quantity are invalid.");
        }
    }

    //
    // Operators
    //

    public static Quantity<TNumber, TSystemOfMeasurement> operator +(Quantity<TNumber, TSystemOfMeasurement> z) => z;

    public static Quantity<TNumber, TSystemOfMeasurement> operator -(Quantity<TNumber, TSystemOfMeasurement> z) => new(-z._value, z._dimensions);

    public static Quantity<TNumber, TSystemOfMeasurement> operator +(Quantity<TNumber, TSystemOfMeasurement> z, Quantity<TNumber, TSystemOfMeasurement> w)
    {
        z.VerifyDimensions(w._dimensions);
        return new(z._value + w._value, z._dimensions | w._dimensions);
    }

    public static Quantity<TNumber, TSystemOfMeasurement> operator -(Quantity<TNumber, TSystemOfMeasurement> z, Quantity<TNumber, TSystemOfMeasurement> w)
    {
        z.VerifyDimensions(w._dimensions);
        return new(z._value - w._value, z._dimensions | w._dimensions);
    }

    public static Quantity<TNumber, TSystemOfMeasurement> operator *(Quantity<TNumber, TSystemOfMeasurement> z, Quantity<TNumber, TSystemOfMeasurement> w)
        => new(z._value * w._value, z._dimensions * w._dimensions);

    public static Quantity<TNumber, TSystemOfMeasurement> operator /(Quantity<TNumber, TSystemOfMeasurement> z, Quantity<TNumber, TSystemOfMeasurement> w)
        => new(z._value / w._value, z._dimensions / w._dimensions);
}
