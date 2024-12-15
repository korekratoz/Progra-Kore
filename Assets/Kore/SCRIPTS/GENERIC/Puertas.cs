using UnityEngine;

namespace Kore
{

    public class Puertas : MonoBehaviour, IInteractable
    {

        public bool hasKey;
        public int keyNumber;
        public int requiredKey;
        public InventoryHandler inventoryHandler;

        public void Interact()
        {
            inventoryHandler = FindObjectOfType<InventoryHandler>();

            foreach(var llaves in inventoryHandler.inventory)
            {
                Llave numero = llaves.itemPrefab.GetComponent<Llave>();

                if(numero.keyNumber == requiredKey)
                {
                    hasKey = true;
                }

            }

            if (hasKey)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("No tienes la llave");
            }
        }

    }
}
