using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEaraser : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = 5.0f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
