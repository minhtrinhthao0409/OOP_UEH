/* LAB 03: Lớp số phức
Một lớp số phức gồm có 2 thuộc tính: phần thực (real) và phần ảo (imaginary).
Hãy khai báo một lớp số phức với các yêu cầu sau:
- Có 2 phương thức getter và setter cho mỗi field
- Có 3 dạng constructor: không tham số, có 2 tham số và copy constructor
- Khai báo các phép toán cộng, trừ, nhân, chia 2 số phức
- Khai báo phương thức tính module của số phức
- Khai báo phương thức tính argument của số phức
- Khai báo phương thức cộng số phức với một số thực, sử dụng default params (tối đa 3 số thực)
- Khai báo phương thức cộng nhiều số phức, sử dụng rest params
(Lưu ý: phương thức cộng 2 số phức và phương thức cộng số phức với một số thực và phương thức cộng các số phức phải
sử dụng method overloading.)
Hàm Main: test thử các phương thức nói trên. Lưu ý: tạo một mảng các số phức để thực
thi kết quả.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_OOP
{
    class SoPhuc
    {
        private double phanThuc;
        private double phanAo;

        public double PhanThuc { get => phanThuc; set => phanThuc = value; }
        public double PhanAo { get => phanAo; set => phanAo = value; }

        // Constructor
        public SoPhuc()
        {
            PhanThuc = 1;
            PhanAo = 1;
        }

        public SoPhuc(double pThuc, double pAo)
        {
            PhanThuc = pThuc;
            PhanAo = pAo;
        }

        public SoPhuc(SoPhuc sPhuc)
        {
            PhanThuc = sPhuc.PhanThuc;
            PhanAo = sPhuc.PhanAo;
        }

        public void Print()
        {
            if (PhanAo > 0)
                Console.WriteLine($"{PhanThuc} + {PhanAo}i");
            else if (PhanAo < 0)
                Console.WriteLine($"{PhanThuc} - {PhanAo * -1}i");
            else
                Console.WriteLine($"{PhanThuc}");
        }

        // Cộng, trừ, nhân, chia
        public static SoPhuc Cong(SoPhuc sp1, SoPhuc sp2)
        {
            double thuc = sp1.PhanThuc + sp2.PhanThuc;
            double ao = sp1.PhanAo + sp1.PhanAo;

            return new SoPhuc(thuc, ao);

        }

        public static SoPhuc Tru(SoPhuc sp1, SoPhuc sp2)
        {
            double thuc = sp1.PhanThuc - sp2.PhanThuc;
            double ao = sp1.PhanAo - sp2.PhanAo;

            return new SoPhuc(thuc, ao);

        }

        public static SoPhuc Nhan(SoPhuc sp1, SoPhuc sp2)
        {
            double thuc = sp1.PhanThuc * sp2.PhanThuc - sp1.PhanAo * sp2.PhanAo;
            double ao = sp1.PhanThuc * sp2.PhanAo + sp1.PhanAo * sp2.PhanThuc;

            return new SoPhuc(thuc, ao);

        }

        public static SoPhuc Chia(SoPhuc sp1, SoPhuc sp2)
        {
            double thuc = (sp1.PhanThuc * sp2.PhanThuc + sp1.PhanAo * sp2.PhanAo) / (Math.Pow(sp2.PhanThuc, 2) + Math.Pow(sp2.PhanAo, 2));
            double ao = (-sp1.PhanThuc * sp2.PhanAo + sp1.PhanAo * sp2.PhanThuc) / (Math.Pow(sp2.PhanThuc, 2) + Math.Pow(sp2.PhanAo, 2));

            return new SoPhuc(thuc, ao);

        }

        // Tính module
        public double Module()
        {
            double pThucbp = Math.Pow(PhanThuc, 2);
            double pAobp = Math.Pow(PhanAo, 2);

            return Math.Sqrt(pThucbp + pAobp);

        }

        // Tính argument
        public double Argument()
        {
            return Math.Atan2(PhanAo, PhanThuc);
        }

        // Cộng số phức với một số thực (có default params)
        public static SoPhuc Cong(SoPhuc sp, double r1, double r2 = 0, double r3 = 0 )
        {
            double thuc = sp.PhanThuc + r1 + r2 + r3;
            double ao = sp.PhanAo;

            return new SoPhuc(thuc, ao);
        }

        // Cộng nhiều số phức sử dụng rest params
        public static SoPhuc Cong(params SoPhuc[] numb)
        {
            double tongPhanThuc = 0, tongPhanAo = 0;
            foreach (var num in numb)
            {
                tongPhanThuc += num.PhanThuc;
                tongPhanAo += num.PhanAo;
            }
            return new SoPhuc(tongPhanThuc, tongPhanAo);
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SoPhuc[] arrSoPhuc =
            {
                new SoPhuc(),
                new SoPhuc(1, 2),
                new SoPhuc(4, -5)
            };
        
            // Hiển thị số phức
            Console.WriteLine("Danh sách các số phức:");
            foreach (SoPhuc sophuc in arrSoPhuc)
                sophuc.Print();

            // TÍnh module
            Console.WriteLine($"Module của số phức sp1 là: {Math.Round(arrSoPhuc[0].Module(), 3)} ");

            // Argument
            Console.WriteLine($"Argument của số phức sp1 là: {Math.Round(arrSoPhuc[0].Argument(), 3)} ");

            // Cộng, trừ, chia
            Console.WriteLine($"Phép cộng sp1 + sp2 là:");
            SoPhuc.Cong(arrSoPhuc[0], arrSoPhuc[1]).Print();

            Console.WriteLine($"Phép trừ sp1 - sp2 là:");
            SoPhuc.Tru(arrSoPhuc[0], arrSoPhuc[1]).Print();

            Console.WriteLine($"Phép nhân sp1 * sp2 là:");
            SoPhuc.Nhan(arrSoPhuc[0], arrSoPhuc[1]).Print();

            Console.WriteLine($"Phép chia sp1 / sp2 là:");
            SoPhuc.Chia(arrSoPhuc[0], arrSoPhuc[1]).Print();


            // Tính tổng nhiều số phức
            Console.WriteLine("Tổng sp1 + sp2 + sp3 là:");
            SoPhuc.Cong(arrSoPhuc).Print();

            // Tổng số thức với số thực
            Console.WriteLine("Tổng sp1 + 2.5 là:");
            SoPhuc.Cong(arrSoPhuc[0], 2.5).Print();


            Console.ReadLine();
        }
    }
}
