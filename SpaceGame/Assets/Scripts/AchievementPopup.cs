﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour
{

    public Text AchievementText;

    public Transform Starting;//AchievementPopupStart
    public Transform Ending;//AchievementPopupEind
    public float speed;//AchievementPopupSnelheid

    private float step;//AchievementPopupDeltatime

    private bool Active;
    //public bool Reset;//AchievementPopupTESTER
                      //public float[] Achievement;

    bool WentTo;
    private int Timer;


    void Start()
    {
        step = speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        ///string oof = PlayerPrefs.GetInt(Achievement[], 0);
        ///
        if (PlayerPrefs.GetInt("MoonJumper", 0) == 1000)
        {
            GoUp("Moon jumper");
            PlayerPrefs.SetInt("MoonJumper", 2000);
        }
        if (PlayerPrefs.GetInt("Sowemeetagain", 0) == 1)
        {
            GoUp("So we meet again");
            PlayerPrefs.SetInt("Sowemeetagain", 2);
        }
        if (PlayerPrefs.GetInt("GetFucked", 0) == 1)
        {
            PlayerPrefs.SetInt("GetFucked", 2);
            GoUp("You're fucked");
        }
        if (PlayerPrefs.GetInt("HACKER", 0) == 1)
        {
            PlayerPrefs.SetInt("HACKER", 2);
            GoUp("Dirty hacker");
        }
        /*if (Reset)
        {
            PlayerPrefs.SetInt("MoonJumper", 999);
        }*/



        if (Active)
        {
            Timer++;
            //Debug.Log(Timer);
            if (transform.position != Ending.position && !WentTo)
            {
                transform.position = Vector3.MoveTowards(transform.position, Ending.position, step);                
            }
            if (transform.position == Ending.position && Timer >= 300)
            {
                WentTo = true;
            }
            if (WentTo)
            {
                transform.position = Vector3.MoveTowards(transform.position, Starting.position, step);
                if (transform.position == Starting.position)
                {
                    
                    Active = false;
                    WentTo = false;
                    Timer = 0;
                }
            }
        }
    }

    void GoUp(string text)
    {
        AchievementText.text = text;
        Active = true;
    }
}