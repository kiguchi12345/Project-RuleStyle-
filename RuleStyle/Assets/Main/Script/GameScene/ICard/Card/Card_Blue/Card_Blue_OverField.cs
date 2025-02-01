using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using UniRx;

/// <summary>
/// 駒がステージ外に出たときに発動する
/// </summary>
public class Card_Blue_OverField : ICard
{

    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => 45;

    Card_Pattern ICard.card_pattern => Card_Pattern.Blue;

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
            PlayerData.OrangeTrigger=PlayerData.Player_GamePiece.OnTriggerEnterAsObservable()
                .Take(1)//一回で自然にDisposeするようにする。
                .Subscribe(collider =>
                {
                    if (collider.gameObject.GetComponent<OutPosition>() != null)
                    {
                        Debug.Log("場外です");
                        PlayerData.Success();
                    }
                }).AddTo(PlayerData.Player_GamePiece);
        }

    }
}
