﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);

    }

    void OnCollisionEnter2D(Collision2D player)

    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");

        }

    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(uiObject);

    }
}
