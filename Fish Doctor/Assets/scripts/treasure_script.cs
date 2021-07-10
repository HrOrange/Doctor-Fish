using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure_script : MonoBehaviour
{
    public Animator anim;

    float clock;
    public float time_out = 20.0f;

    void Update()
    {
        if(clock > 0.0f)
        {
            clock -= Time.deltaTime;
            if (clock < 0.0f) clock = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.root.gameObject.tag == "Player" && clock == 0)
        {
            clock = time_out;
            Debug.Log("Got me");
        }
    }
}
