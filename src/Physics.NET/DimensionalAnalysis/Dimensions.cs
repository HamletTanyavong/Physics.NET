// <copyright file="Dimensions.cs" company="Physics.NET">
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

using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Mathematics.NET.Core.Operations;
using Mathematics.NET.Core.Relations;

namespace Physics.NET.DimensionalAnalysis;

/// <summary>Represents the dimensions of a quantity.</summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly struct Dimensions
    : IBitwiseOperators<Dimensions, Dimensions, Dimensions>,
      IDivisionOperation<Dimensions, Dimensions>,
      IMultiplicationOperation<Dimensions, Dimensions>,
      IEqualityRelation<Dimensions, bool>,
      IEquatable<Dimensions>,
      IFormattable
{
    private static FrozenDictionary<int, string> s_names = new Dictionary<int, string>([
        new(0, "time"),
        new(1, "length"),
        new(2, "mass"),
        new(3, "current"),
        new(4, "temperature"),
        new(5, "amount"),
        new(6, "luminous intensity"),
        new(7, "angle")
    ]).ToFrozenDictionary();

    /// <summary>Represents no dimensions.</summary>
    public static readonly Dimensions Dimensionless = new();

    //
    // Dimensions of Base Units
    //

    /// <summary>Represents the dimensions of the base unit of time.</summary>
    public static readonly Dimensions Time = new Dimensions().SetTime(1);

    /// <summary>Represents the dimensions of the base unit of length.</summary>
    public static readonly Dimensions Length = new Dimensions().SetLength(1);

    /// <summary>Represents the dimensions of the base unit of mass.</summary>
    public static readonly Dimensions Mass = new Dimensions().SetMass(1);

    /// <summary>Represents the dimensions of the base unit of electric current.</summary>
    public static readonly Dimensions Current = new Dimensions().SetCurrent(1);

    /// <summary>Represents the dimensions of the base unit of thermodynamic temperature.</summary>
    public static readonly Dimensions Temperature = new Dimensions().SetTemperature(1);

    /// <summary>Represents the dimensions of the base unit of an amount of substance.</summary>
    public static readonly Dimensions Amount = new Dimensions().SetAmount(1);

    /// <summary>Represents the dimensions of the base unit of luminous intensity.</summary>
    public static readonly Dimensions Intensity = new Dimensions().SetIntensity(1);

    /// <summary>Represents the dimensions of the unit of a plane angle.</summary>
    /// <remarks>
    /// In Physics.NET, this has been added to the SI base units for convenience. However, there are justifications for adding it formally. See <see href="https://iopscience.iop.org/article/10.1088/1681-7575/ac7bc2/pdf">On the Dimension of Angles and Their Units</see> by Peter J. Mohr, Eric L. Shirley, William D. Phillips, and Michael Trott.
    /// </remarks>
    public static readonly Dimensions Angle = new Dimensions().SetAngle(1);

    //
    // Dimensions of Derived Units
    //

    /// <summary>Represents the dimensions of the derived unit of ionizing radiation dose.</summary>
    public static readonly Dimensions AbsorbedDose = new Dimensions().SetTime(-2).SetLength(2);

    /// <summary>Represents the dimensions of the derived unit of catalytic activity.</summary>
    public static readonly Dimensions CatalyticActivity = new Dimensions().SetTime(-1).SetAmount(1);

    /// <summary>Represents the dimensions of the derived unit of electric charge.</summary>
    public static readonly Dimensions ElectricCharge = new Dimensions().SetTime(1).SetCurrent(1);

    /// <summary>Represents the dimensions of the derived unit of electrical capacitance.</summary>
    public static readonly Dimensions ElectricalCapacitance = new Dimensions().SetTime(4).SetLength(-2).SetMass(-1).SetCurrent(2);

    /// <summary>Represents the dimensions of the derived unit of electrical conductance.</summary>
    public static readonly Dimensions ElectricalConductance = new Dimensions().SetTime(3).SetLength(-2).SetMass(-1).SetCurrent(2);

    /// <summary>Represents the dimensions of the derived unit of electrical inductance.</summary>
    public static readonly Dimensions ElectricalInductance = new Dimensions().SetTime(-2).SetLength(2).SetMass(1).SetCurrent(-2);

    /// <summary>Represents the dimensions of the derived unit of electrical potential difference.</summary>
    public static readonly Dimensions ElectricalPotentialDifference = new Dimensions().SetTime(-3).SetLength(2).SetMass(1).SetCurrent(-1);

    /// <summary>Represents the dimensions of the derived unit of electrical resistance.</summary>
    public static readonly Dimensions ElectricalResistance = new Dimensions().SetTime(-3).SetLength(2).SetMass(1).SetCurrent(-2);

    /// <summary>Represents the dimensions of the derived unit of energy.</summary>
    public static readonly Dimensions Energy = new Dimensions().SetTime(-2).SetLength(2).SetMass(1);

    /// <summary>Represents the dimensions of the derived unit of equivalent dose.</summary>
    public static readonly Dimensions EquivalentDose = new Dimensions().SetTime(-2).SetLength(2);

    /// <summary>Represents the dimensions of the derived unit of force.</summary>
    public static readonly Dimensions Force = new Dimensions().SetTime(-2).SetLength(1).SetMass(1);

    /// <summary>Represents the dimensions of the derived unit of frequency.</summary>
    public static readonly Dimensions Frequency = new Dimensions().SetTime(-1);

    /// <summary>Represents the dimensions of the derived unit of illuminance.</summary>
    public static readonly Dimensions Illuminance = new Dimensions().SetLength(-2).SetIntensity(1).SetAngle(2);

    /// <summary>Represents the dimensions of the derived unit of luminous flux.</summary>
    public static readonly Dimensions LuminousFlux = new Dimensions().SetIntensity(1).SetAngle(2);

    /// <summary>Represents the dimensions of the derived unit of magnetic flux.</summary>
    public static readonly Dimensions MagneticFlux = new Dimensions().SetTime(-2).SetLength(2).SetMass(1).SetCurrent(-1);

    /// <summary>Represents the dimensions of the derived unit of magnetic induction.</summary>
    public static readonly Dimensions MagneticInduction = new Dimensions().SetTime(-2).SetMass(1).SetCurrent(-1);

    /// <summary>Represents the dimensions of the derived unit of power.</summary>
    public static readonly Dimensions Power = new Dimensions().SetTime(-3).SetLength(2).SetMass(1);

    /// <summary>Represents the dimensions of the derived unit of pressure.</summary>
    public static readonly Dimensions Pressure = new Dimensions().SetTime(-2).SetLength(-1).SetMass(1);

    /// <summary>Represents the dimensions of the derived unit of radioactivity.</summary>
    public static readonly Dimensions Radioactivity = new Dimensions().SetTime(-1);

    /// <summary>Represents the dimensions of the derived unit of a solid angle.</summary>
    public static readonly Dimensions SolidAngle = new Dimensions().SetAngle(2);

    //
    // Dimensions of Other Units
    //

    /// <summary>Represents the dimensions of the quantity of acceleration.</summary>
    public static readonly Dimensions Acceleration = new Dimensions().SetTime(-2).SetLength(1);

    /// <summary>Represents the dimensions of the quantity of angular acceleration.</summary>
    public static readonly Dimensions AngularAcceleration = new Dimensions().SetTime(-2);

    /// <summary>Represents the dimensions of the quantity of angular velocity.</summary>
    public static readonly Dimensions AngularVelocity = new Dimensions().SetTime(-1);

    /// <summary>Represents the dimensions of the quantity of area.</summary>
    public static readonly Dimensions Area = new Dimensions().SetLength(2);

    /// <summary>Represents the dimensions of the quantity of current density.</summary>
    public static readonly Dimensions CurrentDensity = new Dimensions().SetLength(-2).SetCurrent(1);

    /// <summary>Represents the dimensions of the quantity of density.</summary>
    public static readonly Dimensions Density = new Dimensions().SetLength(-3).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of electric field strength.</summary>
    public static readonly Dimensions ElectricFieldStrength = new Dimensions().SetTime(-3).SetLength(1).SetMass(1).SetCurrent(-1);

    /// <summary>Represents the dimensions of the quantity of energy density.</summary>
    public static readonly Dimensions EnergyDensity = new Dimensions().SetTime(-2).SetLength(-1).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of entropy.</summary>
    public static readonly Dimensions Entropy = new Dimensions().SetTime(-2).SetLength(2).SetMass(1).SetTemperature(-1);

    /// <summary>Represents the dimensions of the quantity of magnetic field strength.</summary>
    public static readonly Dimensions MagneticFieldStrength = new Dimensions().SetLength(-1).SetCurrent(1);

    /// <summary>Represents the dimensions of the quantity of moment of force, also known as torque.</summary>
    public static readonly Dimensions MomentOfForce = new Dimensions().SetTime(-2).SetLength(2).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of moment of inertia.</summary>
    public static readonly Dimensions MomentOfInertia = new Dimensions().SetLength(2).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of permeability.</summary>
    public static readonly Dimensions Permeability = new Dimensions().SetTime(-2).SetLength(1).SetMass(1).SetCurrent(-2);

    /// <summary>Represents the dimensions of the quantity of permittivity.</summary>
    public static readonly Dimensions Permittivity = new Dimensions().SetTime(4).SetLength(-3).SetMass(-1).SetCurrent(2);

    /// <summary>Represents the dimensions of the quantity of specific energy.</summary>
    public static readonly Dimensions SpecificEnergy = new Dimensions().SetTime(-2).SetLength(2);

    /// <summary>Represents the dimensions of the quantity of specific heat capacity.</summary>
    public static readonly Dimensions SpecifictHeatCapacity = new Dimensions().SetTime(-2).SetLength(2).SetTemperature(-1);

    /// <summary>Represents the dimensions of the quantity of surface density.</summary>
    public static readonly Dimensions SurfaceDensity = new Dimensions().SetLength(-2).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of surface tension.</summary>
    public static readonly Dimensions SurfaceTension = new Dimensions().SetTime(-2).SetMass(1);

    /// <summary>Represents the dimensions of the quantity of thermal conductivity.</summary>
    public static readonly Dimensions ThermalConductivity = new Dimensions().SetTime(-3).SetLength(1).SetMass(1).SetTemperature(-1);

    /// <summary>Represents the dimensions of the quantity of volume.</summary>
    public static readonly Dimensions Volume = new Dimensions().SetLength(3);

    /// <summary>Represents the dimensions of the quantity of velocity.</summary>
    public static readonly Dimensions Velocity = new Dimensions().SetTime(-1).SetLength(1);

    /// <summary>Represents the dimensions of the quantity of wavenumber.</summary>
    public static readonly Dimensions WaveNumber = new Dimensions().SetLength(-1);

    //
    // Fields
    //

    private readonly Rational<sbyte> _time = new();
    private readonly Rational<sbyte> _length = new();
    private readonly Rational<sbyte> _mass = new();
    private readonly Rational<sbyte> _current = new();
    private readonly Rational<sbyte> _temperature = new();
    private readonly Rational<sbyte> _amount = new();
    private readonly Rational<sbyte> _intensity = new();
    private readonly Rational<sbyte> _angle = new();

    public Dimensions() { }

    public Dimensions(Rational<sbyte> time, Rational<sbyte> length, Rational<sbyte> mass, Rational<sbyte> current, Rational<sbyte> temperature, Rational<sbyte> amount, Rational<sbyte> intensity, Rational<sbyte> angle)
    {
        _time = time;
        _length = length;
        _mass = mass;
        _current = current;
        _temperature = temperature;
        _amount = amount;
        _intensity = intensity;
        _angle = angle;
    }

    internal Rational<sbyte> this[int index]
    {
        get
        {
            if ((uint)index >= 8)
                throw new IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.As<Dimensions, Rational<sbyte>>(ref Unsafe.AsRef(in this)), index);
        }
    }

    //
    // Operators
    //

    public static Dimensions operator ~(Dimensions value)
    {
        var complement = Vector128.OnesComplement(Unsafe.As<Dimensions, Vector128<ulong>>(ref value));
        return Unsafe.As<Vector128<ulong>, Dimensions>(ref complement);
    }

    public static Dimensions operator &(Dimensions left, Dimensions right)
    {
        var and = Vector128.BitwiseAnd(Unsafe.As<Dimensions, Vector128<ulong>>(ref left), Unsafe.As<Dimensions, Vector128<ulong>>(ref right));
        return Unsafe.As<Vector128<ulong>, Dimensions>(ref and);
    }

    public static Dimensions operator |(Dimensions left, Dimensions right)
    {
        var or = Vector128.BitwiseOr(Unsafe.As<Dimensions, Vector128<ulong>>(ref left), Unsafe.As<Dimensions, Vector128<ulong>>(ref right));
        return Unsafe.As<Vector128<ulong>, Dimensions>(ref or);
    }

    public static Dimensions operator ^(Dimensions left, Dimensions right)
    {
        var xor = Vector128.Xor(Unsafe.As<Dimensions, Vector128<ulong>>(ref left), Unsafe.As<Dimensions, Vector128<ulong>>(ref right));
        return Unsafe.As<Vector128<ulong>, Dimensions>(ref xor);
    }

    public static Dimensions operator *(Dimensions left, Dimensions right)
        => new(
            time: left._time + right._time,
            length: left._length + right._length,
            mass: left._mass + right._mass,
            current: left._current + right._current,
            temperature: left._temperature + right._temperature,
            amount: left._amount + right._amount,
            intensity: left._intensity + right._intensity,
            angle: left._angle + right._angle);

    public static Dimensions operator /(Dimensions left, Dimensions right)
        => new(
            time: left._time - right._time,
            length: left._length - right._length,
            mass: left._mass - right._mass,
            current: left._current - right._current,
            temperature: left._temperature - right._temperature,
            amount: left._amount - right._amount,
            intensity: left._intensity - right._intensity,
            angle: left._angle - right._angle);

    //
    // Equality
    //

    public static bool operator ==(Dimensions left, Dimensions right)
        => Vector128.EqualsAll(Unsafe.As<Dimensions, Vector128<ulong>>(ref left), Unsafe.As<Dimensions, Vector128<ulong>>(ref right));

    public static bool operator !=(Dimensions left, Dimensions right)
        => !Vector128.EqualsAll(Unsafe.As<Dimensions, Vector128<ulong>>(ref left), Unsafe.As<Dimensions, Vector128<ulong>>(ref right));

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Dimensions other && Equals(other);

    public bool Equals(Dimensions value)
        => Vector128.EqualsAll(Unsafe.As<Dimensions, Vector128<ulong>>(ref Unsafe.AsRef(in this)), Unsafe.As<Dimensions, Vector128<ulong>>(ref value));

    public override int GetHashCode() => HashCode.Combine(_time, _length, _mass, _current, _temperature, _amount, _intensity, _angle);

    //
    // Formatting
    //

    public override string ToString() => ToString(null, null);

    public string ToString(string? format, IFormatProvider? provider)
    {
        format = string.IsNullOrEmpty(format) ? string.Empty : format.ToUpperInvariant();
        provider ??= NumberFormatInfo.InvariantInfo;

        switch (format)
        {
            case "TIME":
                return $"[time]{GetExponentString(_time)}";
            case "LENGTH":
                return $"[length]{GetExponentString(_length)}";
            case "MASS":
                return $"[mass]{GetExponentString(_mass)}";
            case "CURRENT":
                return $"[current]{GetExponentString(_current)}";
            case "TEMPERATURE":
                return $"[temperature]{GetExponentString(_temperature)}";
            case "AMOUNT":
                return $"[amount]{GetExponentString(_amount)}";
            case "INTENSITY":
                return $"[luminous intensity]{GetExponentString(_intensity)}";
            case "ANGLE":
                return $"[angle]{GetExponentString(_angle)}";
            default:
                List<string> strings = [];
                for (int i = 0; i < 8; i++)
                {
                    var exponent = this[i];
                    if (exponent != Rational<sbyte>.Zero)
                        strings.Add($"[{s_names[i]}]{GetExponentString(exponent)}");
                }
                return strings.Count == 0 ? "Dimensionless" : string.Join(' ', strings);
        }

        string GetExponentString(Rational<sbyte> exponent) => exponent == Rational<sbyte>.One ? string.Empty : $"[{exponent.ToString(null, provider)}]";
    }

    //
    // Helpers
    //

    private Dimensions SetTime(Rational<sbyte> time)
    {
        Unsafe.AsRef(in _time) = time;
        return this;
    }

    private Dimensions SetLength(Rational<sbyte> length)
    {
        Unsafe.AsRef(in _length) = length;
        return this;
    }

    private Dimensions SetMass(Rational<sbyte> mass)
    {
        Unsafe.AsRef(in _mass) = mass;
        return this;
    }

    private Dimensions SetCurrent(Rational<sbyte> current)
    {
        Unsafe.AsRef(in _current) = current;
        return this;
    }

    private Dimensions SetTemperature(Rational<sbyte> temperature)
    {
        Unsafe.AsRef(in _temperature) = temperature;
        return this;
    }

    private Dimensions SetAmount(Rational<sbyte> amount)
    {
        Unsafe.AsRef(in _amount) = amount;
        return this;
    }

    private Dimensions SetIntensity(Rational<sbyte> intensity)
    {
        Unsafe.AsRef(in _intensity) = intensity;
        return this;
    }

    private Dimensions SetAngle(Rational<sbyte> angle)
    {
        Unsafe.AsRef(in _angle) = angle;
        return this;
    }
}
