using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 椭圆生成器
/// </summary>
public class EllipseGenerate : MonoBehaviour
{ 
  /// <summary>
  /// 创建椭圆坐标
  /// </summary>
  /// <param name="a">长轴长度</param>
  /// <param name="b">短轴长度</param>
  /// <param name="rad">弧度</param>
  /// <returns>坐标</returns>
    public static Vector3 CreatePoint(float a, float b, float rad)
    {
        return new Vector3(a * Mathf.Cos(rad), 0, b * Mathf.Sin(rad));
    }

    /// <summary>
    /// 曲线的节点数量
    /// </summary>
    public int nodeCount = 10;

    /// <summary>
    /// 椭圆角度
    /// </summary>
    public float angle = 360;

    /// <summary>
    /// 长轴
    /// </summary>
    public float a;
    /// <summary>
    /// 短轴
    /// </summary>
    public float b;

    public List<Vector3> pointList;

    /// <summary>
    /// 曲线所有节点总和
    /// </summary>
    public float length;

    private void Start()
    {
        pointList = new List<Vector3>(nodeCount);
        GeneratePoint();
        CalculateNodeInterval();
        CalculateLength();
        DrawCurve();
    }

    /// <summary>
    /// 生成贝塞尔曲线
    /// </summary>
    public void GeneratePoint()
    {
        pointList.Clear();
        //将最大角度转换为最大弧度
        float radMax = angle * Mathf.Deg2Rad;
        //每段占比
        float ratio = radMax / (nodeCount - 1);
        float t = 0;
        for (int i = 0; i < nodeCount; i++)
        {
            Vector3 point = CreatePoint(a, b, t);
            Vector3 worldPoint = this.transform.TransformPoint(point);
            pointList.Add(worldPoint);
            t += ratio;
        }
    }

    //绘制曲线  建议创建单独脚本
    private void DrawCurve()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetVertexCount(pointList.Count);
        line.SetPositions(pointList.ToArray());
    }

    /// <summary>
    /// 获取曲线中坐标
    /// </summary>
    /// <param name="distance">距离</param>
    /// <returns>坐标</returns>
    public Vector3 GetPoint(float distance)
    {
        //1.计算distance在哪段节点(索引) ,以及比例
        //2.计算比例
        int index;
        float ratio;
        CalculateIndexAndRatio(distance, out index, out ratio);

        if (index == -1) return pointList[pointList.Count - 1];

        //3.通过Vector3.Lerp根据比例计算坐标
        return Vector3.Lerp(pointList[index], pointList[index + 1], ratio);
    }

    /// <summary>
    /// 根据比例获取曲线坐标
    /// </summary>
    /// <param name="ratio">比例</param>
    /// <returns></returns>
    public Vector3 GetPoint01(float ratio)
    {
        return GetPoint(ratio * length);
    }

    private float[] nodeIntervals;
    //计算各节点间距
    private void CalculateNodeInterval()
    {
        nodeIntervals = new float[nodeCount - 1];
        for (int i = 0; i < nodeIntervals.Length; i++)
        {
            nodeIntervals[i] = Vector3.Distance(pointList[i], pointList[i + 1]);
        }
    }

    //计算曲线总长度
    private void CalculateLength()
    {
        float sum = 0;
        for (int i = 0; i < nodeIntervals.Length; i++)
        {
            sum += nodeIntervals[i];
        }
        this.length = sum;
    }

    //根据曲线距离，计算节点索引以及比例
    private void CalculateIndexAndRatio(float distance, out int index, out float ratio)//8
    {
        float sum = 0;
        for (int i = 0; i < nodeIntervals.Length; i++)
        {
            sum += nodeIntervals[i];
            if (sum >= distance)
            {
                ratio = 1 - (sum - distance) / nodeIntervals[i];
                index = i;
                return;//退出方法
            }
        }
        //如果移动距离超过所有节点总和
        index = -1;
        ratio = -1;
    }
}
