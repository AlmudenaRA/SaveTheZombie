using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAnimation : MonoBehaviour
{
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
        }
    }
}
