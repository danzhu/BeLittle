using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Library
{
    public struct Int3
    {
        public int X;
        public int Y;
        public int Z;

        public Int3(int value)
        {
            X = Y = Z = value;
        }

        public Int3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return this == (Int3)obj;
        }

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }

        public static Int3 operator +(Int3 value1, Int3 value2)
            => new Int3(value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z);

        public static Int3 operator -(Int3 value1, Int3 value2)
            => new Int3(value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z);

        public static Int3 operator *(Int3 value, int scaleFactor)
            => new Int3(value.X * scaleFactor, value.Y * scaleFactor, value.Z * scaleFactor);

        public static bool operator ==(Int3 value1, Int3 value2)
            => value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z;

        public static bool operator !=(Int3 value1, Int3 value2)
            => value1.X != value2.X || value1.Y != value2.Y || value1.Z != value2.Z;

        public static implicit operator Vector3(Int3 value)
            => new Vector3(value.X, value.Y, value.Z);
    }
}
