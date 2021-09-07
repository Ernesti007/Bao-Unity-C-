using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaomageCore
{
    public class FindHPLowest : MonoBehaviour
    {
        private float lowest;
        public Transform low;
        private  void Start()
        {

            lowest = this.GetComponent<EnemyHP>().HP;
        }
    }
}

