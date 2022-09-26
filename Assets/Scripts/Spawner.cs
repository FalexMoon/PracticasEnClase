using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public int frecuencia;
    public int probabilidad;
    public bool posVariable;

    private void Start()
    {
        InvokeRepeating("Spawn", 1, frecuencia);
    }

    void Spawn()
    {
        if (Random.Range(0, probabilidad) == 1)
        {
            Vector2 pos = transform.position; ;
            if (posVariable)
            {
                pos.y = Random.Range((int)transform.position.y - 2, (int)transform.position.y + 2);
            }

            int x = Random.Range(0, ObjectsToSpawn.Length);
            Instantiate(ObjectsToSpawn[x], pos, Quaternion.identity);
        }
    }
}
