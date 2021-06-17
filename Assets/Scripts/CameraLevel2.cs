using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel2 : MonoBehaviour
{
    public GameObject pj;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; //coger la posición de la cámara
        position.x = pj.transform.position.x + 1.0f; //coge la posición del personaje
        transform.position = position;

        Vector3 positionv = transform.position; //coger la posición de la cámara
        positionv.y = pj.transform.position.y + 1.1f; //coge la posición del personaje
        transform.position = positionv;
    }
}
