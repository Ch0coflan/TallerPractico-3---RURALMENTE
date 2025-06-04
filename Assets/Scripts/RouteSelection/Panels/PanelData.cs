using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Panel", menuName = "Story/PanelData")]
public class PanelData : ScriptableObject
{ 
    public string text;  
    public List<PanelOption> options;
    public Sprite firstBG;
    public Sprite firstCharacter;
    public bool isEndPanel;
    public string charAnim;
    public AudioClip charSound;
}

[System.Serializable]
public class PanelOption
{
    public string optionText;
    public bool isGoodDecision;
    public int nextPanelIndex;
    public Sprite BG;
    public Sprite Character;
}



