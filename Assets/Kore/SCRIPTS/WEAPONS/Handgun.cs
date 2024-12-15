using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Kore.Weapons
{
   
    public class Handgun : Weapon
    {
        
        protected internal override void Shoot()
        {
            base.Shoot();            
        }

        protected internal override void Reload()
        {
            StartCoroutine(Recargar());
        }

        IEnumerator Recargar()
        {
            if (maxAmmo + actualAmmo > magazineSize)
            {

                yield return new WaitForSeconds(reloadTime);
                int ammorRed = magazineSize - actualAmmo;
                maxAmmo -= ammorRed;
                actualAmmo = magazineSize;

            }

            else if (maxAmmo == 0)
            {
                yield return null;
            }

            else
            {
                yield return new WaitForSeconds(reloadTime);
                int ammoRed = magazineSize - actualAmmo;
                maxAmmo -= ammoRed;
                actualAmmo = maxAmmo;
            }

        }
    }

}

