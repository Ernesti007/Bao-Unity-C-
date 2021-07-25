using UnityEngine;
using System.Collections;

/// <summary>
/// 生命周期、消息、可重写函数、必然事件
/// </summary>
public class Lifecycle : MonoBehaviour
{
    /*
     c# 类
     {
         字段
         属性
         构造函数
         方法
     } 
  
     脚本
     {
          private/public 字段 
          方法
     } 
      
     */

    //字段直接初始化(在构造函数中进行，调用Unity方法会产生异常)
    //本质：跨线程访问被禁止
    //解决方案：放到Start 或 Awake中
    //private int a = Random.Range(1, 101);
     
    private string a = "abc";

    [Range(1,100)]
    public int b = 10;

    //在编译器中显示当前字段
    [SerializeField]
    private bool c = true;

    //在编译器中隐藏当前字段
    [HideInInspector]
    public float d = 1.0f;

    //***************生命周期*********************
    //Unity脚本 从唤醒 到 最后销毁的过程。
    //必然事件：当满足某种条件自动执行的方法。
    //重点：执行时机、作用、方法名称

   
    //(前提：物体启用、脚本启用)Unity 引擎会在一开始先调用所有对象的Awake  再调用 所有对象的 Start
    //游戏物体加载    --->    立即执行(仅1次)
    //作用：充当构造函数，初始化数据成员。
    //         如果初始化有明确的先后顺序，需要先执行的放到Awake中，后执行的放到Start中
    private void Awake()
    {
        //Debug.Log(this.name + "：Awake：Lifecycle");
    }
    //游戏物体加载   ---> 等待脚本启用  --> 才执行(仅1次)
    private void Start()
    {
        //Debug.Log(this.name + "：Start：" + Time.time); 
    } 
    private void OnMouseDown()
    {
        Debug.Log("执行喽");
    }

    //固定更新
    //固定时间(默认0.02s)  执行 1次
    //作用：对物体执行物理操作(移动、旋转、施加力……)
    //
    private void FixedUpdate()
    {
        //向前移动1m
    } 
    //每渲染帧(大概0.02s)   执行1次
    //作用：执行游戏逻辑
    private void Update()
    {
        //向前移动1m
        
        //查看某一帧程序执行情况
        //启动调试 F5  -->  运行场景  -->  暂停  -->  在可能出错的行加断点  -->  单帧运行 --> 调试……  --> 停止调试 Shift + F5
        int a = 1;
        int b = 2;
        int c = a + b;

    } 
    //延迟更新：在Update之后执行
    //作用：适合执行跟随Update移动的代码
    private void LateUpdate()
    { 
    
    }

 
}
