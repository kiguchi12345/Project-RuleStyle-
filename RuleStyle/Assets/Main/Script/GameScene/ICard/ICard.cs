using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カード一つ目
/// </summary>
public interface ICard
{
    public Card_Pattern card_pattern { get; }

    public PlayerSessionData PlayerData { get; set; }

    

    /// <summary>
    /// カードの文章
    /// </summary>
    string CardName { get;}

    /// <summary>
    /// カード効果
    /// </summary>
    void CardNum();

    /// <summary>
    /// カードの所持プレイヤ―の変更
    /// </summary>
    public void Card_PlayerChange(PlayerSessionData player)
    {
        PlayerData = player;
    }
}

/// <summary>
/// パターン
/// </summary>
public enum Card_Pattern
{
    Blue,
    Orange,
    Yellow,
    Green,
    Red
}