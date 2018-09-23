using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HoloMu.Networking
{
    public class ApiRequest
    {
        public RequestType Type { get; private set; }
        public byte[] File { get; set; }
        public int ExhibitId { get; set; }
        public string URL
        {
            get
            {
                if (ExhibitId != 0) return $"{_baseUrl}/{this.Type.ToString()}/{ExhibitId.ToString()}";
                return $"{_baseUrl}/{this.Type.ToString()}";
            }
            set
            {
                _baseUrl = value;
            }
        }
        public RequestResult Result { get; private set; }

        private string _baseUrl = "";

        public ApiRequest(RequestType type)
        {
            this.Type = type;
        }

        public ApiRequest(RequestType type, byte[] file)
        {
            this.Type = type;
            this.File = file;
        }

        public void HandleResult(bool isSuccessful, string resultText, string error)
        {
            switch (this.Type)
            {
                case RequestType.Test:
                    resultText = "<item id='2o8ru2309'><name>Comodore64</name><category>computer</category><year>1988</year><manufacturer>HansWurst</manufacturer><description>Ein kurze Beschreibung des Objekts</description><moreinfos><moreinfoitem type='Geschichte'>Die Geschichte des Commodore ist wahnsinnig spannend</moreinfoitem><moreinfoitem type='Technische Spezifikation'>Das technische BlaBla ist nicht so spannend.</moreinfoitem><moreinfoitem type='Anwendungen'>Zocken!!!</moreinfoitem></moreinfos></item>";
                    this.Result = new ImageRecognitionResult(isSuccessful, error, resultText);
                    break;
                case RequestType.recognize:
                    this.Result = new ImageRecognitionResult(isSuccessful, error, resultText);
                    break;
                case RequestType.recommend:
                    this.Result = new RecommenderResult(isSuccessful, error, resultText);
                    break;
                default:
                    this.Result = new RequestResult(isSuccessful, error);
                    break;
            }
        }
    }
}
