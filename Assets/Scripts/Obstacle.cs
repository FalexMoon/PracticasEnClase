using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool movement;
    float vel;
    public float velocity;

    private void Start()
    {
        try
        {
            vel = FindObjectOfType<Paralax>().paralaxVel;
        }
        catch
        {
            vel = velocity;
        }
        Destroy(gameObject, 15f);
    }

    virtual public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(movement)
        transform.position = new Vector3(transform.localPosition.x - (vel / 1000), transform.position.y, 0);
    }
}
