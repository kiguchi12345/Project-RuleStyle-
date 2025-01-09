using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自分以外
/// </summary>
public class Card_Blue_Other_than : ICard
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_playerSettingData"></param>
    public Card_Blue_Other_than(PlayerSessionData _playerSettingData)
    {
        PlayerData=_playerSettingData;
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

    }
}
