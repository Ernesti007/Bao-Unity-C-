using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class VectorAPI : MonoBehaviour
{
    private void Start1()
    {
        //因为 position 是属性，所以返回数据副本，直接修改z无效。所以编译错误。
        //transform.position.z = 1;

        //方案1：
        //复制(数据)
        Vector3 pos = transform.position;
        pos.z = 1;//如果仅仅修改位置的副本，物体位置不会发生改变
        transform.position = pos;

        //方案2： 
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);


        //Vector3.Distance(位置1,位置2)        （位置1 - 位置2）.模长 
        //建议  (位置1 - 位置2).模长平方  sqrMagnitude
    }

    public Transform t1;
    private Vector3 tangent;
    private Vector3 binNormal;
    private void Update()
    { 
        Vector3 norm = t1.position;
        ////计算垂直向量
        //Vector3.OrthoNormalize(ref norm, ref tangent, ref binNormal);

        //Debug.DrawLine(Vector3.zero, norm);
        //Debug.DrawLine(Vector3.zero, tangent,Color.red);
        //Debug.DrawLine(Vector3.zero, binNormal, Color.yellow);  

        //计算t1物体在地面上的投影
        Vector3 project = Vector3.ProjectOnPlane(norm, Vector3.up);
        Debug.DrawLine(Vector3.zero, norm);
        Debug.DrawLine(Vector3.zero, project,Color.red);

        //计算反射向量：Vector3.Reflect 
    }

    public Vector3 currentSpeed;
    //移动类API
    private void OnGUI()
    {
        if (GUILayout.RepeatButton("Lerp"))
        {
            //由快到慢      无限接近目标点
            //起点改变    终点、比例不变
            transform.position =
                Vector3.Lerp(transform.position, new Vector3(0, 0, 10), 0.1f);
        }

        if (GUILayout.RepeatButton("MoveTowards"))
        {
            //匀速     无限接近目标点 
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(0, 0, 10), 0.1f);
        }

        if (GUILayout.RepeatButton("SmoothDamp"))
        {
            //平滑阻尼
            transform.position =
                Vector3.SmoothDamp(transform.position, new Vector3(0, 0, 10), ref currentSpeed, 2);
        }

        if (GUILayout.RepeatButton("变速运动"))
        {
            x += Time.deltaTime / time; 
            //由快到慢      无限接近目标点
            //起点 、终点 不变     比例改变
            Vector3 begin = Vector3.zero;
            //transform.position =
            //    Vector3.Lerp(begin, new Vector3(0, 0, 10), curve.Evaluate(x));
            transform.position =
                Vector3.LerpUnclamped(begin, new Vector3(0, 0, 10), curve.Evaluate(x));
        } 
    }

    public AnimationCurve curve;
    private float x;
    public float time =1;

    //练习：物体闪烁
    private void Start()
    {
        Material mt;
        //mt.SetFloat("_Shininess",    ?  );
    }
}
