using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class GameObjectDemo : MonoBehaviour
{
    /*
     GameObject 类
     -- Variables
     activeInHierarchy ：理解为物体实际激活状态(物体自身被禁用或者父物体被禁用都为false)
     activeSelf：物体在Inspector面板激活状态
     layer
     
     -- Public Functions
     AddComponent：为游戏对象添加组件
     SetActive
     
     -- Static Functions
     * Find ：根据名称查找游戏对象(慎用，如同大海捞针)
     * FindGameObjectsWithTag	：获取使用指定标签的所有物体
     * FindWithTag：获取使用标签的一个物体
     * 
     * Object 类 Static Functions 
     *  
     * 总结：
     * 如何查找某个组件引用
     * Component 类
     *    -- 实例方法
     *    -- 查找当前物体其他类型组件引用
     *    -- 在先辈物体中查找指定类型组件引用
     *    --    后代
     *    
     *  Transform 类
     *     -- 实例方法
     *     -- 通过名称查找子物体
     *     --       索引
     * 
     * GameObject 类
     *     -- 静态方法
     *     -- 通过标签查找物体(单个、所有)
     *     -- 通过名称找物体(慎用)
     *     -- 实例方法
     *     -- 查找当前物体其他类型组件
     *     -- 在先辈物体中查找指定类型组件引用
     *     --    后代
     * 
     * Object 类
     *     -- 静态方法
     *     -- 根据类型查找对象 
     *   
     //练习：(1)代码创建红色的聚光灯
     //         (2)点击按钮启用/禁用指定物体
     * 
     * 作业：查找血量最低的敌人
     */

    public GameObject targetGO;

    private void OnGUI()
    {
        if (GUILayout.Button("代码创建红色的聚光灯"))
        {
            //创建游戏对象
            GameObject go = new GameObject("MyLight");
            //添加灯光组件(创建Ligth类型对象  将引用添加到游戏对象列表中)
            Light light = go.AddComponent<Light>();
            light.type = LightType.Spot;
            light.color = Color.red;
        }
        if (GUILayout.Button("启用/禁用指定物体"))
        {
            targetGO.SetActive(!targetGO.activeInHierarchy);
        }
        if (GUILayout.Button("FindGameObjectsWithTag"))
        {
            //获取所有敌人
            var allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            var playerGO = GameObject.FindWithTag("Player");
        }
        if (GUILayout.Button("FindObjectsOfType"))
        {
            //无论当前组件位于哪个物体，都可以被查找到
            var allRenderer = FindObjectsOfType<MeshRenderer>();
        }
    }
}
