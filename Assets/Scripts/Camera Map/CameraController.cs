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

        public Transform cameraTarget; 
        public float followSpeed = 5f;

        private bool isZoomed = false;
        private float targetFOV;

        void Start()
        {
            if (cineCam == null)
            {
                Debug.LogError("CinemachineCamera no asignada!");
                return;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            targetFOV = normalFOV;
            cineCam.Lens.FieldOfView = normalFOV;
        }

        void Update()
        {
            
            cineCam.Lens.FieldOfView = Mathf.Lerp(cineCam.Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

           
            if (cameraTarget != null)
            {
                transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * followSpeed);
            }

            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ToggleZoom();
            }
        }

        public void ToggleZoom()
        {
            isZoomed = !isZoomed;
            targetFOV = isZoomed ? zoomFOV : normalFOV;

            if (!isZoomed)
                cameraTarget = null; 
        }

        public void ZoomIn(Transform target)
        {
            isZoomed = true;
            targetFOV = zoomFOV;
            cameraTarget = target;
        }

        public void ZoomOut()
        {
            isZoomed = false;
            targetFOV = normalFOV;
            cameraTarget = null;
        }
    }
}