using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public Animator animator;
    public GameObject[] hearts;    
    private int life;

    // Start is called before the first frame update
    private void Start()
    {
        life = hearts.Length;
    }

    private void CheckLife()
    {
        if(life < 1)
        {
            hearts[2].gameObject.SetActive(false);
            //Destroy(hearts[2].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Recarga la escena
            animator.Play("PjDead");
        }
        else if(life < 2)
        {
            hearts[1].gameObject.SetActive(false);
            //Destroy(hearts[1].gameObject);
            animator.Play("PjHurt");
        }
        else if(life < 3)
        {
            hearts[0].gameObject.SetActive(false);
            //Destroy(hearts[0].gameObject);
            animator.Play("PjHurt");
        }
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
        //Debug.Log("Lives damaged: " + life);
    }

    public void RegainLife()
    {
        Debug.Log("Lives: " + life);
        life++;
        if (life > 2)
        {            
            hearts[0].gameObject.SetActive(true);

        }else if (life > 1)
        {
            hearts[1].gameObject.SetActive(true);
        }
        
    }
}
