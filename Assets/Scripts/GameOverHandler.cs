using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject GameOverScreen;
    private void OnDestroy()
    {
        GameOverScreen.SetActive(true);
    }
}
