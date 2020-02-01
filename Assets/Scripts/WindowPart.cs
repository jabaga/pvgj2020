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
    
    private SpringJoint2D joint;
    private Rigidbody2D body;
    private Collider2D collider;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Button button;

    private bool isP1;
    
    void Start()
    {
        joint = GetComponent<SpringJoint2D>();
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
            if (manager.CheckPair(gameObject, other.attachedRigidbody.gameObject))
            {
                joint.enabled = true;
                StartCoroutine(PairPartsCoroutine(gameObject, other.attachedRigidbody.gameObject));
            }
        }
    }

    IEnumerator PairPartsCoroutine(GameObject go1, GameObject go2)
    {
        yield return new WaitForSeconds(0.5f);
        
        manager.p1MovingObj = null;
        manager.p2MovingObj = null;
        
        Destroy(go1.GetComponent<Button>());
        Destroy(go2.GetComponent<Button>());
        
        Destroy(go1.GetComponent<Collider2D>());
        Destroy(go2.GetComponent<Collider2D>());
        
        go1.transform.SetParent(manager.backHolder.transform);
        go2.transform.SetParent(manager.backHolder.transform);

        go1.GetComponent<TargetJoint2D>().enabled = true;
        go2.GetComponent<TargetJoint2D>().enabled = true;
        
        manager.ActivateP1Select();
    }

    public void Select()
    {
        canMove = true;
        transform.localScale = originalScale * 2f;
        collider.isTrigger = false;
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
        if(button != null)
            button.enabled = true;
    }
    public void Deactivate()
    {
        if(button != null)
            button.enabled = false;
    }
    
}
