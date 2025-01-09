using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カード一つ目
/// </summary>
public interface ICard
{
    public Card_Pattern card_pattern { get; }

    /// <summary>
    /// カードの文章
    /// </summary>
    string CardName { get;}

    /// <summary>
    /// カード効果
    /// </summary>
    void CardNum();
}

/// <summary>
/// パターン
/// </summary>
public enum Card_Pattern
{
    Blue,
    Orange,
    Green,
    Red
}