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
        private void OnGUI()
        {
            if (GUILayout.Button("ann"))
            {
                Vector3  Vect = new Vector3(0,5,8);
                this.transform .position=Vect ;
            }
        }
    }
}

