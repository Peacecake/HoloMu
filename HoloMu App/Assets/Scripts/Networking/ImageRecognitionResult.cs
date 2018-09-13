using HoloMu.Persistance;
using System;
using UnityEngine;

namespace HoloMu.Networking
{
    public class ImageRecognitionResult : RequestResult
    {
        public Exhibit Exhibit { get; private set; }
        public SerializeableExhibit SExhibit { get; private set; }

        public ImageRecognitionResult(bool isSuccessful, string errorMessage, string resultText) : base(isSuccessful, errorMessage)
        {
            if (isSuccessful)
            {
                //  XMLParser parser = new XMLParser();
                resultText = resultText.Replace("u'", "'");
                resultText = resultText.Replace("'", "\"");
                resultText = System.Text.RegularExpressions.Regex.Unescape(@resultText);
                SerializeableExhibit e = JsonUtility.FromJson<SerializeableExhibit>(resultText);
                MoreInfo[] newValues = new MoreInfo[e.moreinfos.Length + 1];
                MoreInfo desc = new MoreInfo();
                desc.name = "Allgemein";
                desc.datatype = "text";
                desc.text = e.description;
                newValues[0] = desc;
                Array.Copy(e.moreinfos, 0, newValues, 1, e.moreinfos.Length);
                this.SExhibit = e;
                // this.Exhibit = parser.ParseExhibit(resultText);
            }
        }
    }
}
