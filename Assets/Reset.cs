using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    public void ReturnToStart()
    {
        transform.position = startPos;
    }
}
