using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sonido
{
    public string nombre;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volumen;

    [Range(-3f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
