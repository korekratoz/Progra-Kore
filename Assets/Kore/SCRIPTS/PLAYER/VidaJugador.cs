using UnityEngine;

namespace Kore
{

    public class VidaJugador : MonoBehaviour
    {
        public float health = 10f;
        public Transform spawn;
        public Transform player;

        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log(damage + "de daño recibido. Vida actual: " + health);

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Moriste!");
            player.transform.position = spawn.position;
            health = 10;
        }
    }

}