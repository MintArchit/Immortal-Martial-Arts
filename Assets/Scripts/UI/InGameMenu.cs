using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public void OnLogoutBtn()
    {
        Debug.Log("Back to Lobby");
        SceneManager.LoadScene("Lobby");
    }
}
