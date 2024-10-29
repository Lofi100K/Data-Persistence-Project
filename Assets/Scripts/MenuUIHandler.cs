using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputFieldTMP;
    public void StartGame()
    {
        DataManager.Instance.SetName(inputFieldTMP.text);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
