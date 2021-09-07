using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// </summary>
public class EventDemo : MonoBehaviour, IPointerClickHandler,IDragHandler
{
    public void Fun1()
    {
        Debug.Log("Fun1");
    }
    public void Fun2(string str)
    {
        Debug.Log("Fun2:" + str);
    }

    private void Start1()
    {
        //事件：当满足某种条件自动调用方法的过程。
        //注册事件：将某个方法与某个事件做关联。
        //1.获取相关组件引用
        Button btn = transform.Find("Button").GetComponent<Button>();
        //2.绑定
        //public delegate void UnityAction(); 
        //方法形参：委托类型
        //方法实参：传递方法(无返回值，无参数)
        btn.onClick.AddListener(Fun1);

        var input = transform.Find("InputField").GetComponent<InputField>();
        //public delegate void UnityAction<T0>(T0 arg0);
        //传递无返回值，1个参数的方法
        input.onValueChanged.AddListener(Fun2);
    }
 
    //光标单击当前UI时执行
    public void OnPointerClick(PointerEventData eventData)
    {
        //eventData 事件参数类：包含了引发事件时的信息
        //判断单击次数
        if (eventData.clickCount == 2)
        {
            Debug.Log("OnPointerClick");
        }
    }
    
    //光标拖拽当前UI时执行
    public void OnDrag(PointerEventData eventData)
    {
        //当canvas渲染模式为overlay时，世界坐标原点与屏幕坐标原点重合，
        //所以可以将屏幕坐标视为世界坐标

        //获取当前光标位置(屏幕)
        //transform.position = eventData.position;

        //通用拖拽代码 
        Vector3 worldPos;
        RectTransform parentRTF = transform.parent  as RectTransform;
        //将屏幕坐标  -->  世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPos);
        transform.position = worldPos; 

        //练习：精准拖拽

    }
}