using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Blue_EffectOne : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;

    /// <summary>
    /// ÉJÅ[Éhñº
    /// </summary>
    string ICard.CardName => "P1ÇÃ";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {
        PlayerData.EffectPlayer_Id.Add(1);
    }
}
