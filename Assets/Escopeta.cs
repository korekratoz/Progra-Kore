using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{

    int daņo;
    int municion;
    int tamaņoDeCargador;
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
