using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playertext : MonoBehaviour
{
    public int textnumber;
    public GameObject text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI thistext = text.GetComponent<TextMeshProUGUI>();
        Playerstatus stats = player.GetComponent<Playerstatus>();
        //Level表記時
        if (textnumber == 3)
        {
            thistext.text = "Lv." + ((int)stats.Getstats(textnumber)).ToString();
        }
        //Level以外の表記時
        else
        {
            thistext.text = ((int)stats.Getstats(textnumber)).ToString();
        }
    }
}
