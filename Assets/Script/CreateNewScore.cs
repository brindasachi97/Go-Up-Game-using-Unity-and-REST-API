using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CreateNewScore : MonoBehaviour
{
    public string url;
    public Text inputUI;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = new Score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create_user()
    {
        string json = "{\"name\": \"" + inputUI.text +
            "\", \"score\": \"" + score.GetScore().ToString() + "\"}";

        //string json = "{\"name\": \"Biggie\", \"score\": \"400\"}";

        StartCoroutine(SendPost(json));
    }

    IEnumerator SendPost(string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, "POST"))
        {
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(Encoding.ASCII.GetBytes(json));
            request.SetRequestHeader("Content-Type", "application/json");


            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log("ERROR");
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("POST SUCCESSFUL!");
            }
        }
    }
}
