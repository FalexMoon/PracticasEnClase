using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Obstacle
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collected");
        Destroy(this.gameObject);
    }
}
