using UnityEngine;

namespace Kore.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int actualAmmo; // Municion actual de el arma
        [SerializeField] protected int magazineSize; //  tamaño de el cargador
        [SerializeField] protected int maxAmmo; // capacidad maxima de almacenamiento de municion
        [SerializeField] protected float reloadTime; //  tiempo de recarga

        [SerializeField] protected float fireRate; // cadencia
        [SerializeField] protected internal float range; // alcance de el arma

        [SerializeField] protected int damage; // daño

        [SerializeField] protected LayerMask detection; // a que se le puede disparar
        [SerializeField] float lastFired;
        protected RaycastHit target;
        public AudioManager audioManager;
        public string clip;
        public float FireRate { get { return fireRate; } }
        public int ActualAmmo { get { return actualAmmo; } }
        public int MaxAmmo { get { return maxAmmo; } }

        // Instruccion 1, es una relga hecha por el maestro
        protected internal virtual void Shoot()
        {
            if (actualAmmo > 0 && Time.time > lastFired + fireRate)
            {
                audioManager.PlaySFX(clip);
                lastFired = Time.time;
                actualAmmo--;
                if (Physics.Raycast(transform.position, transform.forward * range, out target, range, detection))
                {
                    target.collider.GetComponent<IDamageable>().TakeDamage(damage);
                }

            }

        }

        // Instruccion 2, es una regla hecha por la escuela
        protected internal abstract void Reload();

        protected void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * range);
        }

    }
}