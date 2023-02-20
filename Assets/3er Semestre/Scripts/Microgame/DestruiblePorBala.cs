using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruiblePorBala : MonoBehaviour
{
    public GameObject effecto;
    public bool enable = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && enable)
        {
            GameObject effect = Instantiate(effecto, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && enable)
        {
            GameObject effect = Instantiate(effecto, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }
}
