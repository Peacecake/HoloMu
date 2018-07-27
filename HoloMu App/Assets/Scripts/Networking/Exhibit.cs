using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit : MonoBehaviour
{
    public string ID { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string Category { get { return _category; } set { _category = value; } }
    public string Year { get { return _year; } set { _year = value; } }
    public string Manufacturer { get { return _manufacturer; } set { _manufacturer = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public Dictionary<string, string> AdditionalInformation
    {
        get
        {
            if (_additionalInformation == null)
            {
                _additionalInformation = new Dictionary<string, string>();
            }
            return _additionalInformation;
        }
        set
        {
            _additionalInformation = value;
        }
    }

    private string _id;
    private string _name;
    private string _category;
    private string _year;
    private string _manufacturer;
    private string _description;
    private Dictionary<string, string> _additionalInformation;

	private void Start ()
    {
        _id = "";
        _name = "";
        _category = "";
        _year = "";
        _manufacturer = "";
        _description = "";
        _additionalInformation = new Dictionary<string, string>();	
	}

    public void InitializeFromXmlString(string xmlString)
    {
        XMLParser parser = new XMLParser();
        Exhibit e = parser.ParseExhibit(xmlString);
        _id = e.ID;
        _name = e.Name;
        _category = e.Category;
        _year = e.Year;
        _manufacturer = e.Manufacturer;
        _description = e.Description;
        _additionalInformation = e.AdditionalInformation;

    }
}
