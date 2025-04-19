
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    public Material mainMaterial;
    public Material outlineMaterial;

    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        ApplyMaterials();
    }

    public void ApplyMaterials()
    {
        if (rend != null)
        {
            rend.materials = new Material[] { mainMaterial, outlineMaterial };
        }
    }

    public void RemoveOutline()
    {
        if (rend != null)
        {
            rend.materials = new Material[] { mainMaterial };
        }
    }
}
