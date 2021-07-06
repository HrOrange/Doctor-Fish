using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die_after_time : MonoBehaviour
{
    public float time_to_die = 1;
    float clock;

    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= time_to_die) GameObject.Destroy(transform.root.gameObject);
    }
}
