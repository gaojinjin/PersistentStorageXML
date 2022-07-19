using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class SaveXmlManager : MonoBehaviour
{
    public List<Book> books = new List<Book>();
    public string fileName;
    void Start()
    {
        XmlDocument xml = new XmlDocument();
        XmlElement root = xml.CreateElement("Root");
        root.SetAttribute("Root","¼¼ÄÜ");

        foreach (var item in books)
        {
            XmlElement book = xml.CreateElement("Book");
            book.SetAttribute("ID",item.id.ToString());
            root.AppendChild(book);

            XmlElement name = xml.CreateElement("Name");
            book.AppendChild(name);
            name.InnerText = item.bookName;

            XmlElement author = xml.CreateElement("Author");
            book.AppendChild(author);
            name.InnerText = item.author;
        }
        xml.AppendChild(root);
        string path = Application.streamingAssetsPath + "/" + fileName + ".xml";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        xml.Save(path);
    }

   
}
[System.Serializable]
public class Book {
    public int id;
    public string bookName;
    public string author;
}