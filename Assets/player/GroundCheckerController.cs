using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
