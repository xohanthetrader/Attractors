using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttractor
{
    public  Vector3 diffrential(Vector3 pos, float dt, Dictionary<string, float> args);
    public void SetActive(bool active);

    void Remove();
}
