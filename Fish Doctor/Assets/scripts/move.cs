using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 5f;

    //HEALTH
    public int life = 3;

    Vector3 mousePos;
    public Transform body;
    public bool right;
    float beginning_y;

    private Vector3 inputRotation;
    private Vector3 mousePlacement;
    private Vector3 screenCentre;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Debug.Log(new Vector3(Screen.width, Screen.height, 0));
        beginning_y = body.localScale.y;
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        body.right = dir;
        
        if (right && dir.x < 0.0f)
        {
            right = false;
            body.localScale = new Vector3(body.localScale.x, -beginning_y, body.localScale.z);
        }
        else if (!right && dir.x > 0.0f)
        {
            right = true;
            body.localScale = new Vector3(body.localScale.x, beginning_y, body.localScale.z);
        }
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        m_Rigidbody.MovePosition(transform.position + mousePos.normalized * Time.fixedDeltaTime * m_Speed);


        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }
}
