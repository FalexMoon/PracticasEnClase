using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float vel;
    Rigidbody2D rb;
    Vector3 dir = new Vector2(0,1);

    public GameObject effect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = dir * vel;
    }

    public void Inicializar(Vector3 direccion)
    {
        direccion = new Vector2(direccion.x * -1, direccion.y * -1);
        dir = direccion.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            Destroy(Instantiate(effect,transform.position,Quaternion.identity),1);
            Destroy(gameObject);
        }
    }
}
