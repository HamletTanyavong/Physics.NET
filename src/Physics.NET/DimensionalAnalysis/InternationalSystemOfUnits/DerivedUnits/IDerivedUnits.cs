// <copyright file="IDerivedUnits.cs" company="Physics.NET">
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

using Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.BaseUnits;

namespace Physics.NET.DimensionalAnalysis.InternationalSystemOfUnits.DerivedUnits;

/// <summary>Defines support for the relevant, named SI coherent derived units.</summary>
/// <remarks>
/// The unit for plane and phase angles can be found in <see cref="IBaseUnits{TBaseUnits, TTime, TLength, TMass, TCurrent, TTemperature, TAmount, TIntensity, TAngle}"/>.
/// </remarks>
/// <typeparam name="T">The type that implements the interface.</typeparam>
internal interface IDerivedUnits<T>
    where T : IDerivedUnits<T>
{
    /// <summary>Represents the quantity of ionizing radiation dose.</summary>
    static abstract T AbsorbedDose { get; }

    /// <summary>Represents the quantity of catalytic activity.</summary>
    static abstract T CatalyticActivity { get; }

    /// <summary>Represents the quantity of electric charge.</summary>
    static abstract T ElectricCharge { get; }

    /// <summary>Represents the quantity of electrical capacitance.</summary>
    static abstract T ElectricalCapacitance { get; }

    /// <summary>Represents the quantity of electrical conductance.</summary>
    static abstract T ElectricalConductance { get; }

    /// <summary>Represents the quantity of electrical inductance.</summary>
    static abstract T ElectricalInductance { get; }

    /// <summary>Represents the quantity of electrical potential difference.</summary>
    static abstract T ElectricalPotentialDifference { get; }

    /// <summary>Represents the quantity of electrical resistance.</summary>
    static abstract T ElectricalResistance { get; }

    /// <summary>Represents the quantity of energy.</summary>
    static abstract T Energy { get; }

    /// <summary>Represents the quantity of equivalent dose.</summary>
    static abstract T EquivalentDose { get; }

    /// <summary>Represents the quantity of force.</summary>
    static abstract T Force { get; }

    /// <summary>Represents the quantity of frequency.</summary>
    static abstract T Frequency { get; }

    /// <summary>Represents the quantity of illuminance.</summary>
    static abstract T Illuminance { get; }

    /// <summary>Represents the quantity of luminous flux.</summary>
    static abstract T LuminousFlux { get; }

    /// <summary>Represents the quantity of magnetic flux.</summary>
    static abstract T MagneticFlux { get; }

    /// <summary>Represents the quantity of magnetic induction.</summary>
    static abstract T MagneticInduction { get; }

    /// <summary>Represents the quantity of power.</summary>
    static abstract T Power { get; }

    /// <summary>Represents the quantity of pressure.</summary>
    static abstract T Pressure { get; }

    /// <summary>Represents the quantity of radioactivity.</summary>
    static abstract T Radioactivity { get; }

    /// <summary>Represents the quantity of a solid angle.</summary>
    static abstract T SolidAngle { get; }
}
