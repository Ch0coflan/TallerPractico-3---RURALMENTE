using UnityEngine;

namespace Scenes.Script
{
    public class ObjectTouch : MonoBehaviour
    {
        public Camera cam;

        private InteractableObject _lastTouched;

        void Update()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector2 touchPos = Input.GetTouch(0).position;
                Ray ray = cam.ScreenPointToRay(touchPos);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    InteractableObject obj = hit.collider.GetComponent<InteractableObject>();
                    if (obj != null)
                    {
                        
                        if (_lastTouched != null && _lastTouched != obj && _lastTouched.IsActive())
                        {
                            _lastTouched.HideCanvas();
                        }

                        obj.ToggleCanvas();
                        _lastTouched = obj;
                    }
                }
            }
        }
        

       
    }
}
