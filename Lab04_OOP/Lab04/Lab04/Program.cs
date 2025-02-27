/*** Lab 03 ***
Một lớp AVector có các phương thức:
- Print: hiển thị thông tin của lớp
- Add: cộng 2 AVector
- Sub: trừ 2 AVector
- Mul: nhân 2 AVector
- Div: chia 2 AVector
- Dot: tích vô hướng 2 AVector
- Module: độ dài của AVector
- Angle: góc giữa 2 AVector
Tất cả các phương thức ở trên đều đặc tả dưới dạng lớp trừu tượng abstract.

Khai báo 2 lớp Vector2D và Vector3D kế thừa từ AVector. Cài đặt các phương thức ở lớp cha.
Trong đó, lớp Vector2D chứa hai thuộc tính x và y (float); lớp Vector3D chứa ba thuộc tính x, y và z (float).
Bổ sung các phương thức cần thiết khác cho mỗi lớp như constructor, getter, setter nếu cần.

Trong hàm main, tạo ra một List các Vector hỗn hợp (Vector2D và Vector3D). 
Thực hiện các phép toán cơ bản giữa các phần tử trong List.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    // Lớp Avector abstract
    abstract class AVector
    {
        public abstract void ShowInfo();

        public abstract string Print();

        public abstract AVector Add(AVector avtor);

        public abstract AVector Sub(AVector avtor);

        public abstract AVector Mul(AVector avtor);
        
        public abstract AVector Div(AVector avtor);

        public abstract float Dot(AVector avtor);

        public abstract double Module();

        public abstract double Angle(AVector avtor);
        

    }
    
    class Vector2D : AVector
    {
        protected float x;
        protected float y;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        
        public Vector2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Vector2D: <x: {X}, y: {Y}>");
        }

        public override string Print()
        {
            return $"({this.X}, {this.Y})";
        }

        public override AVector Add(AVector vtor2)
        {
            if (vtor2 is Vector2D v2) 
            {
                return new Vector2D(this.X + v2.X, this.Y + v2.Y);
            }
            throw new InvalidOperationException("Cannot add non-Vector2D to Vector2D.");
        }

        public override AVector Sub(AVector vtor2)
        {
            if (vtor2 is Vector2D v2)
            {
                return new Vector2D(this.X - v2.X, this.Y - v2.Y);
            }
            throw new InvalidOperationException("Cannot subtract non-Vector2D from Vector2D.");
        }

        public override AVector Div(AVector vtor2)
        {
            if (vtor2 is Vector2D v2)
            {
                return new Vector2D(this.X / v2.X, this.Y / v2.Y);
            }
            throw new InvalidOperationException("Cannot divide non-Vector2D by Vector2D.");
        }

        public override AVector Mul(AVector vtor2)
        {
            if (vtor2 is Vector2D v2)
            {
                return new Vector2D(this.X * v2.X, this.Y * v2.Y);
            }
            throw new InvalidOperationException("Cannot multiply non-Vector2D with Vector2D.");
        }

        public override float Dot(AVector vtor2)
        {
            if (vtor2 is Vector2D v2)
            {
                return (this.X * v2.X + this.Y * v2.Y);
            }
            throw new InvalidOperationException("Cannot calculate dot product with non-Vector2D.");
        }

        public override double Module()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }

        public override double Angle(AVector vtor2)
        {
            if (vtor2 is Vector2D v2)
            {
                double dot = this.Dot(vtor2);
                double module1 = this.Module();
                double module2 = vtor2.Module();

                if (module1 != 0 && module2 != 0)
                {
                    double cosTheta = dot / (module1 * module2);
                    return Math.Acos(cosTheta);
                }
                else throw new InvalidOperationException("Cannot calculate angle with zero vector.");

            }
            throw new InvalidOperationException("Cannot calculate the angle with a non-Vector2D.");

        }

    }

    class Vector3D : AVector
    {
        
        private float z;
        
        public float Z { get => z; set => z = value; }

        public Vector3D(float x, float y, float z) 
            
            this.Z = z;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Vector3D: <x: {X}, y: {Y}, z: {Z}>");
        }
        public override string Print()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }

        public override AVector Add(AVector vtor3)
        {
            if (vtor3 is Vector3D v3)
            {
                return new Vector3D(this.X + v3.X, this.Y + v3.Y, this.Z + v3.Z);
            }
            throw new InvalidOperationException("Cannot add non-Vector3D to Vector3D.");
        }

        public override AVector Sub(AVector vtor3)
        {
            if (vtor3 is Vector3D v3)
            {
                return new Vector3D(this.X - v3.X, this.Y - v3.Y, this.Z - v3.Z);
            }
            throw new InvalidOperationException("Cannot subtract non-Vector3D from Vector3D.");
        }

        public override AVector Mul(AVector vtor3)
        {
            if (vtor3 is Vector3D v3)
            {
                return new Vector3D(this.X * v3.X, this.Y * v3.Y, this.Z * v3.Z);
            }
            throw new InvalidOperationException("Cannot multiply non-Vector3D with Vector3D.");
        }

        public override AVector Div(AVector vtor3)
        {
            if (vtor3 is Vector3D v3)
            {
                return new Vector3D(this.X / v3.X, this.Y / v3.Y, this.Z / v3.Z);
            }
            throw new InvalidOperationException("Cannot divide non-Vector3D by Vector3D.");
        }

        public override float Dot(AVector vtor3)
        {
            if (vtor3 is Vector3D v3)
            {
                return (this.X * v3.X + this.Y * v3.Y + this.Z + v3.Z);
            }
            throw new InvalidOperationException("Cannot calculate dot product with non-Vector3D.");
        }

        public override double Module()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2));
        }

        public override double Angle(AVector vtor3)
        {
            if (vtor3 is Vector3D)
            {
                double dot = this.Dot(vtor3);
                double module1 = this.Module();
                double module2 = vtor3.Module();

                if (module1 != 0 && module2 != 0)
                {
                    double cosTheta = dot / (module1 * module2);

                    return Math.Acos(cosTheta);
                }
                else throw new InvalidOperationException("Cannot calculate angle with zero vector.");
            }
            throw new InvalidOperationException("Cannot calculate the angle with a non-Vector3D.");

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<AVector> vectors = new List<AVector>
            {
                 new Vector2D(2, 4),
                 new Vector3D(2, 4, 7),
                 new Vector3D(3.5f, 7, 9),
                 new Vector2D(4.7f, 9.5f),
                 new Vector2D(5, 1)
            };

            Console.WriteLine("Information of each vetors in the list:");
            foreach (AVector vtor in vectors)
            {
                Console.Write("\t-  ");
                vtor.ShowInfo();
                
            }
            #region Add 2 vectors

            Console.WriteLine("Add 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        AVector resultAdd = vectors[i].Add(vectors[j]);
                        string add = vectors[i].Print() + " + " + vectors[j].Print() + " = " + resultAdd.Print();
                        Console.WriteLine("\t- "+ add);
                        
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

                        AVector resultMin = vectors[i].Sub(vectors[j]);
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

            #region Multiply 2 vectors
            Console.WriteLine("Multiply 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        AVector resultMul = vectors[i].Mul(vectors[j]);
                        string mul = vectors[i].Print() + " * " + vectors[j].Print() + " = " + resultMul.Print();
                        Console.WriteLine("\t- " + mul);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Divide 2 vectors
            
            Console.WriteLine("Divide 2 vectors");

            for (int i = 0; i<vectors.Count; i++)
                for (int j = i + 1; j<vectors.Count; j++)
                {
                    try
                    {

                        AVector resultDiv = vectors[i].Div(vectors[j]);
                        string div = vectors[i].Print() + " \\ " + vectors[j].Print() + " = " + resultDiv.Print();
                        Console.WriteLine("\t- "+ div);
                        
                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            #region Dot product 2 vectors
            Console.WriteLine("Dot product of 2 vectors");

            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        double resulDot = vectors[i].Dot(vectors[j]);
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

            #region Module of vector
            Console.WriteLine("Module of vector");

            foreach (AVector vtor in vectors)
            {
                float module = (float) vtor.Module();
                Console.WriteLine($"\t- Module of vector {vtor.Print()} : {module}");
            }
            #endregion

            #region Angle between 2 vectors
            Console.WriteLine("Angle of 2 vectors");
            for (int i = 0; i < vectors.Count; i++)
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    try
                    {

                        double resulAng = vectors[i].Angle(vectors[j]);
                        string str_resultAng = $"Angle between {vectors[i].Print()} and {vectors[j].Print()}: {resulAng}";
                        Console.WriteLine("\t- " + str_resultAng);

                    }
                    catch //InvalidOperationException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            #endregion

            Console.ReadKey();
        }
    }
}
