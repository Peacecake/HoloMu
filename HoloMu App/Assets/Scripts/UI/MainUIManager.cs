using UnityEngine;

namespace HoloMu.UI
{
    public class MainUIManager : MonoBehaviour
    {
        public GameObject MessageBoxPrefab;
        public Transform MessageBoxTarget;

        private GameObject _msgBox;

        public void ShowMessage(string header, string message)
        {
            if (_msgBox == null)
            {
                _msgBox = Instantiate(MessageBoxPrefab);
            }
            _msgBox.GetComponent<MessageBox>().Show(header, message);
            _msgBox.GetComponent<FaceTarget>().Target = this.MessageBoxTarget;
        }
    }
}
