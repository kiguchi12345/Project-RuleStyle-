using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 計算方法：足し算
/// </summary>
public class Card_Green_Plus : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    /// <summary>
    /// 基準カードの為Null
    /// </summary>
    public float? ProbabilityNum => null;
    Card_Pattern ICard.card_pattern => Card_Pattern.Purple;

    string ICard.CardName => "＋";

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
