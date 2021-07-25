using UnityEngine;
using System.Collections;

/// <summary>
/// Transform 类 提供了查找(根据名字、索引获取子物体)、移动、旋转、缩放物体的功能。
/// </summary>
public class TransformDemo : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("Find"))
        {
            //通过名称获取子物体变换组件引用
            //this.transform.Find("子物体名称")
            //备注：如果通过路径获取物体，那么路径一定不能发生改变
            Transform childTF = this.transform.Find("子物体名称/子物体名称");
            //通过变换组件查找其他类型组件
            childTF.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("获取所有子物体(孙子不要)"))
        {
            //写法1
            int count = transform.childCount;
            for (int i = 0; i < count; i++)
            {
                //根据索引获取子物体
                Transform tf = transform.GetChild(i);
            }
            //写法2
            foreach (var child in transform)
            {
                //child子物体变换组件
            }
        }
        if (GUILayout.RepeatButton("自转"))
        {
            //按下按钮 沿Y轴旋转1度
            transform.Rotate(0, 1, 0);//沿自身坐标轴
            //transform.Rotate(0, 1, 0,Space.World);//沿世界身坐标轴 
        }
        if (GUILayout.RepeatButton("移动"))
        { 
            //移动
            transform.Translate(0, 0, 1);//沿自身坐标轴
            //transform.Translate(0, 1, 0,Space.World);//沿世界身坐标轴 
        }
        if (GUILayout.Button("LookAt"))
        {
            //注视旋转  物体Z轴指向目标位置
            transform.LookAt(targetTF);
        }
        if (GUILayout.RepeatButton("围绕旋转"))
        {
            // （围绕的目标点，围绕的轴向，围绕的角度）
            transform.RotateAround(targetTF.position, Vector3.forward, 1);
        }
        if (GUILayout.RepeatButton("设置父物体"))
        {
            //将当前物体 设置为  targetTF 的子物体
            transform.SetParent(targetTF);
        }
    }

    public Transform targetTF;
    /*
     Transform 类
     -- Variables
          childCount
          localPosition：子物体相对于父物体坐标[编译器中显示的]
          localScale：子物体相对于父物体的缩放比例[编译器中显示的]
          lossyScale：(只读)可以理解为相对于模型的缩放比(父物体.localScale * 自身物体.localScale)
          parent
          position：相对于世界坐标系坐标
          root
     -- Public Functions
          Find ：通过名称查找子物体.
          GetChild：根据索引获取子物体
          LookAt
          Rotate
          RotateAround
          SetParent
          Translate 
     */

}
