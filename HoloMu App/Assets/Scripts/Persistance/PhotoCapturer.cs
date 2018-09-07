using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.WSA.WebCam;
using Vuforia;

namespace HoloMu.Persistance
{
    /// <summary>
    /// Class for making pictures in order to upload them to our REST API.
    /// Based on this tutorial: https://docs.microsoft.com/de-de/windows/mixed-reality/locatable-camera-in-unity
    /// </summary>
    public class PhotoCapturer : MonoBehaviour
    {
        /// <summary>
        /// Gets triggered when photo capture process is done. If this was not successful, <code>file</code> is null.
        /// </summary>
        public event PhotoCaptureHandler PhotoTaken;
        /// <summary>
        /// Gets triggered when something during the process of photo making and saving goes wrong.
        /// </summary>
        public event ErrorHandler ErrorOccured;

        /// <summary>
        /// Check this, if the taken image should not get deleted.
        /// </summary>
        public bool KeepImage = true;

        private PhotoCapture _photoCapture = null;
        private string _filePath = "";
        private int _instanceID;

        /// <summary>
        /// Takes a picture of current view. Overwrite PhotoTaken event in order to get image as byte array.
        /// ATTENTION: If you use unity to run directly, this will take a picture using your webcam.
        /// </summary>
        public void TakePicture(int instanceID)
        {
            _instanceID = instanceID;
            VuforiaBehaviour.Instance.enabled = false;
            // GameObject.Find("ARCamera").SetActive(false);
            PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
        }

        private void OnPhotoCaptureCreated(PhotoCapture captureObject)
        {
            _photoCapture = captureObject;

            Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

            CameraParameters c = new CameraParameters
            {
                hologramOpacity = 0.0f,
                cameraResolutionWidth = cameraResolution.width,
                cameraResolutionHeight = cameraResolution.height,
                pixelFormat = CapturePixelFormat.BGRA32
            };

            try
            {
                captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
            }
            catch(Exception e)
            {
                // Console.Write(e.Message);
                Debug.Log(e.Message);
            }
        }

        private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
        {
            if (result.success)
            {
                string filename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
                _filePath = Path.Combine(Application.persistentDataPath, filename);

                _photoCapture.TakePhotoAsync(_filePath, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
            }
            else
            {
                if (this.ErrorOccured != null)
                {
                    this.ErrorOccured.Invoke(this, new Error(ErrorType.PhotoCapture, "Unable to start photo mode!"));
                }
            }
        }

        private void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result)
        {
            byte[] imgAsBytes = null;

            if (result.success)
            {
                imgAsBytes = File.ReadAllBytes(_filePath);
                _photoCapture.StopPhotoModeAsync(OnStoppedPhotoMode);
            }
            else
            {
                if (this.ErrorOccured != null)
                {
                    this.ErrorOccured.Invoke(this, new Error(ErrorType.PhotoCapture, "Failed to save Photo to disk!"));
                }
            }

            if (this.PhotoTaken != null)
            {
                this.PhotoTaken.Invoke(this, _instanceID, imgAsBytes);
            }
        }

        private void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
        {
            VuforiaBehaviour.Instance.enabled = true;
            // GameObject.Find("ARCamera").SetActive(true);

            _photoCapture.Dispose();
            _photoCapture = null;
            //if (!this.KeepImage)
            //{
            //    File.Delete(_filePath);
            //}
            _filePath = "";
        }
    }
}
