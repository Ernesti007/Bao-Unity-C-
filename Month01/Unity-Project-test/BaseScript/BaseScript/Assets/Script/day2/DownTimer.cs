using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownTimer : MonoBehaviour
{
    public int second;
    private Text texttime;
    public void Start()
    {
        texttime = this.GetComponent<Text>();
        InvokeRepeating("Ti", 1, 1);
    }
    private void Ti()
    {
        second--;
        texttime.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
        if (second <= 0)
            CancelInvoke("Ti");
    }
}

