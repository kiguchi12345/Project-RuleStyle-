using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 駒がステージ外に出たときに発動する
/// </summary>
public class Card_Orange_OverField : ICard
{

    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "場外で";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
