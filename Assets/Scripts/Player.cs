using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    string axisName = "Horizontal1";
    public float moveSpeed = 10;

    void FixedUpdate()
    {
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);
    }

}
