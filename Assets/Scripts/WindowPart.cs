using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowPart : MonoBehaviour
{
    public ManagerRepair manager;
    public bool canMove = false;
    
    private Joint2D joint;
    private Rigidbody2D body;
    private Collider2D collider;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Button button;

    private bool isP1;
    
    void Start()
    {
        joint = GetComponent<Joint2D>();
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        button = GetComponent<Button>();
        originalPosition = transform.position;
        originalScale = transform.localScale;

        if (joint != null)
            joint.enabled = false;
        
        collider.isTrigger = true;

        isP1 = false;
        foreach (var g in manager.windowPairs1)
        {
            if (g == gameObject)
            {
                isP1 = true;
                break;
            }
        }
    }

    void Update()
    {
        if ((manager.p1MovingObj == gameObject || manager.p2MovingObj == gameObject) && canMove == true)
        {
            string playerPrefix = "P1";
            if (isP1 == false)
                playerPrefix = "P2";
            
            body.AddForce(new Vector2(Input.GetAxisRaw(playerPrefix+"Horizontal") * manager.moveSpeed, Input.GetAxisRaw(playerPrefix+"Vertical") * manager.moveSpeed));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canMove == false)
            return;
        
        if (joint != null)
        {
            for (int i = 0; i < manager.windowPairs1.Count; i++)
            {
                if (manager.windowPairs1[i] == gameObject && manager.windowPairs2[i] == other.gameObject && other.gameObject.GetComponent<WindowPart>().canMove == true)
                {
                    joint.enabled = true;
                }
            }
        }
    }

    public void Select()
    {
        canMove = true;
        transform.localScale = originalScale * 2f;
        collider.isTrigger = false;
        print("selected "+ gameObject.name);
        //Activate();
        if (isP1 == true)
            manager.p1MovingObj = gameObject;
        else
            manager.p2MovingObj = gameObject;
    }
    
    public void Deselect()
    {
        canMove = false;
        transform.position = originalPosition;
        transform.localScale = originalScale;
        collider.isTrigger = true;
        if (isP1 == true)
            manager.p1MovingObj = null;
        else
            manager.p2MovingObj = null;
        Deactivate();
    }

    public void Activate()
    {
        button.enabled = true;
    }
    public void Deactivate()
    {
        button.enabled = false;
    }
    
}
