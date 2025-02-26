using DG.Tweening;
using Kore;
using Unity.VisualScripting;
using UnityEngine;


// Tipos de puerta: Automatica, Normal, DeLlave, Evento, MultiplesLlaves
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public TipoDePuerta tipoDePuerta;

    //Evento
    [SerializeField] public bool eventoActivado;

    // Llave
    [SerializeField] public SOItem key;

    // MultiplesLlaves
    [SerializeField] public SOItem[] keys;

    [SerializeField] bool activarPuertaA;

    public GameObject puerta;


    private InventoryHandler inventoryHandler;

    private void Awake()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();
    }

    public void Interact()
    {

        switch (tipoDePuerta)
        {
            case TipoDePuerta.Automatica:
                {
                    Automatica();
                    Debug.Log("Se abre automaticamente");
                    break;
                }

            case TipoDePuerta.Normal:
                {
                    Normal();
                    Debug.Log("Se abre");
                    break;
                }

            case TipoDePuerta.DeLlave:
                {
                    DeLlave();
                    Debug.Log("Se abre con llave");
                    break;
                }

            case TipoDePuerta.Evento:
                {
                    Evento();
                    Debug.Log("Se abre con evento");
                    break;
                }

            case TipoDePuerta.MultiplesLlaves:
                {
                    MultiplesLlaves();
                    Debug.Log("Se abre con multiples llaves");
                    break;
                }
        }


    }


    private void Automatica()
    {
        if (activarPuertaA)
        {
            transform.DOLocalMoveY(-5, 1);
        }
    }

    private void Normal()
    {
        transform.DOLocalMoveY(-5, 1);
    }

    private void Evento()
    {

    }

    private void MultiplesLlaves()
    {

    }


    private void DeLlave()
    {
        if (inventoryHandler.inventory.Contains(key))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activarPuertaA = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activarPuertaA = false;
        }
    }

}


public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}