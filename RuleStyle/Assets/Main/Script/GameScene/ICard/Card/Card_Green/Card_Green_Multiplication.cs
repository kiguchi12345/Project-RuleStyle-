using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ŒvZ•û–@:Š|‚¯Z
/// </summary>
public class Card_Green_Multiplication : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => 3;
    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    /// <summary>
    /// ƒJ[ƒh–¼
    /// </summary>
    string ICard.CardName => "~";

    Sprite ICard.cardUI { get; set; }

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
