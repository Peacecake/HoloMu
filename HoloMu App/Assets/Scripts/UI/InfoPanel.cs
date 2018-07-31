using HoloMu.Networking;
using System.Collections;
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

        public Text TitleText;
        public Text MainText;
        public GameObject ButtonContainer;
        public Button[] Buttons;

        private Exhibit _exhibit;
        private List<string> _additionalInfoTexts;

        private void OnExhibitSet()
        {
            _additionalInfoTexts = new List<string>();
            if (_exhibit != null)
            {
                TitleText.text = _exhibit.Name;
                MainText.text = _exhibit.Description;

                int index = 0;
                foreach(KeyValuePair<string, string> info in _exhibit.AdditionalInformation)
                {
                    Buttons[index].GetComponentInChildren<Text>().text = info.Key;
                    _additionalInfoTexts.Add(info.Value);
                    index++;
                }
            }
        }

        public void OnButtonClick(Button btn)
        {
            Debug.Log("CLICK BUTTON: " + btn.name);
            string value = "";
            bool success = _exhibit.AdditionalInformation.TryGetValue(btn.GetComponentInChildren<Text>().text, out value);
            if (success)
            {
                MainText.text = value;
            } 
            else
            {
                MainText.text = "Fehler";
            }
        }
    }
}
