using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    Score score = new Score();
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name=="Player")
        {
            score.AddScore(25);
            Destroy(this.gameObject);
        }
    }
}
