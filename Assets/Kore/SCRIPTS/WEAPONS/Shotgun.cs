using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Kore.Weapons
{
  

    public class Shotgun : Weapon
    {

        protected internal override void Shoot()
        {
           
            

        }

        protected internal override void Reload()
        {
            Debug.Log("Recargo");
        }

    }
}