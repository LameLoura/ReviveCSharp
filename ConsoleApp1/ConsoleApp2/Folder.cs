using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

public class Folders
{

    List<Folders> folderList = new List<Folders>();

    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        HashSet<int> test = new HashSet<int>();
        string[] ans = new string[2];
        //ans.Length
        //test.A
        XDocument doc = XDocument.Parse(xml);
        List<String> resources = doc.Descendants("folder")
            .Where( nodes => nodes.Attribute("name").Value != null && nodes.Attribute("name").Value.StartsWith(startingLetter.ToString()))
            .Select(nodes => nodes.Attribute("name").Value).ToList();
        return resources;
    }


    private static T FromXml<T>(String xml)
    {
        T returnedXmlClass = default(T);

        try
        {
            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    returnedXmlClass =
                        (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    // String passed is not XML, simply return defaultXmlClass
                }
            }
        }
        catch (Exception ex)
        {
        }

        return returnedXmlClass;
    }

    public static void Main1(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}