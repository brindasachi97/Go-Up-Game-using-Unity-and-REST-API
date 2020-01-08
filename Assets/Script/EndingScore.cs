using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScore : MonoBehaviour
{
    Score score = new Score();
    public Text endingScore;

    // Start is called before the first frame update
    void Start()
    {
        endingScore.text = "Your Score: " + score.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
