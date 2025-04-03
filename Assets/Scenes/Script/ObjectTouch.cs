using UnityEngine;

namespace Scenes.Script
{
    public class ObjectTouch : MonoBehaviour
    {
        public Camera cam;
        public GameObject infoPanel;  

        private void Start()
        {
            infoPanel.SetActive(false); 
        }

        private void Update()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CheckObjectTouch(Input.GetTouch(0).position);
            }
        }

        private void CheckObjectTouch(Vector2 touchPosition)
        {
            Ray ray = cam.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.CompareTag($"Interactable")) 
                {
                    ToggleInfoPanel();
                }
            }
        }

        private void ToggleInfoPanel()
        {
            infoPanel.SetActive(!infoPanel.activeSelf); 
        }
    }
}
