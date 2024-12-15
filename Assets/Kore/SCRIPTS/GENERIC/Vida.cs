using Kore;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public TextMeshProUGUI text;
    public VidaJugador jugador;
    
    // Update is called once per frame
    void Update()
    {
     text.text = $"Vida : {jugador.health}";   
    }
}
