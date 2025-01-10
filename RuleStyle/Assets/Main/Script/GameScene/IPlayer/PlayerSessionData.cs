using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// セッションプレイヤーデータ
/// MonoBrhaviorは使わず、Playerの駒にアタッチするスクリプトは別枠で作成する
/// </summary>
[Serializable]
public class PlayerSessionData:IDisposable
{
    public PlayerSessionData() {
        Debug.Log("rikai1");
        //Blue.Subscribe(_ => { });
    }
    
    public void Dispose()
    {
        Debug.Log("rikai2");
    }

    /// <summary>
    /// ルール全文
    /// </summary>
    public string Rule { get; }

    /// <summary>
    /// ID
    /// </summary>
    public int PlayerId;

    /// <summary>
    /// ショット時の判定イベント
    /// </summary>
    public IDisposable ShotEvent = null;
    /// <summary>
    /// 得点のイベント
    /// </summary>
    public IDisposable PointEvent = null;

    /// <summary>
    /// 誰に効果を発生させるかの参照リスト
    /// プレイヤー番号で管理する
    /// </summary>
    public List<int> EffectPlayer_Id=new List<int>();

    ReactiveProperty<ICard> Blue;
    /// <summary>
    /// 効果対象のカード
    /// </summary>
    public ReactiveProperty<ICard> card_Blue;
    /// <summary>
    /// 得点の条件
    /// </summary>
    public ReactiveProperty<ICard> card_Orenge;
    /// <summary>
    /// 得点で何を得るのかどうか（カードか得点か）
    /// </summary>
    public ICard card_Yellow;
    /// <summary>
    /// 得点の計算方法
    /// </summary>
    public ICard card_Green;
    /// <summary>
    ///　カードの参照する数を変更する
    /// </summary>
    public ICard card_Red;

    /// <summary>
    /// プレイヤーの駒(駒を作成時にアタッチする）
    /// </summary>
    public GameObject Player_GamePiece;


    public void ShotPoint()
    {
        //判定作成
        card_Orenge.Value.CardNum();

        //終了時判定を行う
        Player_GamePiece.transform.ObserveEveryValueChanged(x => x.position)
            .Throttle(TimeSpan.FromSeconds(1))
            .Subscribe(x =>
            { 
                Debug.Log("ショット終了");
                
                PointEvent.Dispose();
            }) .AddTo(Player_GamePiece);
    }
    
    public void Point()
    {

    }

    
}