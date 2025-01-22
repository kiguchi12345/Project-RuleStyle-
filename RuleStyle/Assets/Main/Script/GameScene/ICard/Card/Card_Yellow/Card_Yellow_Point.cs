using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 得点を取得する。
/// </summary>
public class Card_Yellow_Point : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    string ICard.CardName => "得点";

    /// <summary>
    /// PlayerData
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData!=null)
        {
            
        }
    }
}
