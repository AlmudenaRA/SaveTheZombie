using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{

    public Text totalCollect;
    public Text addCollect;
    private int totalCollectsInLevel;

    private void Start()
    {
        totalCollectsInLevel = transform.childCount;
    }

    private void Update()
    {
        totalCollect.text = totalCollectsInLevel.ToString();
        addCollect.text = transform.childCount.ToString();
    }

   
}
