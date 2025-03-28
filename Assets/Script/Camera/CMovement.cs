using UnityEngine;

public class CMovement : MonoBehaviour
{
    public GameObject cam;
    private Vector2 StartPos;
    private Vector2 DragStartPos;
    private Vector2 DragNewPos;
    private Vector2 Finger0Pos;
    private float DistanceBetweenFingers;
    private bool isZooming;

    private void Awake()
    {
        cam = this.gameObject;
        cam.transform.rotation = Quaternion.Euler(90f,0f,0f);
    }
    private void Update()
    {
        if (Input.touchCount == 0 && isZooming)
        {
            isZooming = false;
        }
        if (Input.touchCount == 1)
        {
            if (!isZooming)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPos = GetWorldPos();
                    Vector3 PosDifference = NewPos - StartPos;
                    cam.transform.Translate(PosDifference.x, 0, PosDifference.z);
                }
                StartPos = GetWorldPos();
            }
        }
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                isZooming = true;
                DragNewPos = GetWorldPosFinger(1);
                Vector2 PosDifference = DragNewPos - DragStartPos;
                if (Vector2.Distance(DragNewPos, Finger0Pos) < DistanceBetweenFingers)
                {
                    cam.GetComponent<Camera>().orthographicSize += (PosDifference.magnitude);
                }
                if (Vector2.Distance(DragNewPos, Finger0Pos) >= DistanceBetweenFingers)
                {
                    cam.GetComponent<Camera>().orthographicSize -= (PosDifference.magnitude);
                }
                DistanceBetweenFingers = Vector2.Distance(DragNewPos, Finger0Pos);
            }
            DragStartPos = GetWorldPosFinger(1);
            Finger0Pos = GetWorldPosFinger(0);
        }
    }

    private Vector3 GetWorldPos()
    {
        return cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 GetWorldPosFinger(int index)
    {
        return cam.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(index).position);
    }
}
