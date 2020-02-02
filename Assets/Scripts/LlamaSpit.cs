using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LlamaSpit : MonoBehaviour
{
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bullet Hit Player");
        }
        else if (collision.gameObject.tag == "Window")
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        
            ManagerFarm.Instance.StartCoroutine(ManagerFarm.Instance.LoadRepairScene());
        }
        Destroy(gameObject);
    }
}
