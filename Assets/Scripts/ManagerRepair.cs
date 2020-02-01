using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManagerRepair : MonoBehaviour
{
    public List<GameObject> windowPairs1;
    public List<GameObject> windowPairs2;
    public float moveSpeed;
    public GameObject p1MovingObj;
    public GameObject p2MovingObj ;
    
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

    void WindowClicked()
    {
        bool p1Selected = windowPairs1.Contains(EventSystem.current.currentSelectedGameObject);
        
        EventSystem.current.currentSelectedGameObject.GetComponent<WindowPart>().Select();
        
        if(p1Selected == true)
            ActivateP2Select();
        else
            ActivateP1Select();
        
    }

    public void ActivateP1Select()
    {
        if (p1MovingObj != null)
            return;
        
        print("acivate P1 select");
        foreach (var g in windowPairs1)
        {
            if(g == null)
                continue;
            
            g.GetComponent<WindowPart>().Activate();
            g.GetComponent<Button>().Select();
        }
        foreach (var g in windowPairs2)
        {
            if(g == null)
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
            if(g == null)
                continue;

            g.GetComponent<WindowPart>().Deactivate();
            
        }
        foreach (var g in windowPairs2)
        {
            if(g == null)
                continue;

            g.GetComponent<WindowPart>().Activate();
            g.GetComponent<Button>().Select();
        }
    }

    
}
