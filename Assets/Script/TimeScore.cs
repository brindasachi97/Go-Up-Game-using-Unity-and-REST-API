using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public Text timeUI;
    private Score time = new Score();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
        time.SetLocalTime(300);
    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = "Time: " + time.GetLocalTime().ToString();
    }

    IEnumerator waiter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            time.DecrementLocalTime();
        }
    }
}
