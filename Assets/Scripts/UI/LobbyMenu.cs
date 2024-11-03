using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMenu : MonoBehaviour
{
    public bool joinGame;

    public static LobbyMenu instance;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        instance = this;
    }

    public void OnJoinBtn()
    {
        Debug.Log("Joining");
        joinGame = true;
        SceneManager.LoadScene("InnerWorld");
    }

    public void OnQuitButton()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
