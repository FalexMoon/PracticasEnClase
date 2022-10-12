using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)Vector2.right * speed*Time.deltaTime*transform.localScale.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("ui");
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (!collision.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
