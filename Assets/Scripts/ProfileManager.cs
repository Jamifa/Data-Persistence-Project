using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    public string playerName;
    public int highScore;

    private void Awake() {
        if(instance != null) {
            Destroy (gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad (gameObject);
    }
    
    [System.Serializable]
    class PlayerProfile
    {
        public string name;
        public int highScore;
    }

    public void SaveProfile(string newPlayerName, int newHighScore) {
        playerName = newPlayerName;
        highScore = newHighScore;
        PlayerProfile profile = new PlayerProfile ();
        profile.name = playerName;
        profile.highScore = newHighScore;

        string json = JsonUtility.ToJson (profile);

        File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
    }

    public string LoadProfile() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists (path)) {
            string json = File.ReadAllText (path);
            PlayerProfile profile = JsonUtility.FromJson<PlayerProfile> (json);

            playerName = profile.name;
            highScore = profile.highScore;
            return playerName;
        } else {
            return "";
        }
    }
}
