using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timer;
    public float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTime = Mathf.Round(currentTime * 100f) / 100f;
        
        timer.text = currentTime.ToString() + " s";
    }
}
