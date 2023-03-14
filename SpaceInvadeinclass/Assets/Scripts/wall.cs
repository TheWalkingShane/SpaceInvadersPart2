using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("wall hit ally");
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Missle"))
        {
            //Debug.Log("wall hit enemy");
            Destroy(col.gameObject);
        }
    }
}
