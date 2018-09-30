using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HoloMu.Networking
{
    public class ImageRecognitionResult : RequestResult
    {
        public SerializeableExhibit SExhibit { get; private set; }

        public ImageRecognitionResult(bool isSuccessful, string errorMessage, string resultText) : base(isSuccessful, errorMessage)
        {
            if (resultText.Equals(""))
            {
                isSuccessful = false;
                errorMessage = "Exponat nicht erkannt. Versuchen Sie es bitte noch einmal!";
            }
            if (isSuccessful)
            {
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
            }
        }
    }
}
