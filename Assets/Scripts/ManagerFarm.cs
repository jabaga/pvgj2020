using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerFarm : Singleton<ManagerFarm>
{
    void Start()
    {

    }

    public void LoadRepairScene()
    {
        SceneManager.LoadScene(2);
    }
}
