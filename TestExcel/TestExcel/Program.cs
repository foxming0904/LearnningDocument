using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NPOIExample
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<Student> stus = new List<Student>()
            {
                new Student("小明", 10),
                new Student("小刚", 13)
            };

            IWorkbook wk = new HSSFWorkbook();
            ISheet sheet = wk.CreateSheet("Sheet1");

            int rowIndex = 0;
            foreach (var student in stus)
            {
                IRow row = sheet.CreateRow(rowIndex++);
                row.CreateCell(0).SetCellValue(student.Name);
                row.CreateCell(1).SetCellValue(student.Age);
            }

            // 创建一个FolderBrowserDialog实例  
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // 显示对话框  
            DialogResult result = folderBrowserDialog.ShowDialog();

            string folderPath = "";
            // 如果用户选择了一个文件夹并点击了"确定"  
            if (result == DialogResult.OK)
            {
                // 获取并显示所选文件夹的路径  
                folderPath = folderBrowserDialog.SelectedPath;
                Console.WriteLine("选中的文件夹路径是: " + folderPath);
            }
            else
            {
                // 用户点击了"取消"或其他操作  
                Console.WriteLine("未选择文件夹。");
            }

            using (FileStream file = new FileStream(folderPath+"\\students.xls", FileMode.Create, FileAccess.Write))
            {
                wk.Write(file);
            }
        }
    }

    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}