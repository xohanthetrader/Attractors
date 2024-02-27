using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lorenz : MonoBehaviour,IAttractor
{
    private Transform Position;
    private bool Active = true;
    
    Dictionary<string, float> vars = new()
    {
        {"sigma",10},
        {"beta",2.66667f},
        {"rho",28}
    };

    public Vector3 diffrential(Vector3 pos, float dt, Dictionary<string,float> args)
    {
        Vector3 next = new Vector3
        {
            x = args["sigma"] * (pos.y - pos.x),
            y = pos.x * (args["rho"] - pos.z) - pos.y,
            z = pos.x * pos.y - args["beta"] * pos.z
        };

        return next * dt;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }

    void Start()
    {
        Position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active)
        {
            Position.Translate(diffrential(Position.position,.01f,vars));
        }
    }
    public void Remove()
    {
        Destroy(this);
    }
}
