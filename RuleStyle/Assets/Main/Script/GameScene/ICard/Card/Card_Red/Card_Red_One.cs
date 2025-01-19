using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Red_One : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// ÉJÅ[Éhñº
    /// </summary>
    string ICard.CardName => "1";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData != null)
        {
            //PlayerData.
        }
    }
}
