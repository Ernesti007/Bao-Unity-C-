using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animation ani;
    void Start()
    {
        ani = this.GetComponent<Animation>();
    }
}
