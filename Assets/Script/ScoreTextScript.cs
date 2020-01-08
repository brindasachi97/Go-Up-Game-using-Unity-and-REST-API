using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public Text scoreUI;
    private Score score = new Score();

    // Start is called before the first frame update
    void Start()
    {
        score.localScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + (score.localScore + score.GetScore());
    }
}
