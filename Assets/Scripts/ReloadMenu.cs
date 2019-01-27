using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadMenu : MonoBehaviour
{
    public ScoreHandler MyScore;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        MyScore.GameEnding();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }


}
