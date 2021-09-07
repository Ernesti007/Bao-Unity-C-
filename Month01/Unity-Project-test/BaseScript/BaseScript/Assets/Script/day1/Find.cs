using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaomageCore
{
    public class Find : MonoBehaviour
    {
        [SerializeField]
        private string n;
        public void OnGUI()
        {
            if (GUILayout.Button("find"))
            {
                Find2();
            }
        }
        public void Find2()//任意层级查找对应名字的物体
        {
            List<Transform> ch = new List<Transform>(5);//创建ch子物体缓存列表
            List<Transform> ch2 = new List<Transform>(5);//创建ch2子物体缓存列表(用于两个列表对调循环查找子物体)
            foreach (Transform item in this.GetComponentsInChildren<Transform>())//记录所有子物体到列表里
            {
                ch.Add(item);
            }
            foreach (var item in ch)//在每个子物体里查找
            {
                if (item.transform.Find(n) != null)//找到了
                {
                    print("yes");
                    return;
                }
                else//没找到
                {
                    continue;
                }
            }
            foreach (Transform item in ch)//记录所有子物体到列表里并清除另一个列表
            {
                foreach (Transform item2 in item.GetComponentsInChildren<Transform>())
                {
                    ch2.Add(item2);
                }
                ch.Clear();
            }
            foreach (var item in ch2)//在每个子物体里查找
            {
                if (item.transform.Find(n) != null)//找到了
                {
                    print("yes");
                    return;
                }
                else//没找到
                {
                    continue;
                }
            }
        }

    }
}

