using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    public static float P1MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("P1_J_MainHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P1AltHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("P1_J_AltHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P1MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("P1_J_MainVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P1AltVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("P1_J_AltVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool P1Abutton()
    {
        return Input.GetButtonDown("P1_A_Button");   
    }

    public static bool P1Bbutton()
    {
        return Input.GetButtonDown("P1_B_Button");
    }

    public static bool P1Xbutton()
    {
        return Input.GetButtonDown("P1_X_Button");
    }

    public static bool P1Ybutton()
    {
        return Input.GetButtonDown("P1_Y_Button");
    }

    public static float P2MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("P2_J_MainHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P2AltHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("P2_J_AltHorizontal");
        //r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P2MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("P2_J_MainVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float P2AltVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("P2_J_AltVertical");
        //r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool P2Abutton()
    {
        return Input.GetButtonDown("P2_A_Button");
    }

    public static bool P2Bbutton()
    {
        return Input.GetButtonDown("P2_B_Button");
    }

    public static bool P2Xbutton()
    {
        return Input.GetButtonDown("P2_X_Button");
    }

    public static bool P2Ybutton()
    {
        return Input.GetButtonDown("P2_Y_Button");
    }
}
