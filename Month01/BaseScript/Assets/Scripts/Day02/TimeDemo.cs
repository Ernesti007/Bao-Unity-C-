using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class TimeDemo : MonoBehaviour
{ 
    public float speed = 10;
    private void OnGUI()
    {
        if (GUILayout.Button("游戏暂停"))
        {
            Time.timeScale = 0;
        }
        if (GUILayout.Button("游戏继续"))
        {
            Time.timeScale = 1;
        }
        if (GUILayout.Button("慢动作"))
        {
            Time.timeScale = 0.1f;
        }
        /*
         Time.timeScale 
         不影响渲染  所以 Update 执行间隔不受影响
         影响物理更新 所以FidexUpdate执行间隔受间隔
         Time.deltaTime  受影响
         */
    }

    public float deltaTime, unscaledDeltaTime, time, unscaledTime;
    private void Update()
    { 
        //本帧时间  -   上一帧时间
        //上一帧消耗时间
        deltaTime = Time.deltaTime;

        unscaledDeltaTime = Time.unscaledDeltaTime;

        time = Time.time;

        unscaledTime = Time.unscaledTime;

        //机器性能差/渲染量大    每帧执行间隔大   每秒渲染次数少(Update执行次数少)  希望 每次多旋转
        //机器性能好/渲染量小    每帧执行间隔小   每秒渲染次数多(Update执行次数多)  希望 每次少旋转
          
        //每帧沿Y轴旋转1度
        //transform.Rotate(0, 1, 0);

        //如果Update执行次数少  那么deltaTime数值大
        //                              多                               小
        //总结：如果在Update中对物体做物理操作(移动/旋转/力)
        //         需要在速度上 乘以 每帧消耗时间，用以得到恒定的速度。
        //transform.Rotate(0, speed * Time.deltaTime, 0);

        //如果希望游戏暂停后，当前物体不受影响
        transform.Rotate(0, speed * Time.unscaledDeltaTime, 0);
    }

    private void FixedUpdate()
    {  
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
 
}
