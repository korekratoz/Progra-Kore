using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kore
{

    /// <summary>
    /// EJERCICIO/TAREA
    /// 
    /// Tienen que hacer que cuando se deje de detectar al objetivo después de X cantidad de tiempo, este regrese a el ultimo punto de patrullaje al que fue
    /// 
    /// </summary>
    public class Deteccion : MonoBehaviour
    {
        public float radioDeDetección;
        public LayerMask layer;
        public bool detectado;
        private Patrullaje patrullador;
        private PerseguirObjetivo perseguir;

        private void Start()
        {
            patrullador = GetComponent<Patrullaje>();
            perseguir = GetComponent<PerseguirObjetivo>();
        }

        private void Update()
        {
            Detectar();
        }

        public void Detectar()
        {
            if (Physics.CheckSphere(transform.position, radioDeDetección, layer))
            {
                patrullador.DejarDePatrullar();
                detectado = true;
                perseguir.Perseguir();
            }

            else
            {
                RegresarAPatrullar(); // Al salir de la zona de deteccion, deja de perseguir al jugador
            }

        }

        private void RegresarAPatrullar() //Al estar detectado y salir de la zona de deteccion, dejara de perseguirlo y volvera a patrullar
        {
            if (detectado)
            {
                detectado = false;
                StartCoroutine(patrullador.ReanudarPatrullaje());
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radioDeDetección);
        }



    }
}
