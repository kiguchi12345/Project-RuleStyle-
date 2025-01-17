using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 改変カードを参照する
/// </summary>
public class Card_Yellow_CardDraw : ICard
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_playerSettingData"></param>
    public Card_Yellow_CardDraw(PlayerSessionData _playerSettingData)
    {
        PlayerData = _playerSettingData;
    }

    PlayerSessionData PlayerData;

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

    }
}
