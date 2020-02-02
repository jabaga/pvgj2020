using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerFarm : Singleton<ManagerFarm>
{
    public IEnumerator LoadRepairScene()
    {
        // SFX
        // PARTICLE
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Repair Scene", LoadSceneMode.Single);
    }
}
