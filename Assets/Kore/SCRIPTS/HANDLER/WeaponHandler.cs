using UnityEngine;



namespace Kore.Weapons
{

    public class WeaponHandler : MonoBehaviour
    {

        [SerializeField] private Weapon[] weapons;
        [SerializeField] private Weapon currentWeapon;
        [SerializeField] private float lastFired;
        public Weapon CurrentWeapon { get { return currentWeapon; } }
        private void Update()
        {
            Aim();
            Reload();
            ChangeWeap();
        }

        private void ChangeWeap()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                weapons[0].clip = "AR";
                currentWeapon = weapons[0];
                weapons[0].gameObject.SetActive(true);
                weapons[1].gameObject.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                weapons[1].clip = "DE";
                currentWeapon = weapons[1];
                weapons[0].gameObject.SetActive(false);
                weapons[1].gameObject.SetActive(true);
            }
        }

        private void Reload()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                currentWeapon.Reload();
            }
        }

        private void Aim()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                currentWeapon.Shoot();
            }
        }

    }

}