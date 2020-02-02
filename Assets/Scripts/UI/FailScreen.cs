using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    public float time = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MainMenu", time);
    }

    void MainMenu()
    {
            SceneManager.LoadScene("Menu Scene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
