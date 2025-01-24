using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 計算方法：引く
/// </summary>
public class Card_Green_Minus : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => 40;
    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "-";



    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
