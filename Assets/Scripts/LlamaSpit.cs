using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LlamaSpit : MonoBehaviour
{
    public AudioSource[] audio;
    
    void Start()
    {
        int rand = Random.Range(0, audio.Length);
        audio[rand].Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bullet Hit Player");
        }
        else if (collision.gameObject.tag == "Window")
        {
            ManagerFarm.Instance.StartCoroutine(ManagerFarm.Instance.LoadRepairScene());
        }
        Destroy(gameObject);
    }
}
