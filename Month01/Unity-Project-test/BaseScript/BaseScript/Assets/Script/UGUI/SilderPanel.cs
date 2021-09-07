using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// </summary>
public class SilderPanel : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    [Tooltip("拖拽速度")]
    public float dragSpeed = 30;

    private Transform[] childArrayTF;
    private void Start()
    {
        //将所有子物体(亲儿子)变换组件存储到数组中
        childArrayTF = new Transform[transform.childCount];
        for (int i = 0; i < childArrayTF.Length; i++)
        {
            childArrayTF[i] = transform.GetChild(i);
        } 
    }
     
    public void OnDrag(PointerEventData eventData)
    {
        //当前光标位置 - 上一帧光标位置
        //print(eventData.delta);
        transform.Translate(eventData.delta.x * Time.deltaTime * dragSpeed, 0, 0);
    }

    //开始拖拽位置
    private Vector2 beginPoint;
    //开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        beginPoint = eventData.position;
    }
    [Tooltip("滑动速度阈值")]
    public float silderSpeedThreshold = 5;
    public int index;

    private Vector2 beginPos, endPos;
    //结束拖拽时执行
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 dragOffset = eventData.position - beginPoint;
        //更换页面条件：光标移动距离、速度
        if (dragOffset.magnitude > Screen.width / 2 || Mathf.Abs(eventData.delta.x) > silderSpeedThreshold)
        {
            //如果光标向左移动 则页码增加
            if (dragOffset.x < 0)
                //计算页码
                index++;
            else
                index--;
            //限制页码范围
            index = Mathf.Clamp(index, 0, transform.childCount - 1);
        }
        //transform.position = endPos;
        beginPos = transform.position;
        //公式：父UI位置 - 需要呈现页面位置 + 当前物体位置
        endPos = transform.parent.position - childArrayTF[index].position + transform.position;
        x = 0;
    }

    public AnimationCurve curve;
    private float x = 1;
    [Tooltip("滑动持续时间")]
    public float duration = 0.5f;
    private void Update()
    {
        if (x < 1)
        {
            x += Time.deltaTime / duration;
            //起点固定   终点固定  比例变化
            transform.position = Vector3.Lerp(beginPos, endPos, curve.Evaluate(x));
        }
    } 
}
/*
     需求分析：
     1.面板跟随光标移动方向(左右  eventData.delta )移动 transform.Translate(?,0,0)
     2.松开归位
        -- 确定事件
        -- 更换页面条件：光标移动距离、速度
        -- 计算页码
        -- 如何呈现指定页面(计算当前物体SilderPanel需要移动的位置)
        -- 移动
 * 
 * 全屏滑动：
 * 创建 SilderPanel (四个锚点分开)作为所有页面的父物体
 * 创建子页面Panel
 * 
 * 小屏滑动：
 * 创建 PanelView(Panel) 作为呈现范围,添加Mask组件，用于遮盖范围外的UI元素。
 * 将SilderPanel添加至PanelView中
*/
/*
 作业：实现2048用户的输入
 * 
 
 */
