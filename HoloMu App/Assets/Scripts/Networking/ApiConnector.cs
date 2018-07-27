using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace HoloMu.Networking
{
    public class ApiConnector : MonoBehaviour
    {
        public event ApiRequestResultHandler OnApiResult;

        private const string EXAMPLE_URL = "https://jsonplaceholder.typicode.com/posts/1";

        public void MakeTextRequest()
        {
            StartCoroutine(GetTextFrom(EXAMPLE_URL));
        }

        private IEnumerator GetTextFrom(string url)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    if (this.OnApiResult != null)
                    {
                        OnApiResult.Invoke(this, false, www.error);
                    }
                }
                else
                {
                    if (this.OnApiResult != null)
                    {
                        string xmlString = "<item id='2o8ru2309'><name>Comodore64</name><category>computer</category><year>1988</year><manufacturer>HansWurst</manufacturer><description>Ein kurze Beschreibung des Objekts</description><moreinfos><moreinfoitem type='Geschichte'>blablabla</moreinfoitem><moreinfoitem type='Technische Spezifikation'>blablabla</moreinfoitem></moreinfos></item>";
                        // OnApiResult.Invoke(this, true, www.downloadHandler.text);
                        OnApiResult.Invoke(this, true, xmlString);
                    }
                }
            }
        }
    }
}
