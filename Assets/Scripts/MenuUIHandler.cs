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

    private void Start() {
        ProfileManager.instance.playerNameInputField = nameBox;
        nameBox.text = ProfileManager.instance.playerName;
    }

    public void ChangeName() {
        playerName = nameBox.text;
        ProfileManager.instance.playerName = playerName;
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
}