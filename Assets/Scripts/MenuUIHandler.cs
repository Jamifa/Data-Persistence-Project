using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameBox;
    [SerializeField] string playerName;
    public void ChangeName() {
        playerName = nameBox.text;
        ProfileManager.instance.SaveProfile (playerName, ProfileManager.instance.highScore);
    }

    public void StartGame() {
        SceneManager.LoadScene (1);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode ();
#else
        Application.Quit();
#endif
    }

    public void LoadProfile() {
        playerName = ProfileManager.instance.LoadProfile ();
        nameBox.text = playerName;
    }
}