using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    interface IVector
    {
        void ShowInfo();
        string Print();
        IVector Add(IVector vector);
        IVector Substract(IVector vector);
        IVector Multiply(double scalar);
        IVector Divide(double scalar);
        double Length();
        IVector Normalize();
        double DotProduct(IVector vector);
        IVector CrossProduct(IVector vector);

    }

    class Vector2D : IVector
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Vector2D: <x: {X}, y: {Y}>");
        }

        public string Print()
        {
            return $"({this.X}, {this.Y})";
        }

        public IVector Add(IVector vt2)
        {
            if (vt2 is Vector2D v2)
            {
                return new Vector2D(this.X + v2.X, this.Y + v2.Y);
            }
            throw new InvalidOperationException("Cannot add non-Vector2D to Vector2D.");
        }

        public IVector Substract(IVector vt2)
        {
            if (vt2 is Vector2D v2)
            {
                return new Vector2D(this.X - v2.X, this.Y - v2.Y);
            }
            throw new InvalidOperationException("Cannot subtract non-Vector2D from Vector2D.");
        }

        public IVector Multiply(double k)
        {
            return new Vector2D(this.X * k, this.Y * k);
        }

        public IVector Divide(double k)
        {
            return new Vector2D(this.X / k, this.Y / k);
        }

        public double Length()
        {
            double x_2 = Math.Pow(this.X, 2);
            double y_2 = Math.Pow(this.Y, 2);

            return Math.Sqrt(x_2 + y_2);
        }

        public IVector Normalize()
        {
            if (this.Length() != 0)
            {
                return new Vector2D(this.X / this.Length(), this.Y / this.Length());
            }
            else return new Vector2D(0, 0);
        }

        public double DotProduct(IVector vt2)
        {
            if (vt2 is Vector2D v2)
            {
                return (this.X * v2.X + this.Y * v2.Y);
            }
            throw new InvalidOperationException("Cannot calculate dot product with non-Vector2D.");
        }

        public IVector CrossProduct(IVector vt2) => throw new NotSupportedException("Cross product is not defined for 2D vectors.");
        
    }

    class Vector3D : IVector
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Vector3D: <x: {X}, y: {Y}, z: {Z}>");
        }

        public string Print()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }

        public IVector Add(IVector vt2)
        {
            if (vt2 is Vector3D v2)
            {
                return new Vector2D(this.X + v2.X, this.Y + v2.Y);
            }
            throw new InvalidOperationException("Cannot add non-Vector3D to Vector3D.");
        }

        public IVector Substract(IVector vt2)
        {
            if (vt2 is Vector3D v2)
            {
                return new Vector3D(this.X - v2.X, this.Y - v2.Y, this.Z - v2.Z);
            }
            throw new InvalidOperationException("Cannot subtract non-Vector3D from Vector3D.");
        }

        public IVector Multiply(double k)
        {
            return new Vector3D(this.X * k, this.Y * k, this.Z * k);
        }

        public IVector Divide(double k)
        {
            return new Vector3D(this.X / k, this.Y / k, this.Z / k);
        }

        public double Length()
        {
            double x_2 = Math.Pow(this.X, 2);
            double y_2 = Math.Pow(this.Y, 2);
            double z_2 = Math.Pow(this.Z, 2);

            return Math.Sqrt(x_2 + y_2 + z_2);
        }

        public IVector Normalize()
        {
            if (this.Length() != 0)
            {
                return new Vector3D(this.X / this.Length(), this.Y / this.Length(), this.Z / this.Length());
            }
            else return new Vector3D(0, 0, 0);

        }

        public double DotProduct(IVector vt2)
        {
            if (vt2 is Vector3D v2)
            {
                return (this.X * v2.X + this.Y * v2.Y + this.Z * v2.Z);
            }
            throw new InvalidOperationException("Cannot calculate dot product with non-Vector3D.");
        }

        public IVector CrossProduct(IVector vt2)
        {
            if (vt2 is Vector3D v2)
            {
                return new Vector3D(
                this.Y * v2.Z - this.Z * v2.Y,
                this.Z * v2.X - this.X * v2.Z,
                this.X * v2.Y - this.Y * v2.X);
            }
            throw new InvalidOperationException("Cannot calculate cross product with non-Vector3D."); 

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            // Tạo list các vector
            List<IVector> vectors = new List<IVector>();

            // Thêm vào các vector ngẫu nhiên
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    vectors.Add(new Vector2D(rnd.NextDouble() * 10, rnd.NextDouble() * 10));
                }
                else
                {
                    vectors.Add(new Vector3D(rnd.NextDouble() * 10, rnd.NextDouble() * 10, rnd.NextDouble() * 10));
                }
            }

            // In ra các vector có trong list
            foreach (IVector vtor in vectors)
            {
                vtor.ShowInfo();
            }

            // Làm các phép tính trên vector
            #region Add 2 vectors

            Console.WriteLine("Add 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        IVector resultAdd = vectors[i].Add(vectors[j]);
                        string add = vectors[i].Print() + " + " + vectors[j].Print() + " = " + resultAdd.Print();
                        Console.WriteLine("\t- " + add);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Substract 2 vectors
            Console.WriteLine("Substract 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        IVector resultMin = vectors[i].Substract(vectors[j]);
                        string sub = vectors[i].Print() + " - " + vectors[j].Print() + " = " + resultMin.Print();
                        Console.WriteLine("\t- " + sub);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Multiply
            Console.WriteLine("Multiply");

            for (int i = 0; i < vectors.Count; i++)
                
                {
                    try
                    {

                        IVector resultMul = vectors[i].Multiply(2);
                        string mul = vectors[i].Print() + " * " + 2 + " = " + resultMul.Print();
                        Console.WriteLine("\t- " + mul);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Divide

            Console.WriteLine("Divide");

            for (int i = 0; i < vectors.Count; i++)
                
                {
                    try
                    {

                        IVector resultDiv = vectors[i].Divide(2);
                        string div = vectors[i].Print() + " \\ " + 2 + " = " + resultDiv.Print();
                        Console.WriteLine("\t- " + div);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Length
            foreach (IVector vtor in vectors)
            {
                Console.WriteLine($"Length of vector {vtor.Print()} = {vtor.Length()}");
            }

            #endregion

            #region Normalize
            foreach (IVector vtor in vectors)
            {
                Console.WriteLine($"Normalize of vector {vtor.Print()} = {vtor.Normalize()}");
            }

            #endregion

            #region Dot product 2 vectors
            Console.WriteLine("Dot product of 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        double resulDot = vectors[i].DotProduct(vectors[j]);
                        string str_resultdot = vectors[i].Print() + " * " + vectors[j].Print() + " = " + resulDot;
                        Console.WriteLine("\t- " + str_resultdot);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Cross Product

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        IVector resultAdd = vectors[i].CrossProduct(vectors[j]);
                        string str_result = vectors[i].Print() + " + " + vectors[j].Print() + " = " + resultAdd.Print();
                        Console.WriteLine("\t- " + str_result);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                    #endregion

            Console.ReadLine();
        }
    }
}
