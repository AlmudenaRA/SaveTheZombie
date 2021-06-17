using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel2 : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //El pj colisiona con el enemigo al saltarle encima
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);

            LosseLifeAndHit(); //perder vida del enemigo
            CheckLife(); //comprobar si el enemigo muere
        }
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false; //para que desaparezca el enemigo
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void LosseLifeAndHit()
    {
        lifes--;
        animator.Play("BatHit");
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
