using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 倒计时器
/// </summary>
public class CountdownTimer : MonoBehaviour
{
    public int second = 120;

    private Text txtTimer;
    private void Start()
    {
        txtTimer = GetComponent<Text>();
         
        //重复调用（要执行的方法名称,开始调用时间,调用间隔）
        InvokeRepeating("Timer", 1, 1); 
        //延迟调用
        //Invoke("需要调用的方法名称", 调用时间);
    }

    private float nextTime = 1;//下一次改变时间
    private void Update()
    {
        //如果(按住鼠标左键 &&  nextTime <= Time.time)
        // 则发射子弹   nextTime = Time.time + 0.1f;
         
        //如果(按住鼠标左键)
        //totalTime += Time.deltaTime;
        // if(totalTime >=0.1f)
        // 则发射子弹  totalTime = 0;

        //沿多个路点移动，到达目标等待一段时间。
        //如果到达目标点
        //totalTime += Time.deltaTime;
        // if(totalTime >=3)
        // 设置目标点   totalTime = 0
          
        //Timer();
    }
     
    //Time.time 实现
    //试用场合：发射子弹
    private void Timer1()
    {
        //如果时间到了 
        if (nextTime <= Time.time)
        {
            second--;//119       1:59 
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            nextTime = Time.time + 1;//在当前时间上增加1s

            if (second <= 10) txtTimer.color = Color.red;
            if (second <= 0) enabled = false;
        }
    }

    //Time.deltaTime 实现
    //试用场合：沿多个路点移动，每次到达路点等待一段时间。
    private float totalTime = 0;
    private void Timer2()
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;

        //如果1s
        if (totalTime>=1)
        {
            second--;//119       1:59 
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            totalTime = 0;//清空累加的时间
        }
    }

    //InvokeRepeating 实现
    //试用场合：计时器。每间隔固定时间 执行1次
    private void Timer()
    {
        second--;//119       1:59 
        txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

        if (second <= 0)
            CancelInvoke("Timer");//取消调用
    }
}
