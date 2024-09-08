// <copyright file="Ampere.cs" company="Physics.NET">
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

namespace Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.BaseUnits;

/// <summary>Represents the SI base unit of electric current.</summary>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct Ampere : ICurrent<Ampere>
{
    public Ampere()
    {
        Exponent = new();
    }

    public Ampere(sbyte value)
    {
        Exponent = new(value);
    }

    public Ampere(Rational<sbyte> exponent)
    {
        Exponent = exponent;
    }

    public Ampere(sbyte numerator, sbyte denominator)
    {
        Exponent = new(numerator, denominator);
    }

    public readonly Rational<sbyte> Exponent { get; }

    public static Ampere operator +(Ampere left, Ampere right) => new(left.Exponent + right.Exponent);

    public static Ampere operator -(Ampere left, Ampere right) => new(left.Exponent - right.Exponent);

    public readonly string ToLaTeX()
    {
        if (Rational<sbyte>.IsNaN(Exponent) || Rational<sbyte>.IsInfinity(Exponent))
            return "Invalid base unit.";
        if (Exponent.Num == 0)
            return string.Empty;
        if (Exponent.Den == 1)
        {
            if (Exponent.Num == 1)
                return "\\text{A}";
            else
                return $"\\text{{A}}^{{{Exponent.Num}}}";
        }
        if (Exponent.Num < 0)
            return $"\\text{{A}}^{{-\\frac{{{-Exponent.Num}}}{{{Exponent.Den}}}}}";
        return $"\\text{{A}}^\\frac{{{Exponent.Num}}}{{{Exponent.Den}}}";
    }

    public static implicit operator Ampere(sbyte value) => new(value);
}
