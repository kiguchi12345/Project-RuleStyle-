using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴール行ったときの判定カード
/// </summary>
public class Card_Orange_Goal : ICard
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_playerSettingData"></param>
    public Card_Orange_Goal(PlayerSessionData _playerSettingData)
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
