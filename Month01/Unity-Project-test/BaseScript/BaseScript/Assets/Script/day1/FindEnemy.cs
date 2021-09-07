using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaomageCore;

public class FindEnemy : MonoBehaviour
{
    private List<Transform> e = new List<Transform>(5);
    private float lowest = 100;
    public Transform low;
    public void Start()
    {
        FindChildInTransform(this.transform);
        foreach (Transform item in e)
        {
            if (item.GetComponent<EnemyHP>().HP < lowest)
            {
                lowest = item.GetComponent<EnemyHP>().HP;
                low = item.GetComponent<Transform>();
            }
        }
        e.Clear();
    }
    public Transform FindChildInTransform(Transform parent)//查找子物体的办法（找遍所有物体，符合条件的全部整理出来）
    {

        if (parent.CompareTag("Enemy"))
        {
            e.Add(parent.transform);
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            FindChildInTransform(parent.GetChild(i));
        }
        return null;
    }
}


