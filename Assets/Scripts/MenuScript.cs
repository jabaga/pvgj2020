using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            this.PlayGame();
        }

        if (Input.GetButtonDown("End"))
        {
            this.QuitGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Farm Scene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
