using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 高压测试DTL修改12位
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = "d\t456"; // 要检查的字符串

            // 使用正则表达式匹配字符串是否以数字加制表符开始
            bool isMatch = Regex.IsMatch(input, @"^\d+\t");

            // 输出结果
            if (isMatch)
            {
                Console.WriteLine("字符串以数字加制表符开始。");
            }
            else
            {
                Console.WriteLine("字符串不以数字加制表符开始。");
            }



            string outputFile = $@"C:\Users\xtuser424\Desktop\FileWatch\24B00229-ST-25C-{DateTime.Now.ToString("HHmmssfff")}.dtl";

            string inputFile = @"C:\Users\xtuser424\Desktop\FileWatch\24B00229-ST-25C-COPY.dtl";
            Console.WriteLine(Path.GetExtension(inputFile));
            var lines = File.ReadAllLines(inputFile);

            for (int i = 1210; i < lines.Length; i++)
            {
                var line = lines[i];
                // 拆分行并获取第二列的值
                var parts = line.Split('\t');
                string col = parts[1];
                // 如果第二列的长度是19位，截取为12位
                if (col.Length == 19)
                {   
                    col = col.Substring(0, 12);
                }
                // 更新第二列的值
                parts[1] = col;
                // 将修改后的行重新组合
                lines[i] = string.Join("\t", parts);
            }

       //     File.WriteAllLines(outputFile, lines);
            Console.WriteLine("Wirte finished");
            Console.Read();
        }
    }
}
