using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private BarScript bar;
    private float maxVal;
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = value;
        }
        //https://youtu.be/RVmg6wzC-4U?t=5m25s
    }
}
