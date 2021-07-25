using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class QuaternionAPI : MonoBehaviour
{
    private void Start()
    {  
        Quaternion qt = transform.rotation;
        //1. 四元数  -->  欧拉角
        Vector3 euler = qt.eulerAngles;
        //2.欧拉角 --> 四元数
        Quaternion qt02 = Quaternion.Euler(0, 90, 0);
        //3.轴 / 角 旋转
        //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //transform.localRotation = Quaternion.AngleAxis(30, Vector3.up);  
    }

    public Transform target;
    private void Update()
    {
        //4. 注视旋转
        //Quaternion dir = Quaternion.LookRotation(target.position - transform.position);
        //transform.rotation = dir;
        //transform.LookAt(target.position);

        //5.Lerp 差值旋转  由快到慢
        //transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.1f);

        //6.RotateTowards    匀速旋转
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, dir, 0.1f);
         
        //Quaternion dir = Quaternion.Euler(0, 180, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.005f);
        ////7. 四元数计算角度差
        //if (Quaternion.Angle(transform.rotation, dir) < 30)
        //    transform.rotation = dir;

        //8. 从？到？的旋转
        transform.rotation = Quaternion.FromToRotation(Vector3.right, target.position - transform.position);
      
    }
 
}
