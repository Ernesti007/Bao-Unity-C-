using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>
namespace BaomageTest
{
    class LifeCycle : MonoBehaviour
    {
        [SerializeField]
        private float abcd = 3;
        private void Start()
        {
            int a = 3;
            int b = 6;
            int c = a + b;
        }
    }
}

