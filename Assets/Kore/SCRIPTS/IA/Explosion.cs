using Kore;
using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radioDeteccion;
    public float dañoExplosion;
    public float timer;
    public LayerMask playerLayer;
    public ParticleSystem explosion;


    private void Update()
    {
        Collider[] jugadores = Physics.OverlapSphere(transform.position, radioDeteccion, playerLayer);

        if(jugadores.Length > 0)
        {
            StartCoroutine(Explode(jugadores));
        }

    }
      
    IEnumerator Explode(Collider[] jugadores)
    {
        yield return new WaitForSeconds(timer);
        
        foreach(var collider in jugadores) 
        {
            VidaJugador vidaJugador =collider.GetComponent< VidaJugador>();

            vidaJugador.TakeDamage(dañoExplosion);
        }
        
        StartCoroutine(Boom());

        Destroy(gameObject);

    }

    IEnumerator Boom()
    {
        ParticleSystem explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        Destroy(explosion.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }

}
