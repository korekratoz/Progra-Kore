using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTransition : MonoBehaviour
{
    [SerializeField]Materiales[] materiales;
    [SerializeField]MeshRenderer punta;
    [SerializeField] MeshRenderer mango;

    // Start is called before the first frame update
    void Start()
    {
        // consigues el mesh renderer de el pincel
    }


    private void OnTriggerEnter(Collider other)
    {
        // 0 punta
        // 1 mango
        // if (red)
        // punta.material = materiales[0].rojo
        // mango.material = materiales[1].rojo
        // if(azul)
        // punta.material = materiales[0].azul
        // mango.material = materiales[1].azul
    }

}
