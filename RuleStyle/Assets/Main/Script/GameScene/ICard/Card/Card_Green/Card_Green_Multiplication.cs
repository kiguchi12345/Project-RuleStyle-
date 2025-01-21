using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Green_Multiplication : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    /// <summary>
    /// ÉJÅ[Éhñº
    /// </summary>
    string ICard.CardName => "Å~";



    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
