using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoAI : MonoBehaviour
{
    public enum EstadoDelNPC
    {
        idle,
        walking,
        recogido
    }
    public EstadoDelNPC estadoActual;
    public float vel;
    Rigidbody2D rb;
    bool dir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        estadoActual = EstadoDelNPC.idle;
        StartCoroutine(newState(5));
    }
    IEnumerator newState(float tiempoEspera)
    {
        print("Esperando");
        yield return new WaitForSeconds(tiempoEspera);
        int x = Random.Range(0, 2);
        print(x);
        switch (x)
        {
            case 0: estadoActual = EstadoDelNPC.idle; break;
            case 1: estadoActual = EstadoDelNPC.walking;
                dir = Random.Range(0, 2)==1 ? true : false;  break;
        }
        if (estadoActual != EstadoDelNPC.recogido)
        {
            StartCoroutine(newState(tiempoEspera));
        }
    }

    private void Update()
    {
        if (estadoActual == EstadoDelNPC.walking)
        {
            if (dir)
            {

                rb.velocity = new Vector2(100 * vel * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-100 * vel * Time.deltaTime, rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && estadoActual != EstadoDelNPC.recogido)
        {
            DistanceJoint2D distance = gameObject.AddComponent<DistanceJoint2D>();
            distance.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            distance.autoConfigureDistance = false;
            distance.distance = 3;
            distance.maxDistanceOnly = true;

            Player player = collision.gameObject.GetComponent<Player>();
            player.AddMonito(this);
            rb.velocity = Vector2.zero;
            GetComponent<DestruiblePorBala>().enable = false;
            estadoActual = EstadoDelNPC.recogido;
            StopAllCoroutines();
            //transform.parent = collision.transform;
        }
    }

}
