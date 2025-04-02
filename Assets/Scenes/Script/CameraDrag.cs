using UnityEngine;

namespace Scenes.Script
{
    public class CameraDrag : MonoBehaviour
    {
        public Camera cam;
        private Vector2 _previousTouchPos;
        private bool _isDragging = false;

        public float minX = -50f, maxX = 50f, minZ = -50f, maxZ = 50f;
        public float smoothSpeed = 10f; 
        public float dragSpeed = 0.01f; 

        private void Update()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _previousTouchPos = touch.position;
                    _isDragging = true;
                }
                else if (touch.phase == TouchPhase.Moved && _isDragging)
                {
                    Vector2 touchDelta = touch.position - _previousTouchPos;

                    Vector3 cameraMove = new Vector3(-touchDelta.x * dragSpeed, 0, -touchDelta.y * dragSpeed);

                    Vector3 targetPosition = cam.transform.position + cameraMove;

                    
                    targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
                    targetPosition.z = Mathf.Clamp(targetPosition.z, minZ, maxZ);

                   
                    cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, smoothSpeed * Time.deltaTime);

                    _previousTouchPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _isDragging = false;
                }
            }
        }
    }
}
