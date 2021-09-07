using UnityEngine;
using System.Collections;

/// <summary>
/// 向量
/// </summary>
public class VectorDemo : MonoBehaviour
{
    public Transform t1, t2,t3;

    private void Update()
    {
        Demo08();
    }

    //计算向量长度
    private void Demo01()
    {
        Vector3 pos = transform.position;
        float m1 = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));
        float m2 = pos.magnitude;
        print(m1 + "----" + m2);
    }

    //计算向量方向
    private void Demo02()
    {
        Vector3 pos = transform.position;

        Vector3 n1 = pos / pos.magnitude;
        Vector3 n2 = pos.normalized;

        Debug.DrawLine(Vector3.zero, n1, Color.red);
    }

    //向量基本运算
    private void Demo03()
    {
        Vector3 result = t1.position - t2.position;
        //需求：t3 沿着 result 方向移动
        if (Input.GetMouseButtonDown(0))
            //t3.Translate(result.normalized);
            t3.position = t3.position + result.normalized;

        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position);
        Debug.DrawLine(Vector3.zero, result, Color.red);

        //已知向量a  长度为8.3m
        //计算该方向 长度为1.5m的向量
        //解决方案：将ａ向量标准化，　再乘以1.5

    }

    //弧度与角度
    private void Demo04()
    { 
        // f1角度=>f2 弧度： 弧度=角度数*PI/180   
        float f1 = 50;
        float f2 = f1 * Mathf.PI / 180;
        float f3 = f1 * Mathf.Deg2Rad;
        // Mathf.Rad2Deg  弧度  --->  角度 
    }

    //三角函数
    private void Demo05()
    {
        /*
             sin x = a  /  c
             a = c *  sin x;
             c =  a / sin x; 
         */ 
         //已知：角度x  边长 a
         //计算：边长 c
        float x = 50;
        float a = 10;
        float c = a / Mathf.Sin(x * Mathf.Deg2Rad);

        //已知：边长 a  c
        //计算：角度angle
        float angle = Mathf.Asin(a / c) * Mathf.Rad2Deg;

        print(angle);
    }

    //自身坐标  -->  世界坐标
    private void Demo06()
    { 
        Vector3 worldPos = transform.TransformPoint(1, 0, 0); 
        Debug.DrawLine(this.transform.position, worldPos);  

        //transform.forward   
        //transform.up
        //transform.right
    }

    //练习
    private void Demo07()
    { 
        //计算：前右方30度  10米处世界坐标 
        Vector3 localPos =  new Vector3
                                        (
                                            10 * Mathf.Sin(30 * Mathf.Deg2Rad), 
                                            0, 
                                            10 * Mathf.Cos(30 * Mathf.Deg2Rad)
                                        );
        Vector3 worldPos = transform.TransformPoint(localPos);

        Debug.DrawLine(transform.position, worldPos);
    }

    public float angle;
    //向量     向量
    private void Demo08()
    {
        //向量   + - 向量
        //向量   *  / 数
        //向量   (点乘)  (叉乘)    向量
        //

        //参与点乘运算的向量标准化后，结果为夹角的 cos 值
        float dot = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //if (angle > 30)//比较角度
        if (dot < 0.866f)//比较cos值
        {
            //如果夹角大于30度则
        }

        Vector3 cross = Vector3.Cross(t1.position, t2.position);
        if (cross.y <0)
        {
            angle = 360 - angle;
        }

        Debug.DrawLine(Vector3.zero, cross, Color.red);
        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position); 



    }
}
