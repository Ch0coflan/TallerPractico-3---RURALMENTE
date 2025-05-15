using UnityEngine;

public class DecisionTracker : MonoBehaviour
{
    public static DecisionTracker Instance { get; private set; }
    public int goodDecisionsCount = 0;
    public int badDecisionsCount = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TrackDecision(bool isGoodDecision)
    {
        if (isGoodDecision)
        {
            goodDecisionsCount++;
        }
        else
        {
            badDecisionsCount++;
        }
    }

    public string GetDecisionSummary()
    {
        if(goodDecisionsCount > badDecisionsCount)
        {
            return "Final bueno";
        }
        else if(badDecisionsCount > goodDecisionsCount)
        {
            return "Final malo";
        }
        else
        {
            return "Final neutral";
        }
    }
    public void ResetDecisions()
    {
        goodDecisionsCount = 0;
        badDecisionsCount = 0;
    }
}
