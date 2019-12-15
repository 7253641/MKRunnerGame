using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentHightestScore;

    public PlayerData(PlayerHandler player)
    {
        currentHightestScore = player.PlayerScore;
    }
}
