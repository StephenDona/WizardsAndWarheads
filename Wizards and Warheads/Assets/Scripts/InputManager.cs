﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float AltHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_AltHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float AltVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_AltVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool Abutton()
    {
        return Input.GetButtonDown("A_Button");   
    }

    public static bool Bbutton()
    {
        return Input.GetButtonDown("B_Button");
    }

    public static bool Xbutton()
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool Ybutton()
    {
        return Input.GetButtonDown("Y_Button");
    }


}
