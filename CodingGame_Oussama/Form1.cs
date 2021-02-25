using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CodingGame_Oussama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CodingGame();
            var revision = new Revision();
            revision.CodingGame();

        }

        private void CodingGame()
        {
            var res = 01 | 11;


            var hs = new HashSet<int>();
            hs.Add(1);
            hs.Add(1);
            hs.Add(2);

            var c = hs.Count;

            Question();
            //Question12();
            //Question_13();
            //Question_15();
            //Question_16();
            //Question_17(1, 5);

            //Question_18(new string[] { "-1.001", "1.01" });

            //var next = Question_19();
            //Question_20();
            //Question_21();

            //Question_8_25();
            //Question_22_25();
            ////Question_24_25(); //isTwin
            //Question_25_25();




        }

        private void Question_25_25()
        {
            bool result1 = Check("[()]"); //true
            bool result2 = Check("(())[]"); //true
            bool result3 = Check("[([))]"); //false
            bool result4 = Check("(("); //false

            bool result5 = Check("[](())[]"); //true

        }

        private bool Check(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            if (s.Length == 1) return false;

            var first = s.First();
            s = s.Substring(1, s.Length - 1);

            if (first == '(')
            {
                //search the first ')' and remove it 
                var i = 0;
                foreach (var ch in s)
                {
                    if (ch == ')')
                    {
                        s = s.Remove(i, 1);
                        break;
                    }
                    i++;
                }
            }

            else if (first == '[')
            {
                //search the first ']' and remove it 
                var i = 0;
                foreach (var ch in s)
                {
                    if (ch == ']')
                    {
                        s = s.Remove(i, 1);
                        break;
                    }
                    i++;
                }
            }

            return Check(s);
        }

        private bool Check2(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var first = s.First();
            var last = s.Last();

            if (first == '(' && last != ')') return false;
            if (first == '[' && last != ']') return false;

            s = s.Substring(1, s.Length - 2);
            if (!string.IsNullOrEmpty(s))
                return Check(s);
            return true;
        }

        private void Question_24_25()
        {
            bool result = IsTwin("lookout", "outlook");
            bool result1 = IsTwin("Hello", "world");
            bool result2 = IsTwin("acb", "bca");
            bool result3 = IsTwin("listen", "silent");

            result = IsTwin2("lookout", "outlook");
            result1 = IsTwin2("Hello", "world");
            result2 = IsTwin2("acb", "bca");
            result3 = IsTwin2("listen", "silent");

        }

        private bool IsTwin(string a, string b)
        {
            if (a.Length != b.Length) return false;

            foreach (char letter in a)
            {
                if (!b.ToLowerInvariant().Contains(letter.ToString().ToLowerInvariant()))
                    return false;
            }
            return true;

            //return a.All(letter => b.ToLowerInvariant().Contains(letter.ToString().ToLowerInvariant()));

        }

        private bool IsTwin2(string a, string b)
        {
            if (a.Length != b.Length) return false;

            var la = a.OrderBy(x => x.ToString().ToLower());
            var lb = b.OrderBy(x => x.ToString().ToLower());

            return la.SequenceEqual(lb);

        }

        struct Struct
        {
            public int foo;
        }

        public class ClassExample
        {
            public int foo;
        }

        private void Question_22_25()
        {
            //value
            Struct struct1;
            struct1.foo = 5;

            Struct struct2 = struct1;
            struct2.foo = 10;
            var res = struct1.foo;//5


            //reference
            ClassExample class1 = new ClassExample();
            class1.foo = 5;

            ClassExample class2 = class1;
            class2.foo = 10;
            var res2 = class1.foo;//10



        }

        private void Question_8_25()
        {
            A.B b = new A.B();
            //var result=b.

            var y = A.toto;

            throw new IndexOutOfRangeException();
            throw new NullReferenceException();



        }

        private void Question_21()
        {
            var smal = new Node(9)
            {
                left = new Node(13),
                right = new Node(7),
            };

            smal.left.right = null;
            smal.left.left = new Node(17);

            smal.right.right = new Node(5);
            smal.right.left = new Node(8);

            var large = new Node(0);
            Node node = smal.Find(8);


            //Node root = new Node(0);
            //root.left = new Node(1);
            //root.left.left = new Node(3);
            //root.left.left.left = new Node(7);
            //root.left.right = new Node(4);
            //root.left.right.left = new Node(8);
            //root.left.right.right = new Node(9);
            //root.right = new Node(2);
            //root.right.left = new Node(5);
            //root.right.right = new Node(6);

            //int key = 4;

            //var ret = node.value;

            node = large.Find(0);


        }

        private void Question_20()
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
            var pi = Pi.Apporx(rands);
        }


        private static int Question_19()
        {
            int count = 0;
            object LOCK = new object();
            lock (LOCK)
            {
                count++;
            }
            return count;
        }

        private void Question_18(params string[] numbers)
        {
            var res = numbers.Sum(x => float.Parse(x.Replace('.', ','))); //0.008999944
        }

        private bool Question_17(int i, int j)
        {
            return i == 1 || j == 1 || (i + j) == 1;
        }

        private void Question_16()
        {
            string[] fruits = { "apple", "orange", "apricot", "kiwi" };
            var list = new List<string>(fruits);
            IEnumerable<string> query = list.Where(c => c.Length == 4);
            List<string> query2 = list.Where(c => c.Length == 4).ToList();

            list.Remove("kiwi");

            var res = query.Count(); //0
            var res2 = query2.Count(); //1
        }

        private void Question_15()
        {
            Shape s = new Square();
            Circle c = s as Circle; //null
            Shape c2 = (Circle)s; //exception

        }

        private void Question_13()
        {
            var d = new DateTime(0);
            d.AddHours(2);

            var result = d.Hour;
        }

        private void Question12()
        {
            var sd = new SortedDictionary<int, int>();
            sd[3] = 3;
            sd[2] = 1;
            sd[1] = 2;


            var result = sd.Values; //213

        }

        private void Question()
        {
            var m = new Dictionary<object, int>();
            var o1 = new object();
            var o2 = o1;
            m[o1] = 1;
            m[o2] = 2;

            var result = m[o1];
            MessageBox.Show(result.ToString());//2 et m.count =1 O1 et o2 pointent sur le meme object 
        }

        public class ImaginaryNumber
        {
            public int MyProperty { get; set; }
            public string Type { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodingGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var revision = new Revision();
            revision.CodingGame();
        }
    }

    public class Node
    {
        public Node left, right;
        public int value;

        public Node(int v)
        {
            this.value = v;
            left = right = null;
        }

        public Node Find(Node node, int key)
        {
            if (node == null)
                return null;

            if (node.value == key)
                return node;

            // then recur on left sutree /
            var res1 = Find(node.left, key);

            // node found, no need to look further
            if (res1.value == key)
                return res1;

            // node is not found in left, 
            // so recur on right subtree /
            var res2 = Find(node.right, key);

            return res2;
        }



        // Function to check the given key exist or not 
        static bool iterativeSearch(Node root, int key)
        {
            // Traverse untill root reaches to dead end 
            while (root != null)
            {
                // pass right subtree as new tree 
                if (key > root.value)
                    root = root.right;

                // pass left subtree as new tree 
                else if (key < root.value)
                    root = root.left;
                else
                    return true; // if the key is found return 1 
            }
            return false;
        }

        public Node Find2(int key)  // the correct
        {
            // Traverse untill root reaches to dead end 
            var root = this;
            while (root != null)
            {
                // pass right subtree as new tree 
                if (key > root.value)
                    root = root.right;

                // pass left subtree as new tree 
                else if (key < root.value)
                    root = root.left;
                else
                    return root; // if the key is found return 1 
            }
            return null;
        }

        public bool Search(Node node, int key)
        {
            if (node == null)
                return false;

            if (node.value == key)
                return true;
            if (node.value < key)
                return Search(node.right, key);
            if (node.value > key)
                return Search(node.left, key);
            return false;



        }

        public Node Find(int key)
        {

            if (key == value)
                return this;

            key = left.value;

            // then recur on left sutree /
            var res1 = Find(key);

            // node found, no need to look further
            if (res1.value == key)
                return res1;

            key = right.value;

            // node is not found in left, 
            // so recur on right subtree /
            var res2 = Find(key);

            return res2;
        }




    }

    internal class Shape
    {
    }

    internal class Square : Shape
    {
    }

    internal class Circle : Shape
    {
    }

    class Point
    {
        public double x, y;
    }

    static class Pi
    {
        public static double Apporx(Point[] pts)
        {
            //points inside the circle

            var insides = pts.Count(p => p.x * p.x + p.y * p.y <= 1);
            var prob = (double)insides / pts.Length;
            return 4 * prob; //pi

        }
    }

    public abstract class A
    {
        public string str = "foo";
        private ArrayList err = null;
        protected internal static string toto;

        public class B
        {
        }

        public virtual void Methode()
        {

        }

        public abstract void Method2();
    }

    static class C
    {
    }

    public class D : A
    {
        public override void Methode()
        {
            base.Methode();
        }

        public override void Method2()
        {
            var mock = new MockComposite<B>(new B());
        }
    }



    class MockComposite<T> where T : A.B, new()
    {
        T _toTest;

        public MockComposite()
        {
            _toTest = new T();
        }
        public MockComposite(T gen)
        {
            _toTest = new T();
        }
    }
}









