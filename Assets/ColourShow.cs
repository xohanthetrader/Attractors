using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ColourShow : MonoBehaviour
{
    public enum ColourOption
    {
        Colour1,
        Colour2,
    }

    public ColourOption Option;
    public Image panel;
    public ColourSet colours;
    


    private void Update()
    {
        switch (Option)
        {
            case ColourOption.Colour1:
                panel.color = colours.col1;
                break;
            case ColourOption.Colour2:
                panel.color = colours.col2;
                break;
        }
    }
}
