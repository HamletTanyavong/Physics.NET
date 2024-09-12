// <copyright file="IBaseUnits.cs" company="Physics.NET">
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

namespace Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.BaseUnits;

/// <summary>Represents the SI base units.</summary>
/// <typeparam name="TBaseUnits">The type that implements the interface.</typeparam>
/// <typeparam name="TTime">The type that represents the unit of time.</typeparam>
/// <typeparam name="TLength">The type that represents the unit of length.</typeparam>
/// <typeparam name="TMass">The type that represents the unit of mass.</typeparam>
/// <typeparam name="TCurrent">The type that represents the unit of electric current.</typeparam>
/// <typeparam name="TTemperature">The type that represents the unit of thermodynamic temperature.</typeparam>
/// <typeparam name="TAmount">The type that represents the unit of an amount of substance.</typeparam>
/// <typeparam name="TIntensity">The type that represents the unit of luminous intensity.</typeparam>
/// <typeparam name="TAngle">The type that represents the unit of a plane or phase angle.</typeparam>
internal interface IBaseUnits<TBaseUnits, TTime, TLength, TMass, TCurrent, TTemperature, TAmount, TIntensity, TAngle>
    where TBaseUnits : IBaseUnits<TBaseUnits, TTime, TLength, TMass, TCurrent, TTemperature, TAmount, TIntensity, TAngle>
    where TTime : ITime<TTime>
    where TLength : ILength<TLength>
    where TMass : IMass<TMass>
    where TCurrent : ICurrent<TCurrent>
    where TTemperature : ITemperature<TTemperature>
    where TAmount : IAmount<TAmount>
    where TIntensity : IIntensity<TIntensity>
    where TAngle : IAngle<TAngle>
{
    /// <summary>Represents the SI base quantity of time.</summary>
    TTime Time { get; init; }

    /// <summary>Represents the SI base quantity of length.</summary>
    TLength Length { get; init; }

    /// <summary>Represents the SI base quantity of mass.</summary>
    TMass Mass { get; init; }

    /// <summary>Represents the SI base quantity of electric current.</summary>
    TCurrent Current { get; init; }

    /// <summary>Represents the SI base quantity of thermodynamic temperature.</summary>
    TTemperature Temperature { get; init; }

    /// <summary>Represents the SI base quantity of an amount of substance.</summary>
    TAmount Amount { get; init; }

    /// <summary>Represents the SI base quantity of luminous intensity.</summary>
    TIntensity Intensity { get; init; }

    // It is convenient to add the quantity, angle, since it makes structs that implement this
    // interface have sizes of multiples of eight bytes, allowing for better performance optimizations.

    /// <summary>Represents the quantity of a plane or phase angle.</summary>
    /// <remarks>
    /// In Physics.NET, this has been added to the SI base units for convenience. However, there are justifications for adding it formally. See <see href="https://iopscience.iop.org/article/10.1088/1681-7575/ac7bc2/pdf">On the Dimension of Angles and Their Units</see> by Peter J. Mohr, Eric L. Shirley, William D. Phillips, and Michael Trott. 
    /// </remarks>
    TAngle Angle { get; init; }
}
