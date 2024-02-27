using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dadras : MonoBehaviour,IAttractor
{
    private Transform Position;
    private bool Active = true;

    private Dictionary<string, float> vars = new()
    {
        { "p", 3 },
        {"o", 2.7f },
        { "r", 1.7f },
        { "c", 2 },
        { "e", 9 }
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
            Position.Translate(diffrential(Position.position,0.005f,vars));
        }
    }

    public Vector3 diffrential(Vector3 pos, float dt, Dictionary<string, float> args)
    {
        Vector3 next = new Vector3
        {
            x = (pos.y - (args["p"] * pos.x) + (args["o"] * pos.y * pos.z)),
            y = ((args["r"] * pos.y) - (pos.x * pos.z) + pos.z),
            z = ((args["c"] * pos.x * pos.y) - (args["e"] * pos.z))
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
