using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_forward : MonoBehaviour
{
    Rigidbody2D rig;
    public float m_Speed = 5f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rig.MovePosition(transform.position + transform.right * Time.deltaTime * m_Speed);
    }
}
