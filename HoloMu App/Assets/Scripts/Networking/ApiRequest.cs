using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoloMu.Networking
{
    public class ApiRequest
    {
        public RequestType Type { get; private set; }
        public byte[] File { get; set; }
        public string URL
        {
            get
            {
                // @TODO: Remove test url
                if (this.Type.Equals(RequestType.Test)) return ENDPOINTS[(int)this.Type];
                return BASE_URL + ENDPOINTS[(int) this.Type];
            }
        }
        public RequestResult Result { get; private set; }

        private static readonly string[] ENDPOINTS = new string[] { "recognize", "recommend", "https://jsonplaceholder.typicode.com/posts/1" };
        private const string BASE_URL = "http://localhost:8080/";

        public ApiRequest(RequestType type)
        {
            this.Type = type;
        }

        public void HandleResult(bool isSuccessful, string resultText, string error)
        {
            switch (this.Type)
            {
                case RequestType.Test:
                    resultText = "<item id='2o8ru2309'><name>Comodore64</name><category>computer</category><year>1988</year><manufacturer>HansWurst</manufacturer><description>Ein kurze Beschreibung des Objekts</description><moreinfos><moreinfoitem type='Geschichte'>blablabla</moreinfoitem><moreinfoitem type='Technische Spezifikation'>blablabla</moreinfoitem></moreinfos></item>";
                    this.Result = new ImageRecognitionResult(isSuccessful, error, resultText);
                    break;
                case RequestType.StartRecognize:
                    this.Result = new ImageRecognitionResult(isSuccessful, error, resultText);
                    break;
                case RequestType.GetRecommendation:
                    this.Result = new RecommenderResult(isSuccessful, error);
                    break;
                default:
                    this.Result = new RequestResult(isSuccessful, error);
                    break;
            }
        }
    }
}
