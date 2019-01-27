using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBubble : MonoBehaviour
{
    public GameObject BubbleBoom;
    public ScoreHandler MyScore;

    private void OnDestroy()
    {
        if(!MyScore.GameEnded)
           Instantiate(BubbleBoom, transform.position + new Vector3(0,0,-1), Quaternion.identity);
    }
}
