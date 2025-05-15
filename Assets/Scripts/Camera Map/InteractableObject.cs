using System;
using System.Collections;
using Camera_Map;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Scenes.Script
{
    public class InteractableObject : MonoBehaviour
    {
         public GameObject canvas;
         public CameraController zoomController;
         private bool _isActive = false;
         public Transform cameraFollowTarget; 
         public Transform actualFollowTarget; 
         public float focusSpeed = 5f;
         private Transform _camTarget;
         public Animator anim;
         [SerializeField] private bool isFocusing = false;
         [SerializeField] private AnimationActive animationActive;
         public CinemachineCamera cinemachineCamera;
         public CinemachineCamera cameraHouse;


         

         private void Update()
         {
             if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
             {
                 Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                 if (Physics.Raycast(ray, out RaycastHit hit))
                 {
                     if (hit.collider.CompareTag("Interactable"))
                     {
                         zoomController.ToggleZoom();
                     }
                     else if (hit.collider.CompareTag("Casa"))
                    {
                        cameraHouse.Priority = 20;
                        cinemachineCamera.Priority = 10;
                        animationActive.PlayAnimation();
                        cameraFollowTarget = hit.transform;
                        StartCoroutine(TransitionScene());
                        
                    }
                }
             }

             if (isFocusing && _camTarget != null)
             {
                 Vector3 targetPos = transform.position;
                 targetPos.y = _camTarget.position.y; 
                 _camTarget.position = Vector3.Lerp(_camTarget.position, targetPos, Time.deltaTime * focusSpeed);

                 if (Vector3.Distance(_camTarget.position, targetPos) < 0.1f)
                 {
                     isFocusing = false;
                 }
             }

             
         }

         public void ToggleCanvas()
        {
            _isActive = !_isActive;
            canvas.SetActive(_isActive);

            if (_isActive)
            {
                _camTarget = actualFollowTarget;
                isFocusing = true;
            }
        }

        public void HideCanvas()
        {
            _isActive = false;
            canvas.SetActive(false);
        }

        public bool IsActive()
        {
            return _isActive;
        }

        private void LoadScene(int sceneIndex)
        {
            Debug.Log($"Cargando escena {sceneIndex}...");
            SceneManager.LoadScene(sceneIndex);
        }

        public IEnumerator TransitionScene()
        {
            Debug.Log("Ejecutando corroutina");
            yield return new WaitForSeconds(8);
            anim.SetTrigger("Out");
            yield return new WaitForSeconds(2);
            LoadScene(2);

        }

        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}
