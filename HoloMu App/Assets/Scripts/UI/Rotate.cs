using UnityEngine;

namespace HoloMu.UI
{
    public class Rotate : MonoBehaviour
    {
        public bool Enabled { get; set; }

        public float RotationSpeed = 5.0f;

        private void Start()
        {
            Enabled = true;
        }

        private void Update ()
        {
            if (Enabled)
                transform.Rotate(Vector3.up * Time.deltaTime, this.RotationSpeed);	
	    }
    }
}
