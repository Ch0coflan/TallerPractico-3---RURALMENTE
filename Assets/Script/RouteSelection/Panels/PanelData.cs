using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Panel", menuName = "Story/PanelData")]
public class PanelData : ScriptableObject
{
    public string text;  
    public List<PanelOption> options;  
}

[System.Serializable]
public class PanelOption
{
    public string optionText;  
    public int nextPanelIndex;  
    public bool isGoodEnding;
    public Sprite BG;
    public Sprite Character;
}



