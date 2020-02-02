using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LlamaSpit : MonoBehaviour
{
    public GameObject impactPrefab;
    
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Window")
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        
            ManagerFarm.Instance.StartCoroutine(ManagerFarm.Instance.LoadRepairScene());
        }
        Destroy(gameObject);
    }
}
