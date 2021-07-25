using UnityEngine;
using System.Collections;

/// <summary>
/// 切点探测器
/// </summary>
public class TangentDetector : MonoBehaviour
{
    private Vector3 leftTangent;
    private Vector3 rightTangent;

    private Transform playerTF;
    private float radius;
    private void Start()
    {
        GameObject playerGO  = GameObject.FindWithTag("Player");
        if (playerGO != null)
        {
            playerTF = playerGO.transform;
            radius = playerGO.GetComponent<CapsuleCollider>().radius;
        }
        else
        {
            this.enabled = false;
        }
    }

    public void CalaculateTangent()
    {
        Vector3 playerToExplosion = transform.position - playerTF.position;
        Vector3 playerToExplosionRadius = playerToExplosion.normalized * radius;
        float angle = Mathf.Acos(radius / playerToExplosion.magnitude) * Mathf.Rad2Deg;
        rightTangent =playerTF .position + Quaternion.Euler(0, angle, 0) * playerToExplosionRadius;
        leftTangent = playerTF.position + Quaternion.Euler(0, -angle, 0) * playerToExplosionRadius;
    }

    //**************测试**************
    private void Update()
    {
        CalaculateTangent();

        Debug.DrawLine(transform.position, leftTangent);
        Debug.DrawLine(transform.position, rightTangent);
    }
}
