using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public Text text;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        int min = Mathf.FloorToInt(time / 60.0f);
        int sec = Mathf.RoundToInt(time % 60);
        text.text = min + ":" + sec;
    }
}
