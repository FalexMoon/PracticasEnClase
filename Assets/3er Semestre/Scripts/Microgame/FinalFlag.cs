using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FinalFlag : MonoBehaviour
{
    public List<MonitoAI> monitos = new List<MonitoAI>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            while(player.monitos.Count > 0)
            {
                monitos.Add(player.monitos[0]);
                Destroy(player.monitos[0].GetComponent<Joint2D>());
                player.monitos[0].GetComponent<DestruiblePorBala>().enable = true;
                player.monitos.Remove(player.monitos[0]);
            }
        }
    }
}
