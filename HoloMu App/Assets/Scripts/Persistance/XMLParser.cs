using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLParser
{
    private XmlDocument _doc;

    public XMLParser()
    {
        _doc = new XmlDocument();
    }

    public Exhibit ParseExhibit(string xmlString)
    {
        Exhibit result = new Exhibit();
        _doc.LoadXml(xmlString);
        XmlNode rootNode = _doc.SelectSingleNode("/item");
        result.ID = rootNode.Attributes["id"].Value;

        foreach(XmlNode node in rootNode)
        {
            switch (node.LocalName) {
                case "name":
                    result.Name = node.InnerText;
                    break;
                case "category":
                    result.Category = node.InnerText;
                    break;
                case "year":
                    result.Year = node.InnerText;
                    break;
                case "manufacturer":
                    result.Manufacturer = node.InnerText;
                    break;
                case "description":
                    result.Description = node.InnerText;
                    break;
                case "moreinfos":
                    foreach(XmlNode moreInfoNode in node.ChildNodes)
                    {
                        result.AdditionalInformation.Add(moreInfoNode.Attributes["type"].Value, moreInfoNode.InnerText);
                    }
                    break;
            }
        }

        return result;
    }
}
