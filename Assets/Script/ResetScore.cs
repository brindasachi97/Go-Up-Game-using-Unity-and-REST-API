using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    protected Score score = new Score();

    void Start()
    {
        score.SetScore(0);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
