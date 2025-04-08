using System;
using UnityEngine;
using Unity.Cinemachine;

namespace Scenes.Script
{
    
    
    public class CameraController : MonoBehaviour
    {
        public CinemachineCamera cineCam;
        public float zoomFOV = 30f;
        public float normalFOV = 60f;
        public float zoomSpeed = 5f;

        private bool isZoomed = false;
        private float targetFOV;

        void Start()
        {
            if (cineCam == null)
            {
                Debug.LogError("CinemachineCamera no asignada!");
                return;
            }

            targetFOV = normalFOV;
            cineCam.Lens.FieldOfView = normalFOV;
        }

        void Update()
        {
           
            cineCam.Lens.FieldOfView = Mathf.Lerp(cineCam.Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ToggleZoom();
            }
        }

        public void ToggleZoom()
        {
            isZoomed = !isZoomed;
            targetFOV = isZoomed ? zoomFOV : normalFOV;
        }

        public void ZoomIn() => targetFOV = zoomFOV;
        public void ZoomOut() => targetFOV = normalFOV;
    }
}