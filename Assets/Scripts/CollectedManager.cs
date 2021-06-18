using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectedManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Thread.Sleep(2000);
            //Cuando ha obtenido todos los recogibles cambia de escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
