using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{

    int da�o;
    int municion;
    int tama�oDeCargador;
    int cadencia;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Disparar();
        }
    }

    public void Disparar()
    {

    }

    public void Recargar()
    {

    }
}
