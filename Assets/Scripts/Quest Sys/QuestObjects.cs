using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    
    public Quests quest;
    public QuestGoal goal;

 
   void Update()
   {
       if(quest.isActive && Input.GetMouseButtonDown(1))
        {
            quest.goal.ItemGathered();
            if(quest.goal.IsReached())
            {
                //Reward
                quest.Complete();
            }
        }
   }
       
   
}
