using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character : MonoBehaviour
{
    bool right = true;
    public Transform rpg;

    float rpg_x;


    void Start()
    {
        rpg_x = rpg.localPosition.x;
    }

    void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (right && m_Input.x < 0)
        {
            right = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rpg.localPosition = new Vector3(-rpg_x, rpg.localPosition.y, rpg.localPosition.z);
            //foreach (Transform t in rpg) t.localPosition = new Vector3(0, 0, 0);

        }
        else if (!right && m_Input.x > 0)
        {
            right = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rpg.localPosition = new Vector3(rpg_x, rpg.localPosition.y, rpg.localPosition.z);
            //foreach (Transform t in rpg) t.localPosition = new Vector3(0, 0, 0);
        }
    }
}
