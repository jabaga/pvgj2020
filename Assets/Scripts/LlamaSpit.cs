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

    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if collided with window
        // - play impact particles
        // - play SFX
        // - load RepairScene via ManagerFarm
        
        // check if collided with Llama
        // - play impact particles
        // - play SFX
        // - update UI via UI Score
        
    }
}
