﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ManagerRepair : MonoBehaviour
{
    public List<GameObject> windowPairs1;
    public List<GameObject> windowPairs2;
    public float moveSpeed;
    public GameObject p1MovingObj;
    public GameObject p2MovingObj ;
    public GameObject backHolder;
    
    void Start()
    {
        foreach (var g in windowPairs1)
        {
            g.GetComponent<Button>().onClick.AddListener(WindowClicked);
        }
        foreach (var g in windowPairs2)
        {
            g.GetComponent<Button>().onClick.AddListener(WindowClicked);
        }

        ActivateP1Select();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var g in windowPairs1)
            {
                if(g.GetComponent<Button>() == null)
                    continue;

                g.GetComponent<WindowPart>().Deselect();
            }
            foreach (var g in windowPairs2)
            {
                if(g.GetComponent<Button>() == null)
                    continue;

                g.GetComponent<WindowPart>().Deselect();
            }

            p1MovingObj = null;
            p2MovingObj = null;
            
            ActivateP1Select();
        }
    }

    void WindowClicked()
    {
        bool p1Selected = windowPairs1.Contains(EventSystem.current.currentSelectedGameObject);
        
        EventSystem.current.currentSelectedGameObject.GetComponent<WindowPart>().Select();

        if (p1MovingObj == null || p2MovingObj == null)
        {
            if (p1Selected == true)
                ActivateP2Select();
            else
                ActivateP1Select();
        }
        else
        {
            DeactivateAll();
        }

    }

    public void ActivateP1Select()
    {
        if (p1MovingObj != null)
            return;
        
        print("acivate P1 select");
        foreach (var g in windowPairs1)
        {
            if(g.GetComponent<Button>() == null)
                continue;
            
            g.GetComponent<WindowPart>().Activate();
            g.GetComponent<Button>().Select();
        }
        foreach (var g in windowPairs2)
        {
            if(g.GetComponent<Button>() == null)
                continue;

            g.GetComponent<WindowPart>().Deactivate();
        }
    }
    public void ActivateP2Select()
    {
        if (p2MovingObj != null)
            return;
        
        print("acivate P2 select");
        foreach (var g in windowPairs1)
        {
            if(g.GetComponent<Button>() == null)
                continue;

            g.GetComponent<WindowPart>().Deactivate();
            
        }
        foreach (var g in windowPairs2)
        {
            if(g.GetComponent<Button>() == null)
                continue;

            g.GetComponent<WindowPart>().Activate();
            g.GetComponent<Button>().Select();
        }
    }

    public void DeactivateAll()
    {
        foreach (var g in windowPairs1)
        {
            if(g.GetComponent<Button>() == null)
                continue;

            g.GetComponent<WindowPart>().Deactivate();
        }
        foreach (var g in windowPairs2)
        {
            if(g.GetComponent<Button>() == null)
                continue;

            g.GetComponent<WindowPart>().Deactivate();
        }
    }

    public bool CheckPair(GameObject go1, GameObject go2)
    {
        int go1Key = (windowPairs1.Contains(go1)) ? windowPairs1.IndexOf((go1)) : windowPairs2.IndexOf((go1));
        int go2Key = (windowPairs1.Contains(go2)) ? windowPairs1.IndexOf((go2)) : windowPairs2.IndexOf((go2));

        return go1Key == go2Key;
    }
}
