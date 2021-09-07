using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BaomageCore
{
    public class Find22 : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> n;//创建子物体列表
        public void Find2()
        {
            FindChildInTransform(this.GetComponent<Transform>(), "Cb");
        }
        public Transform FindChildInTransform(Transform parent, string child)//查找子物体的办法（找遍所有物体，符合条件的全部整理出来）
        {
            Transform childTF = parent.Find(child);
            if (childTF != null)
            {
                n.Add(childTF);
                return childTF;
            }
            for (int i = 0; i < parent.childCount; i++)
            {
                childTF = FindChildInTransform(parent.GetChild(i), child);
            }
            return null;
        }
    }
}

