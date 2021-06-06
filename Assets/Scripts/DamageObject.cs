using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged"); //El jugador ha recibido da�o
            Destroy(collision.gameObject); //el jugador muere al colisionar 
        }
    }
}
