using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeTrigger : MonoBehaviour
{
    public string []inspectLines;
    public string[] monoLines;
    public string[] itemLines;
    public bool isInspect;
    public bool isMono;
    public bool isItem;
    private GameObject textDisplay;
    public GameObject indicator;
    void Start()
    {
        //Get universal Text
        textDisplay = GameObject.Find("NarText");
        indicator = GameObject.Find("eIndicator");
        indicator.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("He's in");
            indicator.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("He's out");
            indicator.SetActive(false);
        }
    }
}
