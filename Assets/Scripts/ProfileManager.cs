using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    public string playerName;
    public int highScore;
    public string highScorePlayerName;

    public TMP_InputField playerNameInputField;

    private void Awake() {
        if(instance != null) {
            Destroy (gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad (gameObject);
        Debug.Log (Application.persistentDataPath);
        playerNameInputField.text = LoadProfile ();
    }
    
    [System.Serializable]
    class PlayerProfile
    {
        public string name;
        public int highScore;
    }

    public void SaveProfile(string newPlayerName, int newHighScore) {
        highScorePlayerName = newPlayerName;
        highScore = newHighScore;
        PlayerProfile profile = new PlayerProfile ();
        profile.name = highScorePlayerName;
        profile.highScore = newHighScore;

        string json = JsonUtility.ToJson (profile);

        File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
    }

    public string LoadProfile() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists (path)) {
            string json = File.ReadAllText (path);
            PlayerProfile profile = JsonUtility.FromJson<PlayerProfile> (json);

            highScorePlayerName = profile.name;
            highScore = profile.highScore;
            return highScorePlayerName;
        } else {
            return "";
        }
    }
}
