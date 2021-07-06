using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawn_this;
    public float time_to_die = 2.5f;
    float clock;

    void Start()
    {
        Instantiate(spawn_this, transform.position, Quaternion.identity);
    }
    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= time_to_die) { 
            Instantiate(spawn_this, transform.position, Quaternion.identity);
            clock = 0;
        }
    }
}
