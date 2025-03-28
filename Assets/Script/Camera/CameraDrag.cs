using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public Camera cam;  
    private Vector2 touchStartPos;  
    private Vector3 lastCameraPos;  

    
    public float minX = -50f, maxX = 50f, minZ = -50f, maxZ = 50f;
    public float smoothSpeed = 5f;  

    private void Start()
    {
        lastCameraPos = cam.transform.position;  
    }

    private void Update()
    {
        
        if (Input.touchCount == 1)
        {
            
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchStartPos = Input.GetTouch(0).position; 
            }

            
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = Input.GetTouch(0).position - touchStartPos;  

                
                Vector3 newCameraPos = GetWorldPosFromTouch(Input.GetTouch(0).position);

                
                Vector3 cameraMove = new Vector3(touchDelta.x, 0, touchDelta.y) * 0.01f;  

                
                Vector3 newCameraPosition = new Vector3(lastCameraPos.x - cameraMove.x, lastCameraPos.y, lastCameraPos.z - cameraMove.z);

                
                newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);
                newCameraPosition.z = Mathf.Clamp(newCameraPosition.z, minZ, maxZ);

                
                cam.transform.position = Vector3.Lerp(cam.transform.position, newCameraPosition, smoothSpeed * Time.deltaTime);

                
                touchStartPos = Input.GetTouch(0).position;
            }
        }
    }

    
    private Vector3 GetWorldPosFromTouch(Vector2 touchPosition)
    {
        Ray ray = cam.ScreenPointToRay(touchPosition); 
        Plane plane = new Plane(Vector3.up, Vector3.zero);  

        float distance;
        if (plane.Raycast(ray, out distance))  
        {
            return ray.GetPoint(distance); 
        }
        return Vector3.zero;
    }
}
