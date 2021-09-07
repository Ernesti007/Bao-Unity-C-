using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 贝塞尔曲线生成器
/// </summary>
public class BezierGenerate : MonoBehaviour
{
    public Transform beginTF;
    public Transform controlTF01;
    public Transform controlTF02;
    public Transform endTF;

    /// <summary>
    /// 创建贝塞尔曲线坐标点
    /// </summary>
    /// <param name="beginPos"></param>
    /// <param name="controlPos01"></param>
    /// <param name="controlPos02"></param>
    /// <param name="endPos"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vector3 CreateBezierCurvePoint(Vector3 beginPos, Vector3 controlPos01, Vector3 controlPos02, Vector3 endPos,float t)
    {
        return beginPos * Mathf.Pow(1 - t, 3) + 3 * controlPos01 * t * Mathf.Pow(1 - t, 2) + 3 * controlPos02 * Mathf.Pow(t, 2) * (1 - t) + endPos * Mathf.Pow(t, 3);
    }

    /// <summary>
    /// 节点
    /// </summary>
    public int nodeCount = 20;

    public List<Vector3> pointList;

    private void Start()
    {
        pointList = new List<Vector3>(nodeCount);

        GeneratePoints();
        DrawCurve();
        CalculateNodeIntervals();
    }

    public void GeneratePoints()
    {
        //计算比例的间隔
        float interval = 1.0f / (nodeCount - 1);
        float t =0;
        for (int i = 0; i < nodeCount; i++)
        {
            Vector3 pos = CreateBezierCurvePoint(beginTF.position, controlTF01.position, controlTF02.position, endTF.position, t);
            pointList.Add(pos);
            t += interval;
        }
    }

    public void DrawCurve()
    {
        var renderer = GetComponent<LineRenderer>();
        renderer.SetVertexCount(pointList.Count);
        renderer.SetPositions(pointList.ToArray());
    }

    //节点间距
    private float[] nodeIntervals;
    private void CalculateNodeIntervals()
    {
        nodeIntervals = new float[nodeCount - 1];
        for (int i = 0; i < nodeIntervals.Length; i++)
        {
            nodeIntervals[i] = Vector3.Distance(pointList[i], pointList[i + 1]);
        } 
    }

    private void CalculateIndexAndRatioByDistance(float distance, out int index, out float ratio)
    {
        float sum = 0;
        for (int i = 0; i < nodeIntervals.Length; i++)
        {
            sum += nodeIntervals[i];
            if (sum >= distance)
            {
                ratio = 1 - (sum - distance) / nodeIntervals[i];
                index = i;
                return;
            }
        }
        //移动距离超过曲线长度
        ratio = -1;
        index = -1;
    }

    public Vector3 GetPoint(float distance)
    {
        int index;
        float ratio;

        CalculateIndexAndRatioByDistance(distance, out index, out ratio);

        if (index == -1) return pointList[pointList.Count - 1];

        return Vector3.Lerp(pointList[index], pointList[index + 1], ratio); 
    }
}
