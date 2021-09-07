using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class PlayerController : MonoBehaviour 
{
    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
            Movement(hor, ver);
    }

    public float moveSpeed = 10;
    private void Movement(float hor,float ver)
    {
        hor *= moveSpeed * Time.deltaTime;
        ver *= moveSpeed * Time.deltaTime;

        //限制
        Vector3 screentPos = Camera.main.WorldToScreenPoint(transform.position);

        //如果移动到最下边 并且 还想向下   或者  移动到最上边 并且 还想向上
        if (screentPos.y <= 0 && ver < 0 || screentPos.y >= Screen.height && ver >0)
            ver = 0;//停

        this.transform.Translate(hor, 0, ver);
    }

}
