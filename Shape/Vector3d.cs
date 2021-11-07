using System;

namespace GK_P2.Shape
{
    class Vector3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Length() => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

        public Vector3d ToVersor()
        {
            double length = this.Length();
            return new Vector3d() { X = this.X / length, Y = this.Y / length, Z = this.Z / length };
        }

        public double ScalarProduct(Vector3d otherVector)
        {
            return this.X * otherVector.X + this.Y * otherVector.Y + this.Z * otherVector.Z;
        }

        public double GetCos(Vector3d otherVector)
        {
            return (this.ScalarProduct(otherVector) / (this.Length() * otherVector.Length()));
        }

        public static Vector3d operator *(Vector3d a, double multiplier)
        {
            return new Vector3d() { X = a.X * multiplier, Y = a.Y * multiplier, Z = a.Z * multiplier };
        }

        public static Vector3d operator -(Vector3d a, Vector3d b)
        {
            return new Vector3d() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }

        public static Vector3d operator +(Vector3d a, Vector3d b)
        {
            return new Vector3d() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
    }
}
