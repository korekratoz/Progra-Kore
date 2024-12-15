using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance;

    public AudioSource SFX;
    public Sonido[] musica;

    void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Sonido s in musica) 
        {
            s.source.volume = s.volumen;        
        }

    }

    public void PlaySFX(string nombre)
    {
        Sonido s = Array.Find(musica, x => x.nombre == nombre);
        if (s == null)
        {
            Debug.Log("Sin sonido");
        }

        else
        {
            SFX.PlayOneShot(s.clip);
        }
    }

    public void StopSFX(string nombre)
    {
        Sonido s = Array.Find(musica, x => x.nombre == nombre);
        if (s == null)
        {
            Debug.Log("Sin sonido");
        }

        else
        {
            s.source.Stop();
        }
    }

}