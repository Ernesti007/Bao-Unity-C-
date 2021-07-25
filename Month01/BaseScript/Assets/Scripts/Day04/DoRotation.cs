using UnityEngine;
using System.Collections;

/// <summary>
/// 鼠标控制相机旋转
/// </summary>
public class DoRotation : MonoBehaviour
{
    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (x != 0 || y != 0)
            RotateView(x, y);

        //需要限制沿X轴旋转角度
    }

    public float speed = 10;
    private void RotateView(float x, float y)
    {
        x *= speed * Time.deltaTime;
        y *= speed * Time.deltaTime;

        transform.Rotate(-y, 0, 0);
        transform.Rotate(0, x, 0, Space.World); 
    }
 
}
