using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 駒同士がぶつかった時に発動する
/// </summary>
public class Card_Orange_Attack : ICard
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_playerSettingData"></param>
    public Card_Orange_Attack(PlayerSessionData _playerSettingData)
    {
        PlayerData = _playerSettingData;
    }

    PlayerSessionData PlayerData;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "駒が相手の駒に当たることで";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
