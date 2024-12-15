using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Victoria : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FinDelJuego());



        }

    }

    IEnumerator FinDelJuego()
    {
        text.gameObject.SetActive(true);
        Time.timeScale = 0f;
        yield return null;
    }

}
