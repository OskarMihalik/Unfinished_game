using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorthlessSecretTrigger : MonoBehaviour
{
    public DialogManager dialogToTrigger;
    public bool alreadyActivated = false;
    public GameObject pickUpEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !alreadyActivated)
        {
            alreadyActivated = true;
            dialogToTrigger.StartConversation();
            Instantiate(pickUpEffect, transform.position, pickUpEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
