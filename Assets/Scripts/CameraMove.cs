using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pj;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; //coger la posici�n de la c�mara
        position.x = pj.transform.position.x; //coge la posici�n del personaje
        transform.position = position;
       
    }
}
