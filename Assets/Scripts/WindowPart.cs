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
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject && canMove == true)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
                body.AddForce(new Vector2(-1f * manager.moveSpeed, 0));
            if(Input.GetKey(KeyCode.RightArrow))
                body.AddForce(new Vector2(1f * manager.moveSpeed, 0));
                
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
        button.enabled = true;
        transform.localScale = originalScale * 2f;
        collider.isTrigger = false;
    }
    public void Deselect()
    {
        canMove = false;
        button.enabled = false;
        transform.position = originalPosition;
        transform.localScale = originalScale;
        collider.isTrigger = true;
    }
    
}
