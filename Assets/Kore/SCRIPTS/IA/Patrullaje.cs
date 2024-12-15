using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Kore
{
  
    public class Patrullaje : MonoBehaviour
    {

        public List<Transform> puntosDePatrullaje = new List<Transform>();
        public float tiempoDeVigilancia;
        public bool destinoAlcanzado;
        private NavMeshAgent agent;
        private Transform puntoActual;
        public string NombrePatrulla;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            GameObject[] puntos = GameObject.FindGameObjectsWithTag(NombrePatrulla);
            foreach (GameObject punto in puntos)
            {
                puntosDePatrullaje.Add(punto.transform);
            }

            StartCoroutine(Patrullar());
        }

        public IEnumerator Patrullar()
        {
            Transform randomPos = RandomPos();

            puntoActual = randomPos.transform; //Aqui guardamos el punto actual de patrullaje

            agent.destination = randomPos.position;

            yield return new WaitUntil(() => Vector3.Distance(transform.position, randomPos.position) < 2);

            Debug.Log("Ya llegó al punto");

            destinoAlcanzado = true;

            yield return new WaitForSeconds(tiempoDeVigilancia);

            if (destinoAlcanzado)
            {
                destinoAlcanzado = false;
                StartCoroutine(Patrullar());
            }
        }

        public IEnumerator ReanudarPatrullaje() //Cuando deja de perseguir vuelve a dirigirse al ultimo punto guardado y vuelve a patrullar
        {
            agent.destination = puntoActual.position;
            yield return new WaitUntil(() => Vector3.Distance(transform.position, puntoActual.position) < 2);
            destinoAlcanzado = false;
            yield return new WaitForSeconds(tiempoDeVigilancia);
            StartCoroutine(Patrullar());
        }

        public void DejarDePatrullar()
        {
            StopAllCoroutines();
        }

        private Transform RandomPos()
        {
            int randomPoint = Random.Range(0, puntosDePatrullaje.Count);
            return puntosDePatrullaje[randomPoint];
        }

    }
}