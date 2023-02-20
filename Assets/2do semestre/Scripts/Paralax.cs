using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float paralaxVel;
    public Transform back;
    public float tileValue;
    Vector3 initialPos;
    Vector3 endPos;

    private void Awake()
    {
        initialPos = back.transform.position;
        endPos = new Vector3(initialPos.x-tileValue, initialPos.y, initialPos.z);
    }
    // Update is called once per frame
    void Update()
    {
        back.transform.position = new Vector3(back.transform.localPosition.x - (paralaxVel/1000), 0, 0);
        if(back.transform.position.x <= endPos.x)
        {
            back.transform.position = initialPos;
        }
    }
}
