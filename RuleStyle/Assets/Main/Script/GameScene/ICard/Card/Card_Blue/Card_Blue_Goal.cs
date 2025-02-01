using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// ゴール行ったときの判定カード
/// </summary>
public class Card_Blue_Goal : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => null;
    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;

    Image ICard.cardUI { get; set; }
    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "ゴールで";

    void ICard.CardNum()
    {
        if(PlayerData != null)
        {
            //ショットイベントの念のための初期化
            PlayerData.BlueTrigger?.Dispose();

            //ショットイベント登録
            PlayerData.BlueTrigger = PlayerData.Player_GamePiece.OnTriggerEnterAsObservable()
                .Take(1)//一回で自然にDisposeするようにする。
                .Subscribe(collider =>
            { 
                if (collider.gameObject.GetComponent<GoalObject>() != null)
                {
                    PlayerData.Success();
                }
            }).AddTo(PlayerData.Player_GamePiece);
        }
    }
}
