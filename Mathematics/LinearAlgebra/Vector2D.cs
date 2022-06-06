using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// 2D Vector in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles. <typeparamref name="Cartesian"/> and <typeparamref name="Polar"/> coordinates are valid.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Cartesian"></typeparam>
    /// <typeparam name="Polar"></typeparam>
    public struct Vector2D<T> : IVector
        where T : class, ICoordinateSystem, I2D
    {
        private static string? _coordinateSystem;
        public double First { get; set; }
        public double Second { get; set; }

        public Vector2D(double first, double second)
        {
            _coordinateSystem = typeof(T).Name;
            First = first;
            Second = second;
        }

        public static Vector2D<T> operator +(Vector2D<T> left, Vector2D<T> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector2D<T>(left.First + right.First, left.Second + right.Second);
            }
            else
            {
                var result = (left.ToCartesian() + right.ToCartesian()).ToPolar();
                return new Vector2D<T>(result.First, result.Second);
            }
        }

        public static Vector2D<T> operator -(Vector2D<T> left, Vector2D<T> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector2D<T>(left.First - right.First, left.Second - right.Second);
            }
            else
            {
                var result = (left.ToCartesian() - right.ToCartesian()).ToPolar();
                return new Vector2D<T>(result.First, result.Second);
            }
        }

        public static Vector2D<T> operator *(double left, Vector2D<T> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector2D<T>(left * right.First, left * right.Second);
            }
            else
            {
                return new Vector2D<T>(left * right.First, right.Second);
            }
        }

        public static Vector2D<T> operator *(Vector2D<T> left, double right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector2D<T>(left.First * right, left.Second * right);
            }
            else
            {
                return new Vector2D<T>(left.First * right, left.Second);
            }
        }

        public double Length()
        {
            if (_coordinateSystem is "Cartesian")
            {
                return Math.Sqrt(First * First + Second * Second);
            }
            else
            {
                return First;
            }
        }

        public Vector2D<T> Normalize()
        {
            var length = Length();
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector2D<T>(First / length, Second / length);
            }
            else
            {
                return new Vector2D<T>(First / length, Second);
            }
        }

        public Vector2D<Cartesian> ToCartesian()
        {
            return new Vector2D<Cartesian>(First * Math.Cos(Second), First * Math.Sin(Second));
        }

        public Vector2D<Polar> ToPolar()
        {
            return new Vector2D<Polar>(Math.Sqrt(First * First + Second * Second), Math.Atan2(Second, First));
        }

        public override string ToString()
        {
            return $"({First}, {Second})";
        }
    }
}
