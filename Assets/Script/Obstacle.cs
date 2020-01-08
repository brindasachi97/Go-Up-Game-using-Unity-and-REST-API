using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Player Movement Variables/....
    public static float movespeed = 0.25f;
    public Vector2 userDirection;
    public GameObject Player;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }
    void Update()

    {
        userDirection= Vector2.left;
        transform.Translate(userDirection * movespeed * Time.deltaTime);

    }

  
}