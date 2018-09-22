using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoloMu.UI
{
    public class MainUIManager : MonoBehaviour
    {
        public GameObject MessageBoxPrefab;
        public Transform MessageBoxTarget;
        public List<string> ShowMessageBoxScenes = new List<string>();

        private GameObject _msgBox;

        public void ShowMessage(string header, string message)
        {
            //if (MessageBoxAllowed() == false)
            //    return;

            if (_msgBox == null)
            {
                _msgBox = Instantiate(MessageBoxPrefab);
            }
            _msgBox.GetComponent<MessageBox>().Show(header, message);
            _msgBox.GetComponent<FaceTarget>().Target = this.MessageBoxTarget;
        }

        bool MessageBoxAllowed()
        {
            foreach(string scenename in ShowMessageBoxScenes)
            {
                if (SceneManager.GetActiveScene().name.Equals(scenename))
                    return true;
            }
            return false;
        }
    }
}
