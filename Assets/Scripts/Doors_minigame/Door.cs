using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorColor;
    void Start()
    {
        int underscoreLocation = name.IndexOf("_");
        doorColor = name.Substring(0, underscoreLocation);
    }
}