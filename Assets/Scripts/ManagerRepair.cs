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
    }

    void WindowClicked()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<WindowPart>().Select();
        
        foreach (var g in windowPairs1)
        {
            if (EventSystem.current.currentSelectedGameObject != g)
            {
                g.GetComponent<WindowPart>().Deselect();
            }
        }
        foreach (var g in windowPairs2)
        {
            if (EventSystem.current.currentSelectedGameObject != g)
            {
                g.GetComponent<WindowPart>().Deselect();
            }
        }
    }
}
