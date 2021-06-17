using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitForEnd", 2); //Vuelve al menú cuando han pasado 2 seg
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaitForEnd()
    {
        SceneManager.LoadScene("Menu");
    }
}
