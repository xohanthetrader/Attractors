using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAttractor : MonoBehaviour,IAttractor
{
 

    public Vector3 diffrential(Vector3 pos, float dt, Dictionary<string, float> args)
    {
        throw new System.NotImplementedException();
    }

    public void SetActive(bool active)
    {
        throw new System.NotImplementedException();
    }

    public void Remove()
    {
        Destroy(this);
    }
}
