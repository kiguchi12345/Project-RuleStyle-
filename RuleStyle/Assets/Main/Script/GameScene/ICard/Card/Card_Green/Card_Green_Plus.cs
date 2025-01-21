using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Green_Plus : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    string ICard.CardName => "得点カード";

    /// <summary>
    /// PlayerData
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData != null)
        {

        }
    }
}
