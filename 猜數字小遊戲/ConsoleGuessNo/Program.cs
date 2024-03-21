using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGuessNo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int guess_no,min = 0 ,max = 100;
            Random r = new Random();
            int guess = r.Next(1, 100);
            Console.WriteLine(" ===== 猜數字遊戲 =====");

            do
            {
                count ++;
                Console.Write($"{count}. 猜數字範圍 {min} < ? < {max}：");
                guess_no = int.Parse( Console.ReadLine());


                if (guess_no > 1 && guess_no < 99)
                {
                    if (guess_no == guess)
                    {
                        Console.WriteLine($"恭喜你猜對了！！，共猜 {count} 次");
                        break;
                    }
                    else if (guess_no < guess)
                    {
                        min = guess_no;
                        Console.WriteLine($"再大一點，您已猜 {count} 次");
                    }
                    else if (guess_no > guess)
                    {
                        max = guess_no;
                        Console.WriteLine($"再小一點，您已猜 {count} 次");
                    }
                }
                else
                {
                    Console.WriteLine(" ====== 請依範圍內輸入數字 =====");
                }
            } while (guess_no != guess);
            
            Console.ReadLine();
        }
    }
}
