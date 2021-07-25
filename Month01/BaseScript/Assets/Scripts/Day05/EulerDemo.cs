using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class EulerDemo : MonoBehaviour
{
    public Vector3 euler;
    private void OnGUI()
    {
        euler = transform.eulerAngles;

        if (GUILayout.RepeatButton("沿X轴旋转"))
        {
            //Vector3 euler = transform.eulerAngles;
            //欧拉角 没有 方向 和 大小的概念。
            //x  y   z  沿某个轴的旋转角度 
            transform.eulerAngles += new Vector3(1, 0, 0);
        }
        if (GUILayout.RepeatButton("沿Y轴旋转"))
        {
            transform.eulerAngles += Vector3.up;
        }
        if (GUILayout.RepeatButton("沿Z轴旋转"))
        {
            transform.eulerAngles += Vector3.forward;
        }
    }
 
}
