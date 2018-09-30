using HoloToolkit.Unity;
using UnityEngine;

namespace HoloMu.UI
{
    public class FaceTarget : SimpleTagalong
    {
        public Transform Target = null;
        public bool FlippedYAxis = true;

        protected override void Update()
        {
            base.Update();
            transform.LookAt(this.Target);
            if (this.FlippedYAxis)
                transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
