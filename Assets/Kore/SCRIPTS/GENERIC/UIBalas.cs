using Kore.Weapons;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBalas : MonoBehaviour
{
    public TextMeshProUGUI text;
    public WeaponHandler weapon;
    void Update()
    {
        text.text = $"Balas: {weapon.CurrentWeapon.ActualAmmo} / {weapon.CurrentWeapon.MaxAmmo}";
    }
}
