using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class ScoreViewer : MonoBehaviour
{

    [SerializeField] private Text[] ranks;
 

    [SerializeField] private InputField inputText;
    [SerializeField] private Button enterButton;
    [SerializeField] private Button exitButton;

    public string Name;
    public int score;

    private void Start()
    {
        inputText.gameObject.SetActive(true);

        inputText.onEndEdit.AddListener((s) => { TextInput(); });

        enterButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            ranks[i].gameObject.SetActive(false);
        }
    }


    public void TextInput()
    {
        Name = inputText.text;
        score = 100;
        if(string.IsNullOrEmpty(Name))
        {
            Debug.Log("Return");
            return;
        }

        string path = Application.persistentDataPath + "/score.json";

        if(!File.Exists(path))
        {
            string initJson = JsonConvert.SerializeObject(new UserScores(){ Users = new List<User>() }, Formatting.Indented);
            File.WriteAllText(path, initJson);
        }

        var loadJson = File.ReadAllText(path);
        var users1 = JsonConvert.DeserializeObject<UserScores>(loadJson);
        users1.Users.Add(new User() { Name = Name, Score = score });

        users1.Users = users1.Users.OrderByDescending(p => p.Score).Take(5).ToList();
        string json = JsonConvert.SerializeObject(users1,Formatting.Indented);
        File.WriteAllText(path, json);
        //출력

        var printUsers = JsonConvert.DeserializeObject<UserScores>(File.ReadAllText(path));

        for (int i = 0; i < printUsers.Users.Count; i++)
        {
            Debug.Log(printUsers.Users[i].Name + "," + printUsers.Users[i].Score);
        }

        inputText.gameObject.SetActive(false);
        enterButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);

        exitButton.onClick.AddListener(() => { SceneManager.LoadSceneAsync("Title");  });

        for (int i = 0; i < printUsers.Users.Count && i < 5; i++)
        {
            ranks[i].gameObject.SetActive(true);
            ranks[i].text = (i + 1) + "등  유저이름 : " + printUsers.Users[i].Name + "\t\t 점수 : " + printUsers.Users[i].Score;
        }
    }
}

public class UserScores
{
    public List<User> Users = new List<User>();
}
public class User
{
    public string Name { get; set; }
    public int Score { get; set; }
}
