using UnityEngine;

namespace HoloMu.UI
{
    public class Rotate : MonoBehaviour
    {
        public float RotationSpeed = 5.0f;

	    private void Update ()
        {
            transform.Rotate(Vector3.up * Time.deltaTime, this.RotationSpeed);	
	    }
    }
}
