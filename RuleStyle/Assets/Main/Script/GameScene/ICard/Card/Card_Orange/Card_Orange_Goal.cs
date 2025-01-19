using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// ゴール行ったときの判定カード
/// </summary>
public class Card_Orange_Goal : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "ゴールで";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {
        if(PlayerData != null)
        {
            //PlayerData.
        }
    }

}
