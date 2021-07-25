using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class CharcterMoto : MonoBehaviour
{
    private void FixedUpdate()
    {
        //如果当前位置  坐标 在其他碰撞器内  则执行OnTriggerEnter方法
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
            MovementRotation(hor, ver);
        }
    }

    private void MovementRotation(float hor, float ver)
    {
        var dir = Quaternion.LookRotation(new Vector3(hor, 0, ver));
        transform.rotation = Quaternion.Lerp(transform.rotation, dir, rotateSpeed * Time.deltaTime);
        //transform.rotation = dir;
         
        //transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        //transform.Translate(hor, 0, ver, Space.World);
        transform.Translate(transform.forward * Time.deltaTime * moveSpeed , Space.World);
    } 

    public float rotateSpeed = 10;

    public float moveSpeed = 10;
}
