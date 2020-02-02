using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerFarm : Singleton<ManagerFarm>
{
    public AudioSource windowBreakSound;
    public GameObject windowBreakParticle;
    public AudioSource[] audio;

    public IEnumerator LoadRepairScene()
    {
        windowBreakSound.Play();
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Repair Scene", LoadSceneMode.Single);
    }
}
