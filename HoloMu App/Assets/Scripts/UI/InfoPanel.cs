using HoloMu.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloMu.UI
{
    public class InfoPanel : MonoBehaviour
    {
        public Exhibit Exhibit
        {
            get
            {
                return _exhibit;
            }
            set
            {
                _exhibit = value;
                OnExhibitSet();
            }
        }

        public Button ShowInfoButtonPrefab;
        public Text TitleText;
        public Text MainText;
        public GameObject ButtonContainer;
        public GameObject Canvas;
        public GameObject Preloader;
        

        private Exhibit _exhibit;

        private void OnExhibitSet()
        {
            if (_exhibit != null)
            {
                TitleText.text = _exhibit.Name;
                MainText.text = _exhibit.Description;

                int index = 0;
                foreach(KeyValuePair<string, string> info in _exhibit.AdditionalInformation)
                {
                    AddButtons(info.Key, index);
                    index++;
                }
            }
        }

        public void SetLoadingState(bool isLoading)
        {
            Preloader.SetActive(isLoading);
            Canvas.SetActive(!isLoading);
        }

        /// <summary>
        /// Adds an instance of <code>ShowInfoButtonPrefab</code> to the <code>ButtonContainer</code>
        /// </summary>
        /// <param name="buttonText"></param>
        /// <param name="index"></param>
        private void AddButtons(string buttonText, int index)
        {
            // Calculate button properties
            float height = ButtonContainer.GetComponent<RectTransform>().rect.height;
            float width = ButtonContainer.GetComponent<RectTransform>().rect.width / _exhibit.AdditionalInformation.Count;
            Vector3 localScale = Vector3.one;
            Vector2 anchorPoints = Vector2.up;
            Vector3 position = new Vector3(index * width, 0, 0);

            Button btn = Instantiate(ShowInfoButtonPrefab);
            btn.transform.parent = ButtonContainer.transform;

            // Configure button
            btn.GetComponentInChildren<Text>().text = buttonText;
            btn.onClick.AddListener(delegate { OnButtonClick(btn); });
            btn.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            btn.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            btn.GetComponent<RectTransform>().localScale = localScale;
            btn.GetComponent<RectTransform>().anchorMin = anchorPoints;
            btn.GetComponent<RectTransform>().anchorMax = anchorPoints;
            btn.GetComponent<RectTransform>().pivot = anchorPoints;
            btn.GetComponent<RectTransform>().anchoredPosition3D = position;
        }

        /// <summary>
        /// Callback that handle click on additional info button. Gets text from AdditionalInformation Dictionary by button text.
        /// </summary>
        /// <param name="btn"></param>
        public void OnButtonClick(Button btn)
        {
            string value = "";
            bool success = _exhibit.AdditionalInformation.TryGetValue(btn.GetComponentInChildren<Text>().text, out value);
            if (success)
            {
                MainText.text = value;
            } 
            else
            {
                MainText.text = _exhibit.Description;
            }
        }
    }
}
