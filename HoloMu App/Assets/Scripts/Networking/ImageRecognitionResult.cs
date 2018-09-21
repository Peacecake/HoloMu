using HoloMu.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
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
                List<MoreInfo> oldValues = e.moreinfos.ToList();
                MoreInfo desc = new MoreInfo();
                desc.name = "Allgemein";
                desc.datatype = "text";
                desc.text = e.description;
                oldValues.Insert(0, desc);
                e.moreinfos = oldValues.ToArray();
                this.SExhibit = e;
                // this.Exhibit = parser.ParseExhibit(resultText);
            }
        }
    }
}
