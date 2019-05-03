using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int Total = 0;

    // Resets the Score
    public void ResetScore()
    {
        Total = 0;
    }

    // Targets Hit Gain 100 Points
    public void TakeHitTarget()
    {
        Total += 100;
    }

    // Function gets total accumulated
    public int GetTotal()
    {
        return Total;
    }
}
