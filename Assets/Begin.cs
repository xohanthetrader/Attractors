using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private IAttractor[] components = new IAttractor[64];
    private GameObject[] objects = new GameObject[64];
    private bool paused = false;
    private void Awake()
    {
        var Transforms = GetComponentsInChildren<Transform>();
        for (int i = 1; i < 65; i++)
        {
            objects[i-1] = Transforms[i].gameObject;
            components[i - 1] = Transforms[i].GetComponent<IAttractor>();
        }
        components = GetComponentsInChildren<IAttractor>();
        print(components.Length.ToString() + objects.Length.ToString());
    }

    public void Begin()
    {
        for (int i = 0; i < 64; i++)
        {
            components[i] = objects[i].GetComponent<IAttractor>();
            objects[i].GetComponent<Reset>().ReturnToStart();
            components[i].SetActive(true);
        }
    }

    public void PausePlay()
    {
        foreach (IAttractor attractor in components)
        {
             attractor.SetActive(paused);
        }
        paused = !paused;
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<TrailRenderer>().time = paused ? math.INFINITY : 1f;
        }

    }

    public void setAttractor(int option)
    {
        foreach (GameObject attractor in objects)
        {
            attractor.GetComponent<IAttractor>().Remove();
            print("Destruction");
        }
        switch (option)
        {
            case 1:
                for (int i = 0; i < 64; i++)
                {
                   objects[i].AddComponent<Lorenz>().SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < 64; i++)
                {
                    objects[i].AddComponent<Dadras>().SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < 64; i++)
                {
                    objects[i].AddComponent<SprottB>().SetActive(false);
                }
                break;
                
        }
        
    }

}
