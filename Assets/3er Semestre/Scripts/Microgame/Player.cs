using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<MonitoAI> monitos = new List<MonitoAI> ();

    public void AddMonito(MonitoAI newMonito)
    {
        monitos.Add(newMonito);
    }
}
