using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public UnityEngine.UI.Text text_Timer;
    private float time;

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        text_Timer.text = string.Format("{0:N2}", time);
    }
}
