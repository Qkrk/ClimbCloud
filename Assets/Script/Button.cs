using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
