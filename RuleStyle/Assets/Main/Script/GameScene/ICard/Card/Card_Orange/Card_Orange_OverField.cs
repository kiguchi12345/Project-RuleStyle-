using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using UniRx;

/// <summary>
/// 駒がステージ外に出たときに発動する
/// </summary>
public class Card_Orange_OverField : ICard
{

    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "場外で";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData != null)
        {
            //ショットイベントの念のための初期化
            PlayerData.OrangeTrigger?.Dispose();

            //ショットイベント登録
            PlayerData.OrangeTrigger = PlayerData.Player_GamePiece
                .OnDestroyAsObservable()
                .Subscribe(x => 
                { 
                    Debug.Log("場外判定"); 
                    //OnDestroyだとゴールとかの判定とか今後に響きそう。。。
                }
                )
                .AddTo(PlayerData.Player_GamePiece);
        }
    }
}
