using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class ItweenDemo : MonoBehaviour
{
    //public iTween.EaseType type;
    public GameObject targetTF;
    public void ItweenMovement()
    {
        //iTween.MoveTo(targetTF, transform.position, 1);

        //缓动插件  DoTween
       // iTween.MoveTo(targetTF, iTween.Hash(
       //     "position", transform.position,
       //     "time", 1,
       //     //"easetype", type,
       //     "oncomplete", "Fun1",
       //     "oncompletetarget",gameObject
       //));
    }

    //动画事件
    private void Fun1()
    {
        print("到了");
    }
}
