using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rig;
    public float m_Speed = 40.0f;
    public GameObject Particle;
    public float range = 5.0f;
    public float survival_time = 20.0f;
    
    public Transform center;
    public Transform circle;

    void Start()
    {
        circle.localScale = new Vector3(circle.localScale.x * range, circle.localScale.y * range, circle.localScale.z);

        rig = GetComponent<Rigidbody2D>();
        
        if (transform.rotation.z > 0.5f || transform.rotation.z < -0.5f) transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }


    void Update()
    {
        rig.MovePosition(transform.position + transform.right * Time.deltaTime * m_Speed);
        survival_time -= Time.deltaTime;
        if (survival_time <= 0) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        foreach(GameObject ob in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(ob.transform.position, center.position) < range) 
            {
                Destroy(ob);
            }
        }
        Instantiate(Particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
