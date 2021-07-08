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

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
        if (transform.rotation.z > 0.5f || transform.rotation.z < -0.5f) transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        rig.AddForce(transform.right * m_Speed);
    }


    void Update()
    {
        //rig.MovePosition(transform.position + transform.right * Time.deltaTime * m_Speed);
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

        //Destroy(gameObject);
    }
}
