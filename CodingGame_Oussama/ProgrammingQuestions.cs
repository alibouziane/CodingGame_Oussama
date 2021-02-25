using System;
using System.Linq;

namespace ProgrammingQuestions
{
    class FindSecondLargeInArray
    {
        class RemoveDuplicateCharacters
        {
            static void RemoveDuplicateChars()
            {
                Console.WriteLine("Please eneter your name:");
                string name = Convert.ToString(Console.ReadLine());

                string result = string.Empty;

                for (int i = 0; i < name.Length; i++)
                {
                    if (!result.Contains(name[i]))
                    {
                        result += name[i];
                    }
                }
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }

        static void FindSecondLargeInArrayValues()
        {
            int[] number = new int[5] { 10, 8, 5, 6, 3 };

            int max1 = int.MinValue;
            int max2 = int.MinValue;

            foreach (var item in number)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----Second Highest Number-----");
            foreach (var item in number)
            {
                if (item > max1)
                {
                    max2 = max1;
                    max1 = item;
                }
                else if (item > max2 && item != max1)
                {
                    max2 = item;
                }
            }
            Console.WriteLine(max2);
            Console.ReadLine();
        }

        class ReverseString
        {
            static void Reversestring(string str)
            {

                char[] charArray = str.ToCharArray();
                for (int i = 0, j = str.Length - 1; i < j; i++, j--)
                {
                    charArray[i] = str[j];
                    charArray[j] = str[i];
                }
                string reversestring = new string(charArray);
                Console.WriteLine(reversestring);
                Console.ReadLine();
            }
        }
    }
}