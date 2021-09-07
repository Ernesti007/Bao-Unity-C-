using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class CameraZoom : MonoBehaviour
{
    //同时按下A   +    B
    private void Update1()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.B))
            Debug.Log("按了");
    }

    private Camera camera;
    private void Start()
    {
        //camera = GetComponent<Camera>();
        camera = Camera.main;//GameObject.FindWithTag("MainCamera")
    }

    private void Update()
    {
        Zoom();
    }

    private bool isFar = true;
    private void Zoom1()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //修改缩放等级
            isFar = !isFar;
            if (isFar)
            {
                //拉远 20  --》 60
                camera.fieldOfView = 60;
            }
            else
            {
                //拉近 60 --》 20
                camera.fieldOfView = 20;
            }
        }
    }

    private void Zoom2()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //修改缩放等级
            isFar = !isFar; 
        } 
        if (isFar)
        {
            //拉远 20  --》 60
            if (camera.fieldOfView < 60)
                camera.fieldOfView += 2;
        }
        else
        {
            //拉近 60 --》 20
            if (camera.fieldOfView > 20)
                camera.fieldOfView -= 2;
        }
    }

    private void Zoom3()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //修改缩放等级
            isFar = !isFar;
        }
        if (isFar)
        {
            //拉远 20  --》 60        Lerp(起点、终点、比例)
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60, 0.1f);
            //Vector3.Lerp
            //Quaternion.Lerp
            //Color.Lerp
        }
        else
        {
            //拉近 60 --》 20
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 20, 0.1f);
        }
    }

    //60    50  40  30    20
    public float[] zoomLevels;
    private int currentLevel;
    private void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //修改缩放等级
            //currentLevel++;
            //currentLevel = currentLevel < zoomLevels.Length - 1 ? currentLevel + 1 : 0;
            currentLevel = (currentLevel + 1) % zoomLevels.Length;
        }
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomLevels[currentLevel], 0.1f); 
    }
}
