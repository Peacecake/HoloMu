using HoloMu.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HoloMu.UI
{
    public class InfoPanelManager : MonoBehaviour
    {
        public GameObject InfoPanel;
        public Transform FaceingTarget;

        public event InfoPanelDestroyHandler InfoPanelDestroyed;

        private Dictionary<GameObject, GameObject> _infoPanels;

	    private void Start ()
        {
            _infoPanels = new Dictionary<GameObject, GameObject>();
            if (this.InfoPanel == null)
                Debug.LogError("Set Infopanel Prefab to InfopanelManager");
            if (this.FaceingTarget == null)
                this.FaceingTarget = GameObject.Find("MixedRealityCameraParent").transform;
        }

        public void Add(GameObject parent)
        {
            GameObject p = Instantiate(InfoPanel, parent.transform.position, Quaternion.identity);
            p.GetComponent<InfoPanel>().InfoPanelDestroy += OnInfoPanelDestroy;
            p.GetComponent<InfoPanel>().SetLoadingState(true);
            p.GetComponent<FaceTarget>().Target = this.FaceingTarget;
            p.transform.SetParent(transform);
            _infoPanels.Add(parent, p);
        }

        private void OnInfoPanelDestroy(object sender)
        {
            GameObject infoPanelObj = sender as GameObject;
            GameObject exampleObj = _infoPanels.FirstOrDefault(x => x.Value.Equals(infoPanelObj)).Key;
            if (exampleObj != null)
            {
                infoPanelObj.GetComponent<InfoPanel>().InfoPanelDestroy -= OnInfoPanelDestroy;
                exampleObj.GetComponent<TestScript>().SetEnabled(true);
                _infoPanels.Remove(exampleObj);
                this.InfoPanelDestroyed?.Invoke(this);
            }
        }

        public void SetExhibit(GameObject parent, SerializeableExhibit exhibit)
        {
            GameObject infoObj;
            if (_infoPanels.TryGetValue(parent, out infoObj))
            {
                infoObj.GetComponent<InfoPanel>().SetLoadingState(false);
                infoObj.GetComponent<InfoPanel>().Exhibit = exhibit;
            }
            else Debug.LogWarning("No exhibit found for this gameObject");
        }

        public void Close(int exhibitId)
        {
            foreach(KeyValuePair<GameObject, GameObject> kvp in _infoPanels)
            {
                InfoPanel ip = kvp.Value.GetComponent<InfoPanel>();
                if (ip.Exhibit.id == exhibitId)
                {
                    TestScript ts = kvp.Key.GetComponent<TestScript>();
                    ts.SetEnabled(true);
                    Destroy(kvp.Value);
                    _infoPanels.Remove(kvp.Key);
                }
            }
        }

        public void Remove(GameObject parent)
        {
            GameObject panelObj;
            if (_infoPanels.TryGetValue(parent, out panelObj))
            {
                _infoPanels.Remove(parent);
                Destroy(panelObj);
            }
        }
    }
}
