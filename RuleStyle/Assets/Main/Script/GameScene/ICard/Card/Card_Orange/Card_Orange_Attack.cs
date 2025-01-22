using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 駒同士がぶつかった時に発動する
/// </summary>
public class Card_Orange_Attack : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public int? ProbabilityNum => 35;

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
        if(PlayerData != null){
            //ショットイベントの念のための初期化
            PlayerData.OrangeTrigger?.Dispose();

            //ショットイベント登録
            PlayerData.OrangeTrigger=PlayerData.Player_GamePiece
                .OnTriggerEnterAsObservable()
                .Take(1)//一回で自然にDisposeするようにする。
                .Subscribe(x => 
                {
                    if (x.gameObject.GetComponent<Player_Attach>() != null)
                    {
                        Debug.Log("アタック判定");
                        PlayerData.Success();
                    }
                }).AddTo(PlayerData.Player_GamePiece);
        }
    }
}
