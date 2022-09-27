using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    
    public Slider slider;
    
   public void SetStamina(float stamina)
   {
       slider.value = stamina;
   }

   public void SetMaxStamina(float stamina)
   {
       slider.maxValue = stamina;
       slider.value = stamina;
   }

}

