using UnityEngine;
using UnityEngine.UI;

namespace HoloMu.UI
{
    public class MessageBox : MonoBehaviour
    {
        public Text HeaderText;
        public Text MessageText;

	    void Start ()
        {
            FaceTarget faceTarget = GetComponent<FaceTarget>();
            faceTarget.Target = GameObject.FindGameObjectWithTag("MainCamera").transform;
	    }

        public void Show(string headerText, string message)
        {
            gameObject.SetActive(true);
            this.HeaderText.text = headerText;
            this.MessageText.text = message;
        }
    }
}
