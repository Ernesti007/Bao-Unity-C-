using UnityEngine;
using System.Collections;

/// <summary>
/// Component 类 提供了查找组件的功能(从自身、从后代、从先辈)。
/// </summary>
public class ComponentDemo : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("将当前物体颜色设置为红"))
        { 
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("获取当前物体所有组件"))
        {
            var allComponent = GetComponents<Component>();
            foreach (var item in allComponent)
            {
                Debug.Log(item);
            }
        }
        if (GUILayout.Button("获取所有子物体中的MeshRenderer"))
        {
            var allRenderer = GetComponentsInChildren<MeshRenderer>();
            foreach (var item in allRenderer)
            {
                item.material.color = Color.red;
            }
        }
        if (GUILayout.Button("获取所有先辈物体中的MeshRenderer"))
        {
            var allRenderer = GetComponentsInParent<MeshRenderer>();
            foreach (var item in allRenderer)
            {
                item.material.color = Color.red;
            }
        }
    }

    /*
     GetComponent:获取当前物体其他组件类型的引用。
     GetComponents:获取当前物体所有组件引用。
     GetComponentsInChildren：查找指定类型组件(从自身开始，并搜索所有后代)
     GetComponentInChildren：查找指定类型组件(从自身开始，并搜索所有后代，查找到第一个满足条件则结束)
     GetComponentsInParent：查找指定类型组件(从自身开始，并搜索所有先辈)
 
     */
}
