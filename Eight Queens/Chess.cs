using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Queens
{
    public static class Chess
    {
        static int count;
        private static void MoveTheArray(int[] columns, int index)
        {
            int prev = columns[index];
            for (int i = index; i < columns.Length - 1; i++)
            {
                columns[i] = columns[i + 1];
            }
            columns[columns.Length - 1] = prev;
        }
        private static void CheckAndPrint(int[] columns, int index, bool[] differences, bool[] sums)
        {
            //  התנאי מתקיים רק במקרה והנחנו שמונה מלכות שלא מתנגשות על הלוח
            if (index == columns.Length)
            {
                Console.WriteLine();
                Console.WriteLine("option number:" + ++count);
                for (int i = 0; i < columns.Length; i++)
                {
                    Console.Write($"({i},{columns[i]})");
                }
                Console.WriteLine();
                return;
            }
            else
            {
                for (int i = index; i < columns.Length; i++)
                {
                    //בדיקה האם אין באלכסון הנוכחי מלכה כלשהיא בימני ובשמאלי
                    if (!differences[7 + index - columns[index]] && !(sums[columns[index] + index]))
                    {
                        //שמירת המיקום של המלכה הנוכחית בשני האלכסונים השייכים לה
                        differences[7 + index - columns[index]] = sums[index + columns[index]] = true;
                        //מעבר רקורסיבי הממשיך לשים מלכות נוספות על הלוח הוירטואלי
                        CheckAndPrint(columns, index + 1, differences, sums);
                        //פינוי מיקום המלכה בלוח
                        differences[7 + index - columns[index]] = sums[index + columns[index]] = false;
                    }
                    MoveTheArray(columns, index);
                }
            }

        }
        public static void PutEightQueens()
        {
            //מערך עבור שמירת מלכה באלכסון שמאלי
            //באלכסון שמאלי לאורך כל האלכסון סכום הטור והשורה זהה
            bool[] sums = new bool[15];
            //מערך עבור שמירת מלכה באלכסון ימני
            //באלכסון ימני ההפרש בין הטור לשורה זהה לאורך כל האלכסון
            bool[] differences = new bool[15];
            for (int i = 0; i < 8; i++)
            {
                sums[i] = differences[i] = false;
            }
            int[] columns = new int[8];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = i;
            }
            count = 0;
            CheckAndPrint(columns, 0, differences, sums);
        }
    }
}
