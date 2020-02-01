using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaSpit : MonoBehaviour
{
    void Start()
    {
        // apply forces
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collided with window
        // - play impact particles
        // - play SFX
        // - load RepairScene via ManagerFarm

        // check if collided with Llama
        // - play impact particles
        // - play SFX
        // - update UI via UI Score
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
        else if (collision.gameObject.tag == "Window")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
        else
        {
            // Destroy(gameObject);
        }
    }
}
