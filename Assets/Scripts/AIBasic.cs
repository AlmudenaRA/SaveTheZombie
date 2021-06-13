using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    public Transform[] moveSpots;
    public float startWaitTime = 2;

    private float waitTime;    
    private int i = 0;
    private Vector2 actualPos;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime; 
    }

    // Update is called once per frame
    void Update()
    {
        //llamar corrutina
        StartCoroutine(CheckEnemyMovie());

        //Mover un pj hacia un punto, para ello decimos que se mueva hacia la dirección, 
        //indicando la dirección que queremos y la velocidad
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            //Si la distancia es menor estamos en el punto adecuado, entonces mantenemos el Idle en esa posición
            //Si ese tiempo ha pasado, pasa hacia el siguiente punto o sumar tiempo hasta completarlo
            if(waitTime <= 0)
            {
                //Si se ha completado pasa al siguiente tiempo
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else i = 0;

                waitTime = startWaitTime;
            }
            else waitTime -= Time.deltaTime; //le resta los segundos que han pasado para mantener la animación Idle
  
        }
    }

    IEnumerator CheckEnemyMovie()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f); //esperar durante 5seg para comprobar la posición del enemigo

        if(transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            

        }else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}
