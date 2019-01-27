using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBubble : MonoBehaviour
{
    public GameObject BubbleBoom;
    private void OnDestroy()
    {
        Instantiate(BubbleBoom, transform.position + new Vector3(0,0,-1), Quaternion.identity);
    }
}
