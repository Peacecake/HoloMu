using HoloMu.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace HoloMu.UI
{
    public class InfoPanel : MonoBehaviour
    {
        public event InfoPanelDestroyHandler InfoPanelDestroy;

        public SerializeableExhibit Exhibit
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
        public GameObject Preloader;
        public GameObject[] ActiveContentOnLoaded;
        public float DestroyDistance = 5f;
        

        private SerializeableExhibit _exhibit;
        private Vector3 _initialPlayerPosition;
        private GameController _controller;

        private void Awake()
        {
            _initialPlayerPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            _controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        private void OnDestroy()
        {
            if (this.InfoPanelDestroy != null)
                this.InfoPanelDestroy.Invoke(gameObject);
        }

        private void Update()
        {
            // Check if player has wolked away from info panel
            float currentDistance = GetPlayerDistanceFromInitialPosition();
            if (currentDistance > DestroyDistance)
            {
                _controller.HandleExhibitClose(_exhibit);
                Destroy(gameObject);
            }
        }

        private float GetPlayerDistanceFromInitialPosition()
        {
            Transform player = GameObject.FindGameObjectWithTag("MainCamera").transform;
            if (player == null)
                return 0;
            return Vector3.Distance(_initialPlayerPosition, player.position);
        }

        private void OnExhibitSet()
        {
            if (_exhibit != null)
            {
                TitleText.text = _exhibit.name;
                MainText.text = _exhibit.description;

                int index = 0;
                foreach(MoreInfo info in _exhibit.moreinfos)
                {
                    AddButtons(info.name, index);
                    index++;
                }
            }
        }

        public void Close()
        {
            Destroy(gameObject);
        }

        public void SetLoadingState(bool isLoading)
        {
            Preloader.SetActive(isLoading);
            foreach(GameObject obj in this.ActiveContentOnLoaded)
            {
                obj.SetActive(!isLoading);
            }
        }

        /// <summary>
        /// Adds an instance of <code>ShowInfoButtonPrefab</code> to the <code>ButtonContainer</code>
        /// </summary>
        /// <param name="buttonText"></param>
        /// <param name="index"></param>
        private void AddButtons(string buttonText, int index)
        {
            // Calculate button properties
            float maxHeight = ButtonContainer.GetComponent<RectTransform>().rect.height / 4;
            float height = ButtonContainer.GetComponent<RectTransform>().rect.height / _exhibit.moreinfos.Length;
            height = height > maxHeight ? maxHeight : height;
            float width = ButtonContainer.GetComponent<RectTransform>().rect.width;
            Vector3 localScale = Vector3.one;
            Vector2 anchorPoints = Vector2.up;
            Vector3 position = new Vector3(0, -index * height, 0);

            Button btn = Instantiate(ShowInfoButtonPrefab);
            btn.transform.SetParent(ButtonContainer.transform, false);

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
            bool success = GetButtonText(btn.GetComponentInChildren<Text>().text, out value);
            if (success)
                MainText.text = value;
            else
                MainText.text = _exhibit.description;
        }

        private bool GetButtonText(string key, out string value)
        {
            value = "";

            foreach(MoreInfo info in _exhibit.moreinfos)
            {
                if (info.name.Equals(key))
                {
                    if (info.datatype == "text")
                        value = info.text;
                    else
                    {
                        foreach(string point in info.data)
                        {
                            value += "- " + point + "\n";
                        }
                    }

                    return true;
                }
            }
            return false;
        }
    }
}
