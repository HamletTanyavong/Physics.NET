// <copyright file="Metric.cs" company="Physics.NET">
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
using Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.DerivedUnits;

namespace Physics.NET.DimensionalAnalysis;

/// <summary>
/// Represents the <i>International System of Units</i>, the <i>Metric system</i>, as coordinated by the <see href="https://www.bipm.org">International Bureau of Weights and Measurements</see>.
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly record struct Metric
    : ISystemOfMeasurement<Metric>,
      IBaseUnits<Metric, Second, Meter, Kilogram, Ampere, Kelvin, Mole, Candela, Radian>,
      IDerivedUnits<Metric>
{
    /// <inheritdoc cref="ISystemOfMeasurement{T}.Dimensionless"/>
    public static readonly Metric Dimensionless = new();

    /// <summary>Represents the derived unit of ionizing radiation dose, measured in <i>grays</i>.</summary>
    public static readonly Metric AbsorbedDose = new() { Time = -2, Length = 2 };

    /// <summary>Represents the derived unit of catalytic activity, measured in <i>katals</i>.</summary>
    public static readonly Metric CatalyticActivity = new() { Time = -1, Amount = 1 };

    /// <summary>Represents the derived unit of electric charge, measured in <i>coulombs</i>.</summary>
    public static readonly Metric ElectricCharge = new() { Time = 1, Current = 1 };

    /// <summary>Represents the derived unit of electrical capacitance, measured in <i>farads</i>.</summary>
    public static readonly Metric ElectricalCapacitance = new() { Time = 4, Length = -2, Mass = -1, Current = 2 };

    /// <summary>Represents the derived unit of electrical conductance, measured in <i>siemens</i>.</summary>
    public static readonly Metric ElectricalConductance = new() { Time = 3, Length = -2, Mass = -1, Current = 2 };

    /// <summary>Represents the derived unit of electrical inductance, measured in <i>henries</i>.</summary>
    public static readonly Metric ElectricalInductance = new() { Time = -2, Length = 2, Mass = 1, Current = -2 };

    /// <summary>Represents the derived unit of electrical potential difference, measured in <i>volts</i>.</summary>
    public static readonly Metric ElectricalPotentialDifference = new() { Time = -3, Length = 2, Mass = 1, Current = -1 };

    /// <summary>Represents the derived unit of electrical resistance, measured in <i>ohms</i>.</summary>
    public static readonly Metric ElectricalResistance = new() { Time = -3, Length = 2, Mass = 1, Current = -2 };

    /// <summary>Represents the derived unit of energy, measured in <i>joules</i>.</summary>
    public static readonly Metric Energy = new() { Time = -2, Length = 2, Mass = 1 };

    /// <summary>Represents the derived unit of equivalent dose, measured in <i>sieverts</i>.</summary>
    public static readonly Metric EquivalentDose = new() { Time = -2, Length = 2 };

    /// <summary>Represents the derived unit of force, measured in <i>newtons</i>.</summary>
    public static readonly Metric Force = new() { Time = -2, Length = 1, Mass = 1 };

    /// <summary>Represents the derived unit of frequency, measured in <i>hertz</i>.</summary>
    public static readonly Metric Frequency = new() { Time = -1 };

    /// <summary>Represents the derived unit of illuminance, measured in <i>lux</i>.</summary>
    public static readonly Metric Illuminance = new() { Length = -2, Intensity = 1, Angle = 2 };

    /// <summary>Represents the derived unit of luminous flux, measured in <i>lumens</i>.</summary>
    public static readonly Metric LuminousFlux = new() { Intensity = 1, Angle = 2 };

    /// <summary>Represents the derived unit of magnetic flux, measured in <i>webers</i>.</summary>
    public static readonly Metric MagneticFlux = new() { Time = -2, Length = 2, Mass = 1, Current = -1 };

    /// <summary>Represents the derived unit of magnetic induction, measured in <i>teslas</i>.</summary>
    public static readonly Metric MagneticInduction = new() { Time = -2, Mass = 1, Current = -1 };

    /// <summary>Represents the derived unit of power, measured in <i>watts</i>.</summary>
    public static readonly Metric Power = new() { Time = -3, Length = 2, Mass = 1 };

    /// <summary>Represents the derived unit of pressure, measured in <i>pascals</i>.</summary>
    public static readonly Metric Pressure = new() { Time = -2, Length = -1, Mass = 1 };

    /// <summary>Represents the derived unit of radioactivity, measured in <i>becquerels</i>.</summary>
    public static readonly Metric Radioactivity = new() { Time = -1 };

    /// <summary>Represents the derived unit of a solid angle, measured in <i>steradians</i>.</summary>
    public static readonly Metric SolidAngle = new() { Angle = 2 };

    public Metric() { }

    //
    // Interface Implementations
    //

    static Metric ISystemOfMeasurement<Metric>.Dimensionless => Dimensionless;

    static Metric IDerivedUnits<Metric>.AbsorbedDose => AbsorbedDose;
    static Metric IDerivedUnits<Metric>.CatalyticActivity => CatalyticActivity;
    static Metric IDerivedUnits<Metric>.ElectricCharge => ElectricCharge;
    static Metric IDerivedUnits<Metric>.ElectricalCapacitance => ElectricalCapacitance;
    static Metric IDerivedUnits<Metric>.ElectricalConductance => ElectricalConductance;
    static Metric IDerivedUnits<Metric>.ElectricalInductance => ElectricalInductance;
    static Metric IDerivedUnits<Metric>.ElectricalPotentialDifference => ElectricalPotentialDifference;
    static Metric IDerivedUnits<Metric>.ElectricalResistance => ElectricalResistance;
    static Metric IDerivedUnits<Metric>.Energy => Energy;
    static Metric IDerivedUnits<Metric>.EquivalentDose => EquivalentDose;
    static Metric IDerivedUnits<Metric>.Force => Force;
    static Metric IDerivedUnits<Metric>.Frequency => Frequency;
    static Metric IDerivedUnits<Metric>.Illuminance => Illuminance;
    static Metric IDerivedUnits<Metric>.LuminousFlux => LuminousFlux;
    static Metric IDerivedUnits<Metric>.MagneticFlux => MagneticFlux;
    static Metric IDerivedUnits<Metric>.MagneticInduction => MagneticInduction;
    static Metric IDerivedUnits<Metric>.Power => Power;
    static Metric IDerivedUnits<Metric>.Pressure => Pressure;
    static Metric IDerivedUnits<Metric>.Radioactivity => Radioactivity;
    static Metric IDerivedUnits<Metric>.SolidAngle => SolidAngle;

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
