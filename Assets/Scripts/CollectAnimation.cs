using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectAnimation : MonoBehaviour
{

    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Desactivar el sprite Renderer del recogible
            GetComponent<SpriteRenderer>().enabled = false;
            //Activar la animación
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Eliminar todo en 5 segundos
            Destroy(gameObject, 0.5f);
            audio.Play();
        }
    }
}
