using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountDown : MonoBehaviour
{
    public float countFrom;
    public TMP_Text ui;
    int mili;
    int secs;
    int mins;
    string reloj;
    // Update is called once per frame
    void Update()
    {
        if (countFrom > 0)
        {
            countFrom -= Time.deltaTime;
            mins = Mathf.FloorToInt(countFrom / 60);
            secs = Mathf.FloorToInt(countFrom % 60);
            mili = Mathf.FloorToInt((countFrom * 100) % 100);
            reloj = convertToString(mins) + ":" + convertToString(secs) + ":" + convertToString(mili);
        }
        else
        {
            reloj = "Se acabo el tiempo :3";
        }
        ui.text = reloj;
    }

    string convertToString(int x)
    {
        if (x > 9)
        {
            return x.ToString();

        }else if (x == 0)
        {
            return "00";
        }
        else
        {
            return "0" + x.ToString();
        }
    }
}
