using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelswitch1 : MonoBehaviour
{
    public int index;
    public string levelName;
    private Score time = new Score();

    void Start()
    {

    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //load level with build index
            time.AddScore(time.GetLocalTime());
            time.SetLocalTime(300);

            SceneManager.LoadScene(index);

            //

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}