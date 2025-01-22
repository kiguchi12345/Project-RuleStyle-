using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using System;

/// <summary>
/// ゴール行ったときの判定カード
/// </summary>
public class Card_Orange_Goal : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public int? ProbabilityNum => null;
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
        if(PlayerData != null)
        {
            //ショットイベントの念のための初期化
            PlayerData.OrangeTrigger?.Dispose();

            //ショットイベント登録
            PlayerData.OrangeTrigger = PlayerData.Player_GamePiece.OnTriggerEnterAsObservable()
                .Take(1)//一回で自然にDisposeするようにする。
                .Subscribe(collider =>
            { 
                if (collider.gameObject.GetComponent<GoalObject>() != null)
                {
                    Debug.Log("ゴール");
                    PlayerData.Success();
                }
            }).AddTo(PlayerData.Player_GamePiece);
        }
    }

}
