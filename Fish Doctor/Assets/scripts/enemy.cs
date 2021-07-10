using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject player;
    Rigidbody2D m_Rigidbody;

    bool right = true;
    public bool boss;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (transform.rotation.z < 0.5f && transform.rotation.z > -0.5f && !right)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            right = true;
        }
        else if (transform.rotation.z > 0.5f || transform.rotation.z < -0.5f && right)
        {
            transform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
            right = false;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        m_Rigidbody.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.root.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            if (boss)
            {
                col.gameObject.transform.root.GetComponent<move>().life = 0;
                FindObjectOfType<enemy_spawner>().spawn_next_boss();
            }
            else
            {
                col.gameObject.transform.root.GetComponent<move>().life--;
            }
        }
    }
}
