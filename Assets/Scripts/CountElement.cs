using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountElement : MonoBehaviour
{
    public GameObject finalBoss;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            finalBoss.gameObject.SetActive(true);
        }
    }
}
