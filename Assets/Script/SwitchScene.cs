using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void goToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void goToLeaderBoards()
    {
        SceneManager.LoadScene("LeaderBoards");
    }

    public void goToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
