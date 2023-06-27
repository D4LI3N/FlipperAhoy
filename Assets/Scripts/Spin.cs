using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 500f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gameplay.gameplay)
            transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self); 
    }
}
