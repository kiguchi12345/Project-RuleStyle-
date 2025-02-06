using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Purple_Two : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    /// <summary>
    /// 基準カードの為Null
    /// </summary>
    public float? ProbabilityNum => 40;
    Card_Pattern ICard.card_pattern => Card_Pattern.Purple;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "2";

    
    void ICard.CardNum()
    {
        if (PlayerData != null)
        {
            PlayerData.RuleSuccessNum = 2;
        }
    }
}
