using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public float damTimer;
    public float maxStamina = 100;
    public float currentStamina;
    public float damage = 1;
    public float staminaMultiplier = 2;
    public float regeneration = 5;

    public Stamina stamina;
    public Movement movement;

    public GameObject staminaBar;

    void Update()
   {
       if(Input.GetKey(KeyCode.LeftShift) && currentStamina <= 100 && movement.isGrounded == true)
       {
          if(damTimer <= 0)
          {
             damTimer = 0.3f;
             currentStamina -= damage;
             stamina.SetStamina(currentStamina);
             movement.moveSpeed = 12f;
          }
       }else
       {
          RegenerateStamina();
          movement.moveSpeed = 8f;
       }
       
       if(currentStamina < 100)
       {
          staminaBar.SetActive(true);
       }else
       {
          staminaBar.SetActive(false);
       }
       
       if(currentStamina > maxStamina)
       {
         currentStamina = maxStamina;
       }
      
       if(damTimer >= 0)
       {
          damTimer -= Time.deltaTime;
       }
   }

   void Start()
   {
       currentStamina = maxStamina;
       stamina.SetMaxStamina(maxStamina);
       
   }

   public void RegenerateStamina()
   {
       if(currentStamina < maxStamina)
       {
          currentStamina += staminaMultiplier * Time.deltaTime;
          stamina.SetStamina(currentStamina);
       }
   }

}
