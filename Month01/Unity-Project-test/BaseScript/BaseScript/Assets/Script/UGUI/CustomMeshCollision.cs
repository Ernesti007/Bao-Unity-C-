using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class CustomMeshCollision : Image
{
    //重写IsRaycastLocationValid方法，定义新的事件响应区域
    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        //return base.IsRaycastLocationValid(screenPoint, eventCamera);
        return GetComponent<PolygonCollider2D>().OverlapPoint(screenPoint);
    }
 
}
