using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自分以外
/// </summary>
public class Card_Blue_Other_than : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;
    
    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "自分以外の";

    /// <summary>
    /// 青は全て返り値で効果を行う
    /// </summary>
    void ICard.CardNum()
    {
        Debug.Log("カード自分以外");
        GameSessionManager gameManager = GameSessionManager.Instance();
        foreach (var i in gameManager.Session_Data)
        {
            if (i.Key!=PlayerData.PlayerId)
            {
                PlayerData.EffectPlayer_Id.Add(i.Key);
            }
        }
    }
}
