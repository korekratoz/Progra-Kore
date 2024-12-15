using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{

    int daño;
    int municion;
    int tamañoDeCargador;
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
