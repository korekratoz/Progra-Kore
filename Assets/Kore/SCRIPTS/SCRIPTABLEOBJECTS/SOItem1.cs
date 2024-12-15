using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO = Scriptable Object
/// </summary>
namespace Kore
{

    [CreateAssetMenu(fileName = "Nuevo Objeto", menuName = "Kore/Crear Nuevo Objeto")]
    public class SOItem : ScriptableObject
    {

        public GameObject itemPrefab;
        public Sprite sprite;
        public string names;
        public string description;

    }

}


