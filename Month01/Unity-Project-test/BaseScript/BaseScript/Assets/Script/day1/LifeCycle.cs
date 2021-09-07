using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaomageCore;
/// <summary>
///
/// <summary>
namespace BaomageCore
{
    class LifeCycle : MonoBehaviour
    {
        
        [SerializeField]
        public Transform t;
        private void OnGUI()
        {
            if (GUILayout.Button("test"))
            {
                this.transform.Find("Cube");

                //Transform b= this.transform.Find("Cube");
                //print(b);

                //this.transform.SetParent(t);

                //Transform a = this.transform.root;
                //print(a);

                //this.transform.Translate(0, 2, 3);
                //this.transform.RotateAround(Vector3.zero, Vector3.forward, 30f);
                //this.GetComponent<MeshRenderer>().material.color = Color.red;

                //foreach (Transform item in this.GetComponent <Transform >())
                //{
                //    print(item.name  );
                //}
            }




            //    if (GUILayout.Button("ann"))
            //    {
            //        Vector3  Vect = new(0,5,8);
            //        this.transform .position=Vect ;
            //    }
        }
    }
}

