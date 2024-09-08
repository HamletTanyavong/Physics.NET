// <copyright file="IBaseQuantity.cs" company="Physics.NET">
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

using Mathematics.NET.Core.Operations;

namespace Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.BaseUnits;

/// <summary>Defines support for SI base quantities.</summary>
/// <typeparam name="T">A type that implements the interface.</typeparam>
internal interface IBaseQuantity<T>
    : IAdditionOperation<T, T>,
      ISubtractionOperation<T, T>
    where T : IBaseQuantity<T>
{
    /// <summary>Represents the exponent of the base quantity.</summary>
    Rational<sbyte> Exponent { get; }

    /// <summary>Return a LaTeX representation of this base quantity.</summary>
    /// <returns>A string.</returns>
    string ToLaTeX();

    /// <summary>Convert a <paramref name="value"/> into one of type <typeparamref name="T"/>.</summary>
    /// <param name="value">An <see cref="sbyte"/> value.</param>
    static abstract implicit operator T(sbyte value);
}
