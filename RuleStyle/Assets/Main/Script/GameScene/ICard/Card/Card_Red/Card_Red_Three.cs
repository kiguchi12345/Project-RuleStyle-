using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Red_Three : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    /// <summary>
    /// 基準カードの為Null
    /// </summary>
    public float? ProbabilityNum => 3;
    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "3";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData != null)
        {
            PlayerData.RuleSuccessNum = 3;
        }
    }
}
