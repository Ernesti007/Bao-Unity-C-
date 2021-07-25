using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class RectTransformDemo : MonoBehaviour
{
    public Vector3 localPos;
    public Vector2 size;
    private void Update()
    { 
        //UI 世界坐标（从世界原点 指向 UI 轴心点Pivot向量）
        Vector3 worldPos = transform.position;

        //当前UI轴心点 相对于 父级(UI)轴心点 向量 
        //从父级轴心点 指向 当前UI轴心点 向量
        localPos = transform.localPosition;

        //RectTransform rtf = transform as RectTransform;
        RectTransform rtf = GetComponent<RectTransform>();
        //当前UI 锚点 指向 轴心点的向量
        Vector3 anchoredPos = rtf.anchoredPosition3D;

        //获取3D模型大小
        //Vector3 size = GetComponent<MeshRenderer>().bounds.size;
        //获取UI宽高
        float width = rtf.rect.width;
        float height = rtf.rect.height;

        ////设置UI宽度
        //rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
        ////设置UI高度
        //rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);

        //rtf.sizeDelta = new Vector2(100, 100);
        //当前物体大小 -  锚点大小
        //如果锚点不分开，结果是物体大小
        size = rtf.sizeDelta;

        //RectTransformUtility
    }
 
}
