// <copyright file="DimensionalAnalysisExtensions.cs" company="Physics.NET">
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

#define DIMENSIONS

namespace Physics.NET.DimensionalAnalysis;

/// <summary>Dimensional analysis extensions.</summary>
public static class DimensionalAnalysisExtensions
{
    /// <summary>Convert a value using <see cref="SI"/> units to one using <see cref="CGS"/> units.</summary>
    /// <typeparam name="T">The type that represents the value.</typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <returns>The quantity in <see cref="CGS"/> units.</returns>
    public static Quantity<T, CGS> ToCGS<T>(in this Quantity<T, SI> quantity)
        where T : IComplex<T>, IDifferentiableFunctions<T>
    {
        var value = quantity._value;
        var dimensions = quantity._dimensions;
        if (dimensions[1] != Rational<sbyte>.Zero)
            value *= T.Pow(100, Rational<sbyte>.ToReal(dimensions[1]));
        if (dimensions[2] != Rational<sbyte>.Zero)
            value *= T.Pow(1000, Rational<sbyte>.ToReal(dimensions[2]));
        return new(value, quantity._dimensions);
    }

    /// <summary>Convert a value using <see cref="CGS"/> units to one using <see cref="SI"/> units.</summary>
    /// <typeparam name="T">The type that represents the value.</typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <returns>The quantity in <see cref="SI"/> units.</returns>
    public static Quantity<T, SI> ToSI<T>(in this Quantity<T, CGS> quantity)
        where T : IComplex<T>, IDifferentiableFunctions<T>
    {
        var value = quantity._value;
        var dimensions = quantity._dimensions;
        if (dimensions[1] != Rational<sbyte>.Zero)
            value *= T.Pow(0.01, Rational<sbyte>.ToReal(dimensions[1]));
        if (dimensions[2] != Rational<sbyte>.Zero)
            value *= T.Pow(0.001, Rational<sbyte>.ToReal(dimensions[2]));
        return new(value, quantity._dimensions);
    }
}
