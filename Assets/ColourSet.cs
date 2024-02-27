using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSet : MonoBehaviour
{
    public Material whiteGlow;
    public List<Color> defaults = new List<Color>();
    public Color col1;
    public Color col2;
    private void Awake()
    {
        defaults.Add(whiteGlow.GetColor("_Colour1"));
        col1 = defaults[0];
        defaults.Add(whiteGlow.GetColor("_Colour2"));
        col2 = defaults[1];
    }

    
    private void OnApplicationQuit()
    {
        whiteGlow.SetColor("_Colour1",defaults[0]);
        whiteGlow.SetColor("_Colour2",defaults[1]);
    }

    private void Update()
    {
        whiteGlow.SetColor("_Colour1",col1);
        whiteGlow.SetColor("_Colour2",col2);
    }

    public void Red1(Single Val)
    {
        col1.r = Val;
        print(col1.ToString());
    }
    public void Green1(Single Val) => col1.g = Val;
    public void Blue1(Single Val) => col1.b = Val;
    
    public void Red2(Single Val) => col2.r = Val;
    public void Green2(Single Val) => col2.g = Val;
    public void Blue2(Single Val) => col2.b = Val;

}
