using UnityEngine;
using System.Collections;

/// <summary>
/// 门
/// </summary>
public class Door : MonoBehaviour
{
    public bool doorState=false;

    private Animation anim;
    public string animName = "Door";
    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    //当用户按下当前物体Collider时执行
    private void OnMouseDown()
    {
        if (doorState)
        {
            //如果当前动画组件没有播放动画片段 
            if (!anim.isPlaying) anim[animName].time = anim[animName].length;
            //关门 1 -->0
            anim[animName].speed = -1;
        }
        else
        {
            //开门 0-->1
            anim[animName].speed = 1; 
        }
        anim.Play(animName);
        doorState = !doorState;
    }
 
}
