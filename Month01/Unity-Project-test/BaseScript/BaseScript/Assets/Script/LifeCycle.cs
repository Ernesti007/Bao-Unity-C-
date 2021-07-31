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
            if (GUILayout.Button("test"))
            {
                foreach (Transform item in this.GetComponent <Transform >())
                {
                    print(item.name  );
                }
            }




            //    if (GUILayout.Button("ann"))
            //    {
            //        Vector3  Vect = new(0,5,8);
            //        this.transform .position=Vect ;
            //    }
        }
    }
}

