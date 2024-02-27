using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprottB : MonoBehaviour,IAttractor
{
    private Dictionary<string, float> vars = new();
    private bool Active = true;
    private Transform position;
    void Start()
    {
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            position.Translate(diffrential(position.position,0.02f,vars));
        }
    }

    public Vector3 diffrential(Vector3 pos, float dt, Dictionary<string, float> args)
    {
        Vector3 next = new Vector3
        {
            x = pos.y * pos.z,
            y = pos.x - pos.y,
            z = 1 - pos.x * pos.y
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
