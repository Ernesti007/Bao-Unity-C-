using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private Camera fov;
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
    private void Awake()
    {
        fov = this.GetComponent<Camera>();
        fov.fieldOfView = 60;
    }
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
        if ((camera.fieldOfView-zoomLevels[currentLevel])<=0.2f)
        {
            camera.fieldOfView = zoomLevels[currentLevel];
        }
    }
    /// <summary>
    /// 缓慢改变相机的fov
    /// </summary>
    private void Update2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (fov.fieldOfView <= 20)
            {
                InvokeRepeating("CameraPlus", 0, 0.01f);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (fov.fieldOfView >= 60)
            {
                InvokeRepeating("CameraCut", 0, 0.01f);
            }
        }
    }
    private void CameraPlus()
    {
        fov.fieldOfView += 1;
        if (fov.fieldOfView >= 60)
        {
            CancelInvoke("CameraPlus");
        }
    }
    private void CameraCut()
    {
        fov.fieldOfView -= 1;
        if (fov.fieldOfView <= 20)
        {
            CancelInvoke("CameraCut");
        }
    }
    /// <summary>
    /// 直接改变相机的fov
    /// </summary>
    private void Update1()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (this.GetComponent<Camera>().fieldOfView != 20)
            {
                fov.fieldOfView = 20;
            }
            else
            {
                fov.fieldOfView = 60;
            }
        }

    }
}
