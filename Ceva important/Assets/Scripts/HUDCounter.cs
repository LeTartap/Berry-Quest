﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCounter : MonoBehaviour {
    public Text berryCountText;
    public Text killCountText;
    public murecounter mc;
    // Use this for initialization
    void Start () {
        berryCountText.text =  mc.countmure.ToString();
    }
    
    // Update is called once per frame
    void Update ()
    {
        berryCountText.text = mc.countmure.ToString();
        killCountText.text =  killcounter.killcount.ToString();
    }
}
