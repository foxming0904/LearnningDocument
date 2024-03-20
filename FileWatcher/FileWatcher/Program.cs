using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

class Program
{


    static void Main()
    {

        //创建一个FileSystemWatcher，并设置其属性
        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
        //设置监控的路径
        fileSystemWatcher.Path = @"C:\Users\xtuser424\Desktop\FileWatch\";
        //是否监控指定路径中的子目录
        fileSystemWatcher.IncludeSubdirectories = true;
        //启用
        fileSystemWatcher.EnableRaisingEvents = true;

        //注册监听事件，Created、Changed、Deleted三个事件传递的参数是一样的，我们就用同一个方法来处理就可以了
        fileSystemWatcher.Changed += new FileSystemEventHandler(FileSystemWatcher_EventHandler);
        fileSystemWatcher.Created += new FileSystemEventHandler(FileSystemWatcher_EventHandler);
        //fileSystemWatcher.Deleted += new FileSystemEventHandler(FileSystemWatcher_EventHandler);
        //fileSystemWatcher.Renamed += new RenamedEventHandler(FileSystemWatcher_Renamed);
        //fileSystemWatcher.Error += new ErrorEventHandler(FileSystemWatcher_Error);



        string filePath = @"C:\Users\xtuser424\Desktop\FileWatch\new 1.txt"; // 请将文件路径替换为实际文件的路径 
        List<string> lines = File.ReadAllLines(filePath).ToList();

        string lotNo = "";
        Dictionary<int, List<int>> stripDefects = new Dictionary<int, List<int>>();
        int totalInspection = 0;
        int totalPass = 0;
        int totalReject = 0;
        double passYield = 0.0;

        // 初始化列表以存储提取的代码
        List<string> codes = new List<string>();
        Dictionary<string, List<string>> errNums = new Dictionary<string, List<string>>();

        bool foundLotNo = false;
        foreach (string line in lines)
        {
            // 检查行是否包含代码
            if (line.Contains("PASS") && line.Contains("T.Rej"))
            {
                // 获取包含代码的部分（以制表符分隔）
                string[] parts = line.Split('\t');

                // 提取从第3个元素到最后一个元素
                for (int i = 3; i < parts.Length; i++)
                {
                    codes.Add(parts[i]);
                }
            }
            else if (line.StartsWith("LOT NO :"))
            {
                lotNo = line.Split(':')[1].Trim();
                foundLotNo = true;
            }
            else if (foundLotNo && line.StartsWith("IA"))
            {
                string[] parts = line.Split('\t');
                var key = parts[0].Replace(" ", "-");
                errNums.Add(key, new List<string>());
                 
                var defectCodes = parts.Skip(2).Take(24).ToArray();

                for (int i = 0; i < defectCodes.Length; i++)
                {
                    errNums[key.Replace(" ","-")].Add($"{codes[i]},{defectCodes[i]}");
                }
            }

            else if (line.StartsWith("TOTAL INSPECTION:"))
            {
                totalInspection = int.Parse(line.Split(':')[1].Trim());
            }
            else if (line.StartsWith("TOTAL PASS:"))
            {
                totalPass = int.Parse(line.Split(':')[1].Trim());
            }
            else if (line.StartsWith("TOTAL REJECT:"))
            {
                totalReject = int.Parse(line.Split(':')[1].Trim());
            }
            else if (line.StartsWith("PASS YIELD:"))
            {
                passYield = double.Parse(line.Split(':')[1].Trim());
            }
        }


        List<LotNOItem> lotnoList = new List<LotNOItem>();
        foreach (var errNo in errNums)
        {
            lotnoList.Add(new LotNOItem()
            {
                lossQty = errNo.Value[errNo.Value.Count - 2].Split(',').Last(),
                passQty = errNo.Value[0].Split(',').Last(),
                passRate = errNo.Value[errNo.Value.Count - 1].Split(',').Last(),
                waferSerial = errNo.Key,
                lossCode = string.Join(";", errNo.Value.Skip(1).Take(12))
            });
        }

        Rootobject rootobject = new Rootobject()
        {
            id = "1",
            type = "Nkd.Custom.BusinessOrchestration.WafersOutsourcePostManagement.InputObjects.WafersOutsourceInput, Nkd.Venus.BusinessOrchestration",
            sumQty = totalInspection,
            sumlossQty = totalReject,
            sumpassQty = totalPass,
            sumpassRate = passYield,
            workOrder = lotNo,
            items = lotnoList.ToArray()
        };

        var jsonContent = JsonConvert.SerializeObject(rootobject);


       // Console.WriteLine(jsonContent);
        Console.Read();
    }

    static List<string> files = new List<string>();
    private static object loker=new object();

    public static void FileSystemWatcher_EventHandler( object o,FileSystemEventArgs e)
    { 
        try
        {
            if (!files.Contains(e.FullPath))
            {
                files.Add(e.FullPath);
                Console.WriteLine("upd："+e.FullPath);
                DelayDelete(e.FullPath);
            }
        }
        catch (Exception)
        {
             
        }
    }



    public static async void DelayDelete(string path)
    {
        await Task.Delay(2000);
        lock (loker)
        {
            files.Remove(path);
        }
    }
}
