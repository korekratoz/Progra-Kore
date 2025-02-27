using DG.Tweening;
using Kore;
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

        transform.DOLocalMoveY(-5, 1);

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
        bool hasAllKeys = true;
        foreach (SOItem requiredKey in keys)
        {
            if (!inventoryHandler.inventory.Contains(requiredKey))
            {
                hasAllKeys = false;
                break;
            }
        }

        if (hasAllKeys)
        {
            transform.DOLocalMoveY(-5, 1);
        }
        else
        {
            Debug.Log("No tienes todas las llaves");
        }
    }


    private void DeLlave()
    {
        if (inventoryHandler.inventory.Contains(key))
        {
            transform.DOLocalMoveY(-5, 1);
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
            if (tipoDePuerta == TipoDePuerta.Automatica)
            {
                Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

}


public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}