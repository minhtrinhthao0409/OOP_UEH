/*
Một cửa hàng bán xe đạp có các đối tượng sau cần quản lý: 
Xe đạp thường, xe đạp đua, xe đạp địa hình, với: 
UsualBicycle (id, color, price, utility),
SpeedBicycle (id, color, price, speedrate), 
ClimpBicycle (id, color, price, climprate).
Trong đó, id, color, price lần lượt là mã, màu, giá của xe; utility là phụ 
kiện tích hợp (yes/no), speedrate là số bước tăng tốc, 
speedclimp là số bước leo dốc.
1/ Xây dựng một lớp ABicycle dưới dạng lớp abstract
để tạo bộ khung dùng chung có các phương thức: Print, 
MakeDeal(id) để in thông tin và giảm giá theo mã.
2/ Cài đặt các lớp UsualBycycle, SpeedBicycle, ClimpBicycle
3/ Tạo một lớp Store chứa một List<ABicycle> và tạo 
ngẫu nhiên 10 xe thuộc ba nhóm nói trên. Lớp Store cung
cấp các phương thức sau:
- Tìm kiếm xe theo bước giá (from - to)
- Sắp xếp một danh sách xe theo tuỳ chọn (tăng/giảm) giá
4/ Cài đặt chương trình chính Main để thực thi kq.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLyXeDap
{
    abstract class ABicycle 
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }

        public abstract void Print();
        public abstract void MakeDeal(string id);
    }

    class UsualBicycle : ABicycle
    {
        private string utility;
        private float sale;

        public string Utility { get => utility; set => utility = value; }
        public float Sale { get => sale; set => sale = value; }

        public UsualBicycle(string id, string color, float price, string utility = "n/a")
        {
            this.Id = id;
            this.Color = color;
            this.Price = price;
            this.Utility = utility;
        }

        public override void Print()
        {
            Console.WriteLine("------Thông tin của xe đạp-----");
            Console.WriteLine($"Loại xe: UsualBicycle | Mã xe: {this.Id} | Màu sắc: {this.Color}\nGía: {this.Price} | Phụ kiện tích hợp: {this.Utility}");
        }

        public override void MakeDeal(string id)
        {
            Console.WriteLine("------Thông tin giảm giá-----");
            Console.WriteLine($"Loại xe: UsualBicycle - Mã xe: {this.Id}\nMàu sắc: {this.Color}" +
                                 $"\nGía gốc: {this.Price}\nSale: {this.Sale}%" +
                                 $"\nThành tiền: {this.Price * (1 - this.Sale)}");
        }

        class SpeedBicycle : ABicycle
        {
            private int speedrate;
            private float sale;

            public int Speedrate { get => speedrate; set => speedrate = value; }
            public float Sale { get => sale; set => sale = value; }

            public SpeedBicycle(string id, string color, float price, int speedrate)
            {
                this.Id = id;
                this.Color = color;
                this.Price = price;
                this.Speedrate = speedrate;
            }

            public override void Print()
            {
                Console.WriteLine("------Thông tin của xe đạp-----");
                Console.WriteLine($"Loại xe: SpeedBicycle | Mã xe: {this.Id} | Màu sắc: {this.Color}\nGía: {this.Price} | Số bước tăng tốc: {this.Speedrate}");
            }

            public override void MakeDeal(string id)
            {
                Console.WriteLine("------Thông tin giảm giá-----");
                Console.WriteLine($"Loại xe: SpeedBicycle - Mã xe: {this.Id}\nMàu sắc: {this.Color}" +
                                     $"\nGía gốc: {this.Price}\nSale: {this.Sale}%" +
                                     $"\nThành tiền: {this.Price * (1 - this.Sale)}");
            }

        }

        class ClimbBicycle : ABicycle
        {
            private int climbrate;
            private float sale;

            public int Climbrate { get => climbrate; set => climbrate = value; }
            public float Sale { get => sale; set => sale = value; }

            public ClimbBicycle(string id, string color, float price, int climbrate)
            {
                this.Id = id;
                this.Color = color;
                this.Price = price;
                this.Climbrate = climbrate;
            }

            public override void Print()
            {
                Console.WriteLine("------Thông tin của xe đạp-----");
                Console.WriteLine($"Loại xe: ClimbBicycle | Mã xe: {this.Id} | Màu sắc: {this.Color}\nGía: {this.Price} | Số bước leo dốc: {this.Climbrate}");
            }

            public override void MakeDeal(string id)
            {
                Console.WriteLine("------Thông tin giảm giá-----");
                Console.WriteLine($"Loại xe: ClimbBicycle - Mã xe: {this.Id}\nMàu sắc: {this.Color}" +
                                     $"\nGía gốc: {this.Price}\nSale: {this.Sale}%" +
                                     $"\nThành tiền: {this.Price * (1 - this.Sale)}");
            }

        }

        class Store
        {
            
            public List<ABicycle> lstBike = new List<ABicycle>();
            public Store()
            {
                Random rnd = new Random();
                string[] bikeColors = { "Matte Black", "Metallic Blue", "Neon Green", "Bright Red", "White", "Silver", "Yellow" };
                for (int i = 0; i <= 10; i++)
                {
                    int category = rnd.Next(1, 3);
                    string color = bikeColors[rnd.Next(0, bikeColors.Length)];
                    float price = (float)rnd.Next(1000, 10000);
                    switch (category)
                    {
                        case 1:
                            int ulti = rnd.Next(0, 2);
                            string strUl;
                            if (ulti == 0) strUl = "no";
                            else if (ulti == 1) strUl = "yes";
                            else strUl = "n/a";
                            lstBike.Add(new UsualBicycle("U" + i, color, price, strUl));
                            break; 

                        case 2:
                            int speedRate = rnd.Next(10, 100);
                            lstBike.Add(new SpeedBicycle("S" + i, color, price, speedRate));
                            break; 

                        default:
                            int climbRate = new Random().Next(5, 30);
                            lstBike.Add(new ClimbBicycle("C" + i, color, price, climbRate));
                            break; 
                    }

                }
            }
            // Search by price

            public List<ABicycle> SearchByPrice(int minVal, int maxVal)
            {
                List<ABicycle> lstByPrice = new List<ABicycle>();

                foreach (ABicycle bike in lstBike)
                {
                    if (bike.Price >= minVal && bike.Price <= maxVal)
                    {
                        lstByPrice.Add(bike);
                    }
                }
                return lstByPrice;
            }

            // Sort by price
            public List<ABicycle> SortedByPrice(bool asc)
            {
                List<ABicycle> clonedLst = new List<ABicycle>();
                foreach (var bike in lstBike)
                {
                    clonedLst.Add(bike); 
                }

                if (asc == true)
                {
                    clonedLst.Sort((x, y) => x.Price.CompareTo(y.Price));
                }
                else
                    clonedLst.Sort((x, y) => y.Price.CompareTo(x.Price));

                return clonedLst;
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;

                Store store1 = new Store();
                Console.WriteLine("Các xe đạp có trong cửa hàng: ");
                foreach (ABicycle bike in store1.lstBike)
                {
                    bike.Print();
                }
                Console.WriteLine("******************************************");
                Console.WriteLine("-------Tìm kiếm theo mức giá-------------");

                Console.WriteLine("Nhập mức giá thấp nhất: ");
                int min = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nhập mức giá cao nhất: ");
                int max = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Xe đạp có giá từ {min} - {max}:");
                List<ABicycle> filter = store1.SearchByPrice(min, max);
                foreach (ABicycle bike in filter)
                {
                    bike.Print();
                }
                Console.WriteLine("******************************************");
                Console.WriteLine("-------Sắp xếp theo mức giá tăng dần-------------"); 
                List<ABicycle> ascLst = store1.SortedByPrice(true);
                foreach (ABicycle bike in ascLst)
                {
                    bike.Print();
                }
                Console.WriteLine("******************************************");
                Console.WriteLine("-------Sắp xếp theo mức giá giảm dần-------------");
                List<ABicycle> descLst = store1.SortedByPrice(false);
                foreach (ABicycle bike in descLst)
                {
                    bike.Print();
                }


                Console.ReadLine();

            }
        }
    }
}

