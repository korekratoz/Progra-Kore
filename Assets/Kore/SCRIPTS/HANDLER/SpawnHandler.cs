using System.Collections;
using UnityEngine;

namespace Kore
{

    public class SpawnHandler : MonoBehaviour
    {
        [SerializeField] GameObject enemigo;
        [SerializeField] GameObject spawnpoint;
        [SerializeField] int timer;


        void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            yield return new WaitForSeconds(timer);
            Instantiate(enemigo, spawnpoint.transform);
            yield return new WaitForSeconds(1);
            StartCoroutine(SpawnEnemies());
        }

    }
}
