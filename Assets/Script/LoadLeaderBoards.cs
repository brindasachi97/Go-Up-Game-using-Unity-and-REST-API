using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;
using System.IO;

public class LoadLeaderBoards : MonoBehaviour
{
    public Text firstPlace;
    public Text secondPlace;
    public Text thirdPlace;

    public Text firstValue;
    public Text secondValue;
    public Text thirdValue;

    //private LeaderBoardData data;
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://go-up-api.herokuapp.com/scores"));

        firstPlace.text = "Hello!";

        //path = Path.Combine(Application.persistentDataPath, "saved files", "data.json");

        /*
        string loadJson = File.ReadAllText(path);
        data = JsonUtility.FromJson<LeaderBoardData>(loadJson);

        firstPlace.text = data.name[0];
        secondPlace.text = data.name[1];
        thirdPlace.text = data.name[2];

        firstValue.text = data.score[0].ToString();
        secondValue.text = data.score[1].ToString();
        thirdValue.text = data.score[2].ToString();
        */
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                string jSoN = "{\"items\": " + webRequest.downloadHandler.text + "}";
                //Debug.Log("{\"items\": " + webRequest.downloadHandler.text + "}");

                //string test = "{\"name\": \"ace\", \"score\": \"50000\", \"aaa\":\"400\"}";
                ScoreList jsonObj = JsonUtility.FromJson<ScoreList>(jSoN);
                //Debug.Log(jsonObj.items[0].name);

                /*
                foreach (ScoreBoardData sbd in jsonObj.items)
                {
                    Debug.Log(sbd.name);
                }

                Debug.Log("AAA");
                */

                IOrderedEnumerable<ScoreBoardData> orderedEnumerable = jsonObj.items.OrderByDescending(x => int.Parse(x.score));

                foreach(ScoreBoardData sbd in orderedEnumerable)
                {
                    Debug.Log(sbd.name);
                }

                List<ScoreBoardData> leaderboards = orderedEnumerable.ToList();

                firstPlace.text = leaderboards[0].name;
                firstValue.text = leaderboards[0].score;

                secondPlace.text = leaderboards[1].name;
                secondValue.text = leaderboards[1].score;

                thirdPlace.text = leaderboards[2].name;
                thirdValue.text = leaderboards[2].score;

            }
     
        }
    }
}

[System.Serializable]
public class ScoreBoardData
{
    public string name;
    public string score;
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreBoardData> items;
}

/*
[System.Serializable]
public class LeaderBoardData
{
    public string[] name;
    public int[] score;

    public LeaderBoardData(string[] name, int[] score)
    {
        this.name = name;
        this.score = score;
    }
}



using UnityEngine;
 using System.IO;
 
 public class JsonFileWriter : MonoBehaviour
{
    public JsonData data;

    public string path;

    public void Start()
    {
        data = new JsonData(1, "Alfred Jodl");

        path = Path.Combine(Application.persistantDataPath, "saved files", "data.json");
        SerializeData();
        DeserializeData();
    }

    public void SerializeData()
    {
        string jsonDataString = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, jsonDataString);

        Debug.Log(jsonDataString);
    }

    public void DeserializeData()
    {
        string loadedJsonDataString = File.ReadAllText(path);

        data = JsonUtility.FromJson<JsonData>(loadedJsonDataString);

        Debug.Log("id: " + data.id.ToString() + " | name: " + data.name)
     }
}

[Serializeable]
public class JsonData
{
    public int id;
    public string name;

    public JsonData(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public JsonData() { }
}
*/
