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
        private static int count = -1;
        
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
        private List<Point> points = new List<Point>();


        public Cluster(List<Point> points)
        {
            this.points = new List<Point>(points);

        }

        public string ToString()
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = "";
            for (int i = 0; i < points.Count; i++)
            {
                if (i == 0)
                {
                    str += "{";
                }
                str += $"{alpha[i]}({points[i].X},{points[i].Y})";
                if (i != points.Count - 1)
                {
                    str += ", ";
                }
            }
            return str + "}";
        }


        public static double Distance(Cluster a, Cluster b)
        {
            if (a.points.Count == 0 || b.points.Count == 0)
            {
                throw new ArgumentException("Cụm không được rỗng");
            }

            double minDistance = double.MaxValue;


            foreach (Point p1 in a.points)
            {
                foreach (Point p2 in b.points)
                {
                    double dist = Point.Distance(p1, p2);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                    }
                }
            }

            return minDistance;
        }

        public static Cluster operator +(Cluster a, Cluster b)
        {
            List<Point> aug = new List<Point>(a.points);
            foreach (Point p in b.points)
            {
                aug.Add(p);
            }

            return new Cluster(aug);
            
        }

        public static List<Cluster> HierarchicalClustering(List<Point> points)
        {
            if (points == null || points.Count == 0)
                return new List<Cluster>();

            // Bắt đầu với mỗi điểm là một cụm riêng
            List<Cluster> clusters = new List<Cluster>();
            for (int i = 0; i < points.Count; i++)
            {
                List<Point> singlePointList = new List<Point> { points[i] };
                clusters.Add(new Cluster(singlePointList));
            }

            while (clusters.Count > 1)
            {
                double minDist = double.MaxValue;
                Cluster cluster1 = null;
                Cluster cluster2 = null;

                // Tìm cặp cụm gần nhau nhất
                for (int i = 0; i < clusters.Count - 1; i++)
                {
                    for (int j = i + 1; j < clusters.Count; j++)
                    {
                        double dist = Distance(clusters[i], clusters[j]);
                        if (dist < minDist)
                        {
                            minDist = dist;
                            cluster1 = clusters[i];
                            cluster2 = clusters[j];
                        }
                    }
                }

                // Hợp hai cụm gần nhất
                Cluster merged = cluster1 + cluster2;
                clusters.Remove(cluster1);
                clusters.Remove(cluster2);
                clusters.Add(merged);
            }

            return clusters;
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
            Console.WriteLine(C.ToString());
            Point D = new Point(7, 10);
            Console.WriteLine(D.ToString());
            Console.WriteLine();

            Console.WriteLine("Khoảng cách giữa 2 điểm A và B theo công thức Euclidean:");
            Console.WriteLine(Point.Distance(A, B));
            // Cụm 1
            List<Point> lst1 = new List<Point>{ A, B, C };
            Cluster cluster1 = new Cluster(lst1);
            // Cụm 2
            List<Point> lst2 = new List<Point> { A, C, D };
            Cluster cluster2 = new Cluster(lst2);

            Console.WriteLine("Các điểm có trong cluster 1:");
            Console.WriteLine(cluster1.ToString());
            Console.WriteLine("Các điểm có trong cluster 2:");
            Console.WriteLine(cluster2.ToString());
            // Hợp 2 cluster
            Cluster cluster3 = cluster1 + cluster2;
            Console.WriteLine("Các điểm có trong cluster 3:");
            Console.WriteLine(cluster3.ToString());
            // Phân cụm hierarchical clustering
            List<Point> allPoints = new List<Point> { A, B, C, D };
            Console.WriteLine("Phân cụm hierarchical clustering:");
            List<Cluster> result = Cluster.HierarchicalClustering(allPoints);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].ToString());
            }



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
