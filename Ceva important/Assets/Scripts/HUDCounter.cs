using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCounter : MonoBehaviour {
    public Text countText;
    public murecounter mc;
    // Use this for initialization
    void Start () {
        countText.text = "Blueberries: " + mc.countmure.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        countText.text = "Blueberries: " + mc.countmure.ToString();

    }
}
