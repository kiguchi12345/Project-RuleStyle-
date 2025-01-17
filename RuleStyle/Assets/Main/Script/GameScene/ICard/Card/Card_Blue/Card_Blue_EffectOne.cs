using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Blue_EffectOne : ICard
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_playerSettingData"></param>
    public Card_Blue_EffectOne(PlayerSessionData _playerSettingData)
    {
        PlayerData = _playerSettingData;
    }

    PlayerSessionData PlayerData;

    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "Other_than";

    /// <summary>
    /// 青は全て返り値で効果を行う
    /// </summary>
    void ICard.CardNum()
    {
        Debug.Log("カード自分以外");
    }
}
