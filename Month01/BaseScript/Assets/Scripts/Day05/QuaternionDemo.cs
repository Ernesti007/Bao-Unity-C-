using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class QuaternionDemo : MonoBehaviour
{
    private void Start()
    {
        //物体沿Y轴旋转50度
        Vector3 axis = Vector3.up;
        float rad = 50 * Mathf.Deg2Rad;
        Quaternion qt = new Quaternion();
        qt.x = Mathf.Sin(rad / 2) * axis.x;
        qt.y = Mathf.Sin(rad / 2) * axis.y;
        qt.z = Mathf.Sin(rad / 2) * axis.z;
        qt.w = Mathf.Cos(rad / 2);

        //transform.rotation = qt;
        transform.rotation = Quaternion.Euler(0, 50, 0);

        Debug.Log(transform.eulerAngles);
    }

    //计算
    private void OnGUI()
    { 
        if (GUILayout.RepeatButton("沿X轴旋转"))
        {  
            transform.rotation *= Quaternion.Euler(1, 0, 0);
            //transform.Rotate(1, 0, 0); //Rotate通过四元数实现
        }
        if (GUILayout.RepeatButton("沿Y轴旋转"))
        {
            transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
        if (GUILayout.RepeatButton("沿Z轴旋转"))
        {
            transform.rotation *= Quaternion.Euler(0, 0, 1);
        }
    }

    private void Update()
    {
        Demo01();
    }

    private void Demo01()
    {  
        //计算物体右前方30度10m处坐标
        Vector3 worldPos =
            transform.position + Quaternion.Euler(0, 30, 0) * transform.rotation * new Vector3(0, 0, 10);

        Debug.DrawLine(transform.position, worldPos);
    }
}
