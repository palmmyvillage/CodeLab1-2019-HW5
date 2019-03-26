using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{

    private void OnMouseDown()
    {        
        if (Int32.Parse(gameObject.GetComponentInChildren<TextMesh>().text) == GameManager.instance.currentNumber)
        {
            GameManager.instance.currentNumber++;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
