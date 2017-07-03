using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberToChinese
{
    class Program
    {
        private static readonly DigitToChnText digitToChnText = new DigitToChnText();
        static void Main(string[] args)
        {
            string result = string.Empty;
            do
            {
                string num = string.Empty;
                Console.WriteLine("请输入是3位的整数字符串：");
                do
                {
                    num = Console.ReadLine();
                    if (!IsNumeric(num))
                    {
                        Console.WriteLine("匹配失败！");
                        Console.WriteLine("请输入是3位的整数字符串：");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                if (num.StartsWith("0"))
                {
                    num = NumberHelper.NumberToChinese2(num);
                }
                else
                {
                    num = NumberHelper.NumberToChinese(num);
                    //不限制数字长度时使用
                    //num = digitToChnText.Convert(num, false);
                }
                Console.WriteLine("输入为：" + num);
                Console.Write("输入y继续或任意字符结束：");
                result = Console.ReadLine();
            } while (result.ToLower() == "y");
        }
        private static bool IsNumeric(string message)
        {
            if (message != "" && Regex.IsMatch(message, @"^\d{3}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
