using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDashController : MonoBehaviour
{
    public DialogManager dialogToTrigger;
    public bool alreadyActivated = false;
    public GameObject pickUpEffect;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !alreadyActivated)
        {
            alreadyActivated = true;
            dialogToTrigger.StartConversation();
            other.GetComponent<MovementController>().canDash = true;
            Instantiate(pickUpEffect, transform.position, pickUpEffect.transform.rotation);
            Destroy(gameObject);
            audioManager.Play("PickUp");
        }
    }
}
