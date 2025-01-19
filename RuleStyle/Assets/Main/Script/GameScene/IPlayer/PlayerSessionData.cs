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
    public PlayerSessionData() 
    {
        
    }
    /// <summary>
    /// カード全て初期化
    /// </summary>
    public void Init()
    {
        gameSessionManager = GameSessionManager.Instance();
        SubScribe();

        Card_Blue.Value = new Card_Blue_MySelf();
        Card_Orange.Value = new Card_Orange_Goal();
        Card_Yellow.Value = new Card_Yellow_Point();
    }

    public void Dispose()
    {   
        //判定を作った後の受け皿。
        //これらのDisposeはオブジェクトが破壊されたとしても発生させないようにする。
        ShotEvent?.Dispose();
        PointEvent?.Dispose();

        //ReactivePropety
        Card_Blue?.Dispose();
        Card_Green?.Dispose();
        Card_Yellow?.Dispose();
        Card_Green?.Dispose();
        Card_Red?.Dispose();
    }

    public void SubScribe()
    {
        Debug.Log("サブスクライブ");
        //対象なので行う。
        Card_Blue
            .Subscribe(_ => {
                EffectPlayer_Id.Clear();
                _.CardNum();
                Debug.Log("青(対象)カード変更");
            });
        //判定カード変更なのでCardNumは行わない。UI変更のみ
        Card_Orange.Subscribe(_ => 
        {
            Debug.Log("オレンジ(ルール・判定)カード変更");
        });
        //計算方法なのでCardNumは行わない。UI変更のみ
        Card_Green.Subscribe(_ =>
        {
            Debug.Log("緑(計算方法の変更)カード変更");
        });
        //CardNumは行わない。UI変更のみ
        Card_Yellow.Subscribe(_ => 
        {
            Debug.Log("黄（得点）カード変更");
        });


    }

    

    /// <summary>
    /// マネージャー（UI変更等の時の処理
    /// </summary>
    private GameSessionManager gameSessionManager=null;


    /// <summary>
    /// ルール全文
    /// </summary>
    public string Rule { get; }
    /// <summary>
    /// ID
    /// </summary>
    public int PlayerId;

    /// <summary>
    /// プレイヤーネーム
    /// </summary>
    public string PlayerName=null;
    

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



    /// <summary>
    /// 効果対象のカード
    /// </summary>
    public ReactiveProperty<ICard> Card_Blue = new ReactiveProperty<ICard>();

    /// <summary>
    /// 得点の条件(発生は変更時ではないので効果を
    /// Reactiveで発生するものでは無い。
    /// </summary>
    public ReactiveProperty<ICard> Card_Orange=new ReactiveProperty<ICard>();

    /// <summary>
    /// 得点で何を得るのかどうか（カードか得点か）
    /// </summary>
    public ReactiveProperty<ICard> Card_Yellow=new ReactiveProperty<ICard>();

    /// <summary>
    /// 得点の計算方法
    /// </summary>
    public ReactiveProperty<ICard> Card_Green = new ReactiveProperty<ICard>();

    /// <summary>
    ///　カードの参照する数を変更する
    /// </summary>
    public ReactiveProperty<ICard> Card_Red = new ReactiveProperty<ICard>();

    /// <summary>
    /// プレイヤーの駒(駒を作成時にアタッチする）
    /// </summary>
    private GameObject Player_GamePiece;
    //場外判定
    public bool Death=false; 

    public void ShotPoint()
    {
        //判定作成
        Card_Orange.Value.CardNum();

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

    /// <summary>
    /// 
    /// </summary>
    public void PlayerPieceCreate(GameObject MyPiece)
    {

    }
}