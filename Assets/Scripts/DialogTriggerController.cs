using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerController : MonoBehaviour
{
   public DialogManager dialogToTrigger;
   public bool alreadyActivated = false;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player") && !alreadyActivated)
      {
         alreadyActivated = true;
         dialogToTrigger.StartConversation();
      }
   }
}
