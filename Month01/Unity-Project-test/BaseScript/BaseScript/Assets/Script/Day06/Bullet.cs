using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    //满足碰撞条件  碰撞第一帧执行
    private void OnCollisionEnter(Collision other)
    {
        //other.collider  对方的碰撞器组件引用
        Debug.Log("OnCollisionEnter:"+other.collider);
        //other.contacts[0].point 碰撞点坐标
    }

    //满足触发条件  接触第一帧执行
    private void OnTriggerEnter(Collider other)
    { //other 就是对方碰撞器组件
        Debug.Log("OnTriggerEnter:" + other);
        Destroy(other.gameObject);
        Destroy(gameObject); 
    }

    //如果移动速度过快，将导致碰撞检测失败。
    public float moveSpeed = 100;
    private void Update1()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        Debug.Log(transform.position);
    }

    private RaycastHit hit; 
    public LayerMask layer;
    private Vector3 targetPos;
    //解决方案：
    private void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500, layer))
        { //检测到目标
            targetPos = hit.point;
        }
        else
        {
            //没有目标 
            //targetPos = transform.TransformPoint(0, 0, 500);
            targetPos = transform.position + transform.forward * 500;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if ((transform.position - targetPos).sqrMagnitude < 0.1f)
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject); 
        }
    }
}
