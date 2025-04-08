using UnityEngine;

namespace Scenes.Script
{
    public class CameraDrag : MonoBehaviour
    {
        public Transform cameraTarget; 
        private Vector2 _previousTouchPos;
        private bool _isDragging = false;

        public float minX = -50f, maxX = 50f, minZ = -50f, maxZ = 50f;
        public float smoothSpeed = 10f; 
        public float dragSpeed = 0.01f; 

        private Vector3 _currentVelocity;

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

                    Vector3 move = new Vector3(-touchDelta.x * dragSpeed, 0, -touchDelta.y * dragSpeed);
                    Vector3 targetPos = cameraTarget.position + move;

                    
                    targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
                    targetPos.z = Mathf.Clamp(targetPos.z, minZ, maxZ);

                    
                    cameraTarget.position = Vector3.SmoothDamp(cameraTarget.position, targetPos, ref _currentVelocity, 1f / smoothSpeed);

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
