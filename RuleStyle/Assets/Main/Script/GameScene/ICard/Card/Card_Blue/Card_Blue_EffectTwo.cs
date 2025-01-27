using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Blue_EffectTwo : ICard, ICard_Blue
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => 50;
    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "P2の";

    /// <summary>
    /// カードBlueの時のみの実装となる。
    /// </summary>
    public List<int> EffectMember => new List<int> { 2 };

    void ICard.CardNum()
    {
        //PlayerData.EffectPlayer_Id.Add(2);
    }
}
