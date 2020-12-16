using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

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
            CodingGame();
        }

        private void CodingGame()
        {
            //Question();
            //Question12();
            //Question_13();
            //Question_15();
            //Question_16();
            //Question_17(1, 5);

            //Question_18(new string[] { "-1.001", "1.01" });

            //var next = Question_19();
            //Question_20();
            Question_21();

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
            var res = numbers.Sum(x => float.Parse(x.Replace('.', ',')));//0.008999944
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

            var res = query.Count();//0
            var res2 = query2.Count();//1
        }

        private void Question_15()
        {
            Shape s = new Square();
            Circle c = s as Circle; //null
            Shape c2 = (Circle)s;//exception

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


            var result = sd.Values;//213

        }

        private void Question()
        {
            var m = new Dictionary<object, int>();
            var o1 = new object();
            var o2 = o1;
            m[o1] = 1;
            m[o2] = 2;

            var result = m[o1];
            MessageBox.Show(result.ToString());
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


    }

    public class Node
    {
        public Node left, right;
        public int value;
        private int v;

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

    internal class Shape { }
    internal class Square : Shape { }
    internal class Circle : Shape { }

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

}
