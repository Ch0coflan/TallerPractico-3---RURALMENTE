using UnityEngine;

namespace Scenes.Script
{
    public class CameraDragController : MonoBehaviour
    {
        public Transform cameraTarget;
        private Vector2 _previousInputPos;
        private bool _isDragging = false;

        public float smoothSpeed = 10f;
        public float dragSpeed = 0.01f;

        private Vector3 _currentVelocity;

        private void Update()
        {
            Vector2 inputDelta = Vector2.zero;

            //Touch
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _previousInputPos = touch.position;
                    _isDragging = true;
                }
                else if (touch.phase == TouchPhase.Moved && _isDragging)
                {
                    inputDelta = touch.position - _previousInputPos;
                    _previousInputPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _isDragging = false;
                }
            }
            //PC
            else if (Input.GetMouseButtonDown(0))
            {
                _previousInputPos = Input.mousePosition;
                _isDragging = true;
            }
            else if (Input.GetMouseButton(0) && _isDragging)
            {
                inputDelta = (Vector2)Input.mousePosition - _previousInputPos;
                _previousInputPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
            }

            // Movimiento
            if (inputDelta != Vector2.zero)
            {
                Vector3 move = new Vector3(-inputDelta.x * dragSpeed, 0, -inputDelta.y * dragSpeed);
                Vector3 targetPosition = cameraTarget.position + move;
                cameraTarget.position = Vector3.SmoothDamp(cameraTarget.position, targetPosition, ref _currentVelocity,
                    1f / smoothSpeed);
            }
        }
    }
}
