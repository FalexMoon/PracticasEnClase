using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class ProyectoMate : MonoBehaviour
{
    Vector2 pivotePos;
    Vector2 inicialPosPivote;
    float grados;
    public float vel;
    bool horaria;
    bool rotando = true;
    Vector2 dir;
    Vector2 dir2;
    float distancia;

    public LineRenderer line;
    Vector2 MatrizRotacionAntiHoraria(float anguloRotar, Vector2 vectorRotar, Vector2 desfase)
    {
        float x, y;
        vectorRotar -= desfase;
        print(vectorRotar);
        x = (vectorRotar.x * Coseno(anguloRotar)) - (vectorRotar.y * Seno(anguloRotar));
        y = (vectorRotar.x * Seno(anguloRotar)) + (vectorRotar.y * Coseno(anguloRotar));
        x += desfase.x;
        y += desfase.y;
        return new Vector2(x, y);
    }
    Vector2 MatrizRotacionHoraria(float anguloRotar, Vector2 vectorRotar, Vector2 desfase)
    {
        float x, y;
        vectorRotar -= desfase;
        print(vectorRotar);
        x = (vectorRotar.x * Coseno(anguloRotar)) + (vectorRotar.y * Seno(anguloRotar));
        y = (vectorRotar.x * -Seno(anguloRotar)) + (vectorRotar.y * Coseno(anguloRotar));
        x += desfase.x;
        y += desfase.y;
        return new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line.gameObject.SetActive(true);
            rotando = true;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pivotePos = worldPosition;
            inicialPosPivote = (Vector2)transform.position;
            grados = 0;
            line.SetPosition(0, pivotePos);
            line.SetPosition(1, transform.position);
            if (transform.position.x < pivotePos.x)
            {
                horaria = false;
            }
            else
            {
                horaria = true;
            }
        }
        if (Input.GetMouseButtonDown(1) && rotando)
        {
            line.gameObject.SetActive(false);
            rotando = false;
            inicialPosPivote = (Vector2)transform.position;
            distancia = DistanciaEntrePuntos(transform.position, pivotePos);
            if (horaria)
            {
                dir = MatrizRotacionAntiHoraria(90, pivotePos, transform.position);
            }
            else
            {
                dir = MatrizRotacionHoraria(90, pivotePos, transform.position);
            }
            dir2 = dir - (Vector2)transform.position;
            
        }
        if (rotando)
        {
            grados += Time.deltaTime * vel * 10;
            if (grados > 359)
            {
                grados = 0;
            }

            if (horaria)
            {
                transform.position = MatrizRotacionHoraria(grados, inicialPosPivote, pivotePos);
            }
            else
            {
                transform.position = MatrizRotacionAntiHoraria(grados, inicialPosPivote, pivotePos);
            }

            line.SetPosition(0, pivotePos);
            line.SetPosition(1, transform.position);
            Debug.DrawLine(pivotePos, transform.position, Color.blue);
        }
        else
        {
            Debug.DrawLine(inicialPosPivote, dir, Color.green);
            transform.Translate(dir2.normalized * Time.deltaTime * (vel*distancia/5));
        }
        Debug.DrawLine(pivotePos, transform.position, Color.blue);

    }

    float DistanciaEntrePuntos(Vector2 puntoA, Vector2 puntoB)
    {
        return Mathf.Sqrt(Mathf.Pow(puntoB.x - puntoA.x, 2) + Mathf.Pow(puntoB.y - puntoA.y, 2));
    }

    float Coseno(float degrees)
    {
        return Mathf.Round(Mathf.Cos(degrees*Mathf.Deg2Rad) * 1000.0f) * 0.001f;
    }
    float Seno(float degrees)
    {
        return Mathf.Round(Mathf.Sin(degrees * Mathf.Deg2Rad) * 1000.0f) * 0.001f;
    }
    float ArcoTangente(float val)
    {
        return Mathf.Round(Mathf.Atan(val) * 1000.0f) * 0.001f * Mathf.Rad2Deg;
    }

    float AnguloRespectoEjeY(Vector2 posPlayer)
    {
        return ArcoTangente(posPlayer.x /posPlayer.y);
    }
}
