using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("view-source_https___habr.com_rss_interesting_.xml");

            PrintXml(doc);

            XmlElement status = doc.CreateElement("status");
            status.InnerText = "Active";

            XmlNodeList title = doc.GetElementsByTagName("title");
           
            XmlElement root = doc.DocumentElement;
            //root.AppendChild(status);
            //root.InsertAfter(status, title[0]);
            //root.InsertBefore(status, title[0]);

            CreateElement(doc, "TesElement");

            doc.Save("view-source_https___habr.com_rss_interesting_.xml");

            Console.WriteLine("---------------------");
            Console.WriteLine("File Save");
            Console.WriteLine("---------------------");
            PrintXml(doc);
        }

        public static void PrintXml(XmlDocument doc)
        {
            //get root element
            var root = doc.DocumentElement;
            
            foreach (XmlNode item in root.ChildNodes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Name);
                Console.ForegroundColor = ConsoleColor.White;

                if (item.HasChildNodes)
                    foreach (XmlNode child in item.ChildNodes)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("   " + child.Name);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
            }
        }

        public static void CreateElement(XmlDocument doc, string elementName)
        {
            //1
            XmlElement element = doc.CreateElement(elementName);
            element.InnerText = DateTime.Now.ToString();


            XmlAttribute xmlAttr = doc.CreateAttribute("Id");
            xmlAttr.InnerText = "551704";

            element.Attributes.Append(xmlAttr);

            XmlElement root = doc.DocumentElement;
            root.AppendChild(element);
            
            //doc.AppendChild(element);



        }
    }
}
