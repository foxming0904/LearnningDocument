using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlToObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
 

            var xmlstr = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Message>
  <Body>
    <TRID>TRID</TRID>
  </Body>
</Message>";

            var model = XmlHelper.Deserialize<Message>(xmlstr);
             

            Console.WriteLine(Environment.NewLine);
            Console.Read();
        }


    }

    public class UserInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
    }
}
