using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// UI拖拽
/// </summary>
public class UIDrag : MonoBehaviour,IPointerDownHandler,IDragHandler
{
    private RectTransform parentRTF;
    private void Start()
    {
        parentRTF = transform.parent as RectTransform;
    }

    private Vector3 downOffset;
    //光标按下时执行
    public void OnPointerDown(PointerEventData eventData)
    {  
        //记录偏移位置
        //屏幕坐标 eventData.position  -->  世界坐标 downWorldPos
        Vector3 downWorldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out downWorldPos);

        downOffset = transform.position - downWorldPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentWorldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out currentWorldPos);
        //拖拽时，在当前光标位置基础上 +  按下时记录的偏移量
        transform.position = currentWorldPos + downOffset;
    }
}
