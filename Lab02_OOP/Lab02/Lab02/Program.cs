/*  ############ LAB 02 ###############
    Cho một lớp Vector2D gồm 2 dữ liệu thành viên x, y 
    kiểu float đặc trưng cho toạ độ của vector 2 chiều.
    1. Xây dựng lớp Vector2D với các fields nói trên.
    2. Bổ sung getter và setter cho 2 fields nói trên.
    3. Khai báo constructor không tham số và có tham số.
    4. Khai báo phương thức Print() để in ra thông tin
    của vector 2D dưới dạng: Vector2D<x: 1.2, y: 3.4>
    5. Khai báo phương thức kiểm tra 2 vector trực giao.
    6. Khai báo phương thức tính độ dài của vector.
    7. Khai báo phương thức xác định góc (theo radian)
    giữa 2 vector.
    Trong chương trình chính: tạo ra một mảng 
    (List, ArrayList hay bất kì cấu trúc collection 
    nào), sau đó kiểm tra tất cả các hàm chức năng
    từ câu 4 đến câu 7.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Vector2D
    {
        private float x;
        private float y;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Vector2D()
        {
            x = 1.2f;
            y = 3.4f;
        }

        public Vector2D(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        // In ra thông tin vector 2D
        public void Print()
        {
            Console.WriteLine($"Vector2D<x: {X}, y: {Y}>");
        }

        // Tính tích vô hướng giữa 2 vector

        public double TichVoHuong(Vector2D vtor2)
        {
            double tichVoHuong = this.X * vtor2.X + this.Y * vtor2.Y;
            return tichVoHuong;
        }
        
        
        // Kiểm tra 2 vector trực giao
        public bool TrucGiao(Vector2D vtor2)
        {
            bool trucGiao = false;
            
            if (TichVoHuong(vtor2) == 0)
            {
                trucGiao = true;
            }

            return trucGiao;
        }


        // Tính độ dài vector
        public double DoDai()
        {
            double trongCan = Math.Pow(X, 2) + Math.Pow(Y, 2);
            return Math.Sqrt(trongCan);
        }


        // Xác định góc giữa 2 vector
        public double Rad(Vector2D vtor2)
        {
            return this.TichVoHuong(vtor2) / DoDai() * vtor2.DoDai();

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            // Tạo danh sách các vector
            List<Vector2D> vectors = new List<Vector2D>
            {
                new Vector2D(),
                new Vector2D(2f, 2f),
                new Vector2D(1f, -1f)
            };

            // In thông tin của từng vector

            foreach (Vector2D vector in vectors)
            {  
                vector.Print();
            }

            // Kiểm tra hai vector có trực giao không

            if (vectors[1].TrucGiao(vectors[2]) == true)
            {
                Console.WriteLine("Vector2 có trực giao với Vector3");
            }
            else
            {
                Console.WriteLine("Vector2 không trực giao với Vector3");
            }


            // Tính độ dài của Vector3

            Console.WriteLine($"Độ dài của Vector3: {vectors[2].DoDai()}");

            // Tính góc giữa Vector2 và Vector3

            double angleRad = vectors[1].Rad(vectors[2]);
            Console.WriteLine($"Góc giữa Vector2 và Vector3 (radian): {angleRad}");

            Console.ReadLine();


        }
    }
}
