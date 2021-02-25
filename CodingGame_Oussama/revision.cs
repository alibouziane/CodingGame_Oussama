using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace CodingGame_Oussama
{
    public class Revision
    {
        private int _count;

        public void CodingGame()
        {

            //MessageBox.Show(question20_26().ToString());
            //question24_26();
            //question25_26();
            //question26_26();
            //var res = new[] { "apple", "orange", "apricot", "kiwi" }.Max((c => c.Length));

            //kata2
            //var m = new Dictionary<object, int>();
            //var o1 = 1;
            //var o2 = o1;
            //m[o1] = 1;
            //m[o2] = 2; // m[o1] -> 2

            //var h1 = o1.GetHashCode();
            //var h2 = o2.GetHashCode();
            //var res = h1 == h2;//true


            //var d=new DateTime(0);

            //d.AddHours((2));
            //var h = d.Hour;


            //question_18_25();
            //var res = question_19_19();
            //question_20_29();
            //question_08_25();
            //question_24_25();
            //question_25_25();
            GetSuperCustomer();


        }

        private void question_25_25()
        {
            bool result1 = Check("[()]"); //true
            bool result2 = Check("(())[]"); //true
            bool result3 = Check("[([))]"); //false
            bool result4 = Check("(("); //false

            bool result5 = Check("[](())[]"); //true
            bool result6 = Check("([)]"); //false


        }

        private bool Check(string str)
        {
            if (str.Count(x => x.Equals('(')) != str.Count(x => x.Equals(')')))
                return false;
            if (str.Count(x => x.Equals('[')) != str.Count(x => x.Equals(']')))
                return false;
            return true;

        }

        private bool CheckOld(string str)
        {
            var result = str;
            foreach (var c in str)
            {
                if (c == '[')
                    result = RemoveFirst(result, ']');
                else if (c == '(')
                    result = RemoveFirst(result, ')');

                if (string.IsNullOrEmpty(result)) return true;

                if (result.Length == 1) return false;

            }
            return false;
        }

        private string RemoveFirst(string str, char c)
        {
            str = str.Remove(0, 1);
            var toremove = str.IndexOf(c);
            if (toremove != -1)
                str = str.Remove(toremove, 1);
            return str;
        }

        private void question_24_25()
        {
            bool result = IsTwin("Silent", "Listen");
            result = IsTwin("Lookout", "Outlook");

        }

        private bool IsTwin(string a, string b)
        {

            return a.ToUpper().OrderBy(x => x).SequenceEqual(b.ToUpper().OrderBy(x => x));

        }

        private void question_08_25()
        {
            A.B b = new A.B();
            //var res = b.str; compile time error

        }


        public class A
        {
            public static string str = "foo";

            public class B
            {

            }

        }
        public class D : A
        {

        }




        private void question_20_29()
        {
            var rands = new Point[100000];
            Random random = new Random();
            for (int i = 0; i < rands.Length; i++)
            {
                Point p = new Point();
                p.x = random.NextDouble();
                p.y = random.NextDouble();
                rands[i] = p;

            }
            var pi = Apporx(rands);

        }

        private double Apporx(Point[] rands)
        {
            if (rands.Length == 0) return 0;
            var nbPointInside = rands.Count(p => (Math.Pow(p.x, 2) + Math.Pow(p.y, 2)) <= 1);

            var pi = 4 * (double)nbPointInside / rands.Length;//3.14
            return pi;
        }


        private int question_19_19()
        {
            var locker = new object();
            Monitor.Enter(locker);
            //lock (locker)
            {
                _count = _count + 1;
            }
            Monitor.Exit(locker);
            return _count;

        }

        private void question_18_25()
        {
            string res = Sum("-1.001", "1.01");//"0.008999944"



        }

        private string Sum(params string[] numbers)
        {
            return numbers.Sum(n => float.Parse(n.Replace('.', ','))).ToString(CultureInfo.InvariantCulture);
        }

        //kata1

        private void question26_26()
        {
            var result = LocateFormula();



        }

        private string LocateFormula()
        {
            var subFolder = @"/tmp/documents";

            string[] allFiles = Directory.GetFiles(subFolder, "universe-formula", SearchOption.AllDirectories);


            return allFiles.FirstOrDefault();







        }

        private void question25_26()
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 3 };
            var res = CalcArray(array, 0, 1);//1
            res = CalcArray(array, 0, 5);//15

        }

        private int CalcArray(int[] array, int p1, int p2)
        {

            var res = new List<int>();

            //for (int i = 0; i < array.Length - 1; i++)
            //{
            //    if (i >= p1 && i <= p2) res.Add(array[i]);
            //}

            for (var i = p1; i <= p2; i++)
            {
                res.Add(array[i]);
            }
            return res.Sum();

        }

        private void question24_26()
        {
            //int[] ints = { -9, 8, 2, -5, 7, -2 };
            int[] ints = { -9, 8, -5, 7, -2 };


            int result = ClosetToZero(ints);
            int result2 = ClosetToZero2(ints);


        }

        private int ClosetToZero2(int[] ints)
        {

            return ints.OrderBy(Math.Abs).First();

        }

        private int ClosetToZero(int[] ints)
        {
            if (ints == null || ints.Length == 0) return 0;

            var maxNegative = ints.Where(x => x <= 0).Max(x => x);
            var minPositive = ints.Where(x => x > 0).Min(x => x);

            if (Math.Abs(maxNegative) == Math.Abs(minPositive)) return Math.Abs(maxNegative);
            return Math.Abs(maxNegative) <= Math.Abs(minPositive) ? maxNegative : minPositive;


        }

        private bool question20_26()
        {
            return Test(1, 5);
            Test(2, 3);
            Test(-3, 4);
        }

        private bool Test(int i, int j)
        {
            return i == 1 || j == 1 || i + j == 1;
        }



        class Order
        {
            public Customer Customer { get; set; }
            public double Price { get; set; }
        }
        public class Customer
        {

            public Customer(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }

        private void GetSuperCustomer()
        {
            List<Order> liste = new List<Order>()
            {
                new Order() {Customer = new Customer("C1"), Price = 110},
                new Order() {Customer = new Customer("C2"), Price = 150},
                new Order() {Customer = new Customer("C3"), Price = 20},
                new Order() {Customer = new Customer("C4"), Price = 20},
                new Order() {Customer = new Customer("C5"), Price = 20},
                new Order() {Customer = new Customer("C5"), Price = 105}
            };


            //rechercher les super customer; customer ayant payé plus que 100
            var super2 = liste.GroupBy(x => x.Customer.Name)
                .Select(g => new { g.Key, g })
                .Where(c => c.g.Any(x => x.Price >= 100))
                .Select(x => x.Key); //c1/c2/c5
        }



    }


}
