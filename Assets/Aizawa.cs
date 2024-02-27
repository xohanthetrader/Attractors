using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public class Aizawa : MonoBehaviour,IAttractor
{
    private Transform Position;
    private bool Active = true;
    private Dictionary<string, float> vars = new()
    {
        {"a",0.95f},
        {"b",0.7f},
        {"c",0.65f},
        {"d",3.5f},
        {"e",0.25f},
        {"f",0.1f}
    };
    void Start()
    {
        Position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active)
        {
            Position.Translate(diffrential(Position.position,0.01f,vars));
        }
    }

    public Vector3 diffrential(Vector3 pos, float dt, Dictionary<string, float> args)
    {
        Vector3 next = new Vector3
        {
            x = (pos.z - args["b"]) * pos.x - args["d"] * pos.y,
            y = args["d"] * pos.x + (pos.z - args["b"]) * pos.y,
            z = args["c"] + args["a"] * pos.z - math.pow(pos.z, 3) / 3 -
                (math.pow(pos.x, 2) + math.pow(pos.y, 2)) * (1 + args["e"] * pos.z) +
                args["f"] * pos.z * math.pow(pos.x, 3)
        };
        return next * dt;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }
    public void Remove()
    {
        Destroy(this);
    }
}
