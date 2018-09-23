using HoloMu.Networking;
using System.Collections.Generic;
using UnityEngine;

namespace HoloMu.UI
{
    public class InfoPanelManager : MonoBehaviour
    {
        public GameObject InfoPanel;
        public Transform FaceingTarget;

        public event InfoPanelDestroyHandler InfoPanelDestroyed;

        private Dictionary<int, GameObject> _panels;
        private Dictionary<int, InfoIcon> _icons;

        private const int DEFAULT_KEY = -1;

	    private void Start ()
        {
            _panels = new Dictionary<int, GameObject>();
            _icons = new Dictionary<int, InfoIcon>();
            if (this.InfoPanel == null) Debug.LogError("Set Infopanel Prefab to InfopanelManager");
        }

        public void Add(InfoIcon icon)
        {
            GameObject p = Instantiate(this.InfoPanel, icon.transform.position, Quaternion.identity);
            p.GetComponent<InfoPanel>().InfoPanelDestroy += OnInfoPanelDestroy;
            p.GetComponent<InfoPanel>().SetLoadingState(true);
            p.GetComponent<FaceTarget>().Target = this.FaceingTarget;
            p.transform.SetParent(transform);
            _panels.Add(DEFAULT_KEY, p);
            _icons.Add(DEFAULT_KEY, icon);
        }

        private void OnInfoPanelDestroy(object sender)
        {
            GameObject infoPanelObj = sender as GameObject;
            InfoPanel ip = infoPanelObj.GetComponent<InfoPanel>();
            InfoIcon icon;
            if (_panels.TryGetValue(ip.Exhibit.id, out infoPanelObj) && _icons.TryGetValue(ip.Exhibit.id, out icon))
            {
                ip.InfoPanelDestroy -= OnInfoPanelDestroy;
                icon.SetEnabled(true);
                _icons.Remove(ip.Exhibit.id);
                _panels.Remove(ip.Exhibit.id);
                this.InfoPanelDestroyed?.Invoke(this);
            }
        }

        public void SetExhibit(SerializeableExhibit exhibit)
        {
            GameObject infoObj;
            if (_panels.TryGetValue(DEFAULT_KEY, out infoObj))
            {
                infoObj.GetComponent<InfoPanel>().SetLoadingState(false);
                infoObj.GetComponent<InfoPanel>().Exhibit = exhibit;
                _panels.UpdateKey(DEFAULT_KEY, exhibit.id);
                _icons.UpdateKey(DEFAULT_KEY, exhibit.id);
            }
            else Debug.LogWarning("No exhibit found for this gameObject");
        }

        public void Remove(int exhibitId = DEFAULT_KEY)
        {
            GameObject panelObj;
            InfoIcon icon;
            if (_panels.TryGetValue(exhibitId, out panelObj) && _icons.TryGetValue(exhibitId, out icon))
            {
                _panels.Remove(exhibitId);
                _icons.Remove(exhibitId);
                icon.SetEnabled(true);
                Destroy(panelObj);
            }
        }
    }
}
