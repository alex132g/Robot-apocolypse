using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests
{
   public bool isActive;
    
   public string description;
   
   public int goldReward;

   public QuestGoal goal;

   public void Complete()
   {
      isActive = false;
      Debug.Log("Current Quest Was Complete!");
      goal.currentAmount = 0;
   }
   
}
