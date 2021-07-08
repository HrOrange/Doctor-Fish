using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALL : MonoBehaviour
{
    Rigidbody2D rig;
    public float m_Speed = 2500.0f;
    public GameObject Particle;
    public float range = 5.0f;
    public float survival_time = 20.0f;

    public Transform center;
    public Transform range_circle;
    public float my_speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.AddRelativeForce(transform.right * m_Speed);

        range_circle.localScale = new Vector3(range, range, 1);
    }

    void FixedUpdate()
    {
        my_speed = rig.velocity.magnitude;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            foreach (GameObject ob in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(ob.transform.position, center.position) <= range)
                {
                    Destroy(ob);
                }
            }
            Instantiate(Particle, transform.position, Quaternion.identity);

            Vector3 dir = Vector3.Normalize(col.gameObject.transform.root.position - center.position) * -1 * range;
            rig.velocity = new Vector3(dir.x, dir.y, 0);
        }

        //Destroy(gameObject);
    }
}
