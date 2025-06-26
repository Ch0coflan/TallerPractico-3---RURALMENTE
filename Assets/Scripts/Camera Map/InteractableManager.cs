using Camera_Map;
using UnityEngine;

public static class InteractableManager
{
    public static InteractableObject CurrentActive;

    public static void SetActiveObject(InteractableObject obj)
    {
        if (CurrentActive != null && CurrentActive != obj)
        {
            CurrentActive.HideCanvas(); 
        }

        CurrentActive = obj;
    }

    public static void ClearActive()
    {
        if (CurrentActive != null)
        {
            CurrentActive.HideCanvas();
            CurrentActive = null;
        }
    }
}
