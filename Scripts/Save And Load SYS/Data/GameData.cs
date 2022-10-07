using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentAmount;   

    public bool isActive;
    public bool QuestUIisActive;

    public Vector3 playerPos;
    

    // the values defined in the constructor is the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        // ints
        this.currentAmount = 0;

        // Bools
        this.isActive = false;
        this.QuestUIisActive = false;

        // Vectors
        playerPos = new Vector3(0f, 1f, 0f);
    }
}
