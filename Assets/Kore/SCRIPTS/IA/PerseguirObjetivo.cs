
using UnityEngine;
using UnityEngine.AI;


namespace Kore
{
  
    public class PerseguirObjetivo : MonoBehaviour
    {

        public Transform objetivo;
        public float velocidad;

        private NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Perseguir()
        {
            agent.speed = velocidad;
            agent.destination = objetivo.position;
        }

    }

}