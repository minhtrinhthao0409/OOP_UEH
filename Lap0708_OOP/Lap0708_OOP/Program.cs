using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap0708_OOP
{
    class Point
    {
        private double x;
        private double y;
        public static int count = -1;
        
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            count++;
        }

        public string ToString()
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            return $"{alpha[count]}({this.x},{this.y})";
        }

        public static double Distance(Point a, Point b)
        {
            return  Math.Sqrt (Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y , 2)) ;
        }

    }

    class Cluster
    {
        public List<Point> lstPoint = new List<Point>();


        public Cluster(List<Point> lstPoint)
        {
            this.lstPoint = lstPoint;

        }

        public string ToString()
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = "";
            for (int i = 0; i < lstPoint.Count; i++)
            {
                if (i == 0)
                {
                    str += "{";
                }
                str += $"{alpha[i]}({lstPoint[i].X},{lstPoint[i].Y})";
                if (i != lstPoint.Count - 1)
                {
                    str += ", ";
                }
            }
            return str + "}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Point A = new Point(2, 3);
            Console.WriteLine(A.ToString());
            Point B = new Point(3, 4);
            Console.WriteLine(B.ToString());
            Point C = new Point(5, 6);
            Console.WriteLine(B.ToString());
            Console.WriteLine();

            Console.WriteLine("Khoảng cách giữa 2 điểm A và B theo công thức Euclidean:");
            Console.WriteLine(Point.Distance(A, B));
            List<Point> lst = new List<Point>{ A, B, C };
            Cluster cluster1 = new Cluster(lst);
            Console.WriteLine("Các điểm có trong cluster 1:");
            Console.WriteLine(cluster1.ToString());


        }
    }
}


/* Lab 07 - 08 (Lab 07 từ câu 01-05, Lab 08 từ câu 06-07).
    Một lớp Point trong hệ toạ độ Descartes 2 chiều gồm các
    thuộc tính: x, y. Một lớp Cluster chứa một list các Point.
    1/ Xây dựng lớp Point.
    2/ Bổ sung vào Point: ToString dạng A(x, y), distance
     - tính khoảng cách giữa 2 điểm theo Euclidean.
    3/ Bổ sung vào lớp Cluster: ToString dạng {A(x, y), B(x, y), C(x, y)}
    4/ Bổ sung phương thức distance cho Cluster để tính
    khoảng cách giữa các cụm theo single linkage (theo
    khoảng cách nhỏ nhất giữa các cặp điểm của 2 cụm).
    5/ Bổ sung operator + để hợp 2 Cluster.
    6/ Cài đặt thuật toán hierarchical clustering để phân
     cụm (với single linkage).
        - public List<Cluster> HierarchicalClustering()
    7/ Triển khai kết quả trong hàm main.
*/
