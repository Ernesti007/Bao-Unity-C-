using UnityEngine;
using System.Collections;

/// <summary>
/// 测试当前物体沿曲线运动
/// </summary>
public class DoMovement : MonoBehaviour
{
    public float distance = 0;
    public float speed = 10;

    private void Update()
    {
        distance += speed * Time.deltaTime;

        transform.position 
            = FindObjectOfType<BezierGenerate>().GetPoint(distance);
    } 
}
