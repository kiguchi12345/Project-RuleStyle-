using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// セッションプレイヤーデータ
/// MonoBehaviorは使わず、Playerの駒にアタッチするスクリプトは別枠で作成する
/// </summary>
public class PlayerSessionData:IDisposable
{
    /// <summary>
    /// カード全て初期化
    /// </summary>
    public void Init()
    {
        gameSessionManager = GameSessionManager.Instance();

        SubScribe();
        Reset_All();
    }

    /// <summary>
    /// キャラクターのカードの情報をリセットする
    /// </summary>
    public void Reset_All()
    {
        Remove_Blue_EffectAward();
        Remove_Orange();
        Remove_Yellow();
        Remove_Green();
        Remove_Red();
    }
    //Remove-色ーー特定色カードを基準カードに初期化
    #region Remove関数

    private void Remove_Blue_EffectPrise()
    {
        Card_Blue_EffectPiece.Value = new Card_Blue_MySelf();
    }
    public void Remove_Blue_EffectAward()
    {
        Card_Blue_EffectAward.Value = new Card_Blue_MySelf();
    }
    public void Remove_Orange()
    {
        Card_Blue_EffectAward.Value= new Card_Orange_Goal();
    }
    public void Remove_Yellow()
    {
        Card_Yellow.Value = new Card_Yellow_Point();
    }
    public void Remove_Green()
    {
        Card_Green.Value = new Card_Green_Plus();  
    }
    public void Remove_Red()
    {
        Card_Red.Value = new Card_Red_One();
    }
    #endregion

    public void Dispose()
    {   
        //判定を作った後の受け皿。
        //これらのDisposeはオブジェクトが破壊されたとしても発生させないようにする。
        ShotEvent?.Dispose();

        //ReactivePropety
        Card_Blue_EffectAward?.Dispose();
        Card_Green?.Dispose();
        Card_Yellow?.Dispose();
        Card_Green?.Dispose();
        Card_Red?.Dispose();
    }

    /// <summary>
    /// 主にカード変更時の処理について
    /// </summary>
    public void SubScribe()
    {
        Card_Blue_EffectPiece
            .Subscribe(_ =>
            {
                _.Card_PlayerChange(this);
                _.CardNum();
            });


        Card_Blue_EffectPiece.Subscribe(_ => { 
            EffectPrisePlayer_Id.Clear();
            _.Card_PlayerChange(this);
            _.CardNum();
            //-------------------------------------------
            //IBlueCardに一度キャストして変換する。
            ICard_Blue blue = (ICard_Blue)_;
            //ここやり方が不安なんだけど問題ないのだろうか
            EffectPrisePlayer_Id = blue.EffectMember;
            //-----------------------------------------------

            Debug.Log("青(適用対象)カード変更");
        });

        Card_Blue_EffectAward
            .Subscribe(_ => {
                EffectAwardPlayer_Id.Clear();
                _.Card_PlayerChange(this);
                _.CardNum();

                //-------------------------------------------
                //IBlueCardに一度キャストして変換する。
                ICard_Blue blue=(ICard_Blue)_;
                //ここやり方が不安なんだけど問題ないのだろうか
                EffectAwardPlayer_Id = blue.EffectMember;
                //-----------------------------------------------

                Debug.Log("青(報酬対象)カード変更");
            });

        //判定カード変更なのでCardNumは行わない。UI変更のみ
        Card_Orange.Subscribe(_ => 
        {
            _.Card_PlayerChange(this);
            Debug.Log("オレンジ(ルール・判定)カード変更");
        });
        //計算方法なのでCardNumは行わない。UI変更のみ
        Card_Green.Subscribe(_ =>
        {
            _.Card_PlayerChange(this);
            Debug.Log("緑(計算方法の変更)カード変更");
        });
        //CardNumは行わない。UI変更のみ
        Card_Yellow.Subscribe(_ => 
        {
            _.Card_PlayerChange(this);
            Debug.Log("黄（得点）カード変更");
        });
        Card_Red.Subscribe(_ =>
        {
            _.Card_PlayerChange(this);
            _.CardNum();
            Debug.Log("赤（数値）カード変更");
        });
    }

    /// <summary>
    /// カードを誰かに変更する時の処理。「これじゃダメだった。ブルーが厳しくなる」
    /// </summary>
    public void GiveCard(ICard card,PlayerSessionData player)
    {
        switch (card.card_pattern)
        {
            case Card_Pattern.Blue:
                //player.Card_Blue_EffectAward.Value = card;
                BlueGiveCard();
                break;
            case Card_Pattern.Orange: 
                player.Card_Orange.Value = card;
                break;
            case Card_Pattern.Yellow: 
                 player.Card_Yellow.Value = card;
                break;
            case Card_Pattern.Green:
                player.Card_Green.Value = card;
                break;
            case Card_Pattern.Red:
                player.Card_Red.Value = card;
                break;
        }
    }
    /// <summary>
    /// 青のカードを誰かに付与する時の特殊関数。（UIに関わってきます。）
    /// </summary>
    public void BlueGiveCard()
    {

    }


    /// <summary>
    /// マネージャー（UI変更等の時の処理
    /// </summary>
    private GameSessionManager gameSessionManager=null;


    /// <summary>
    /// ルール全文
    /// </summary>
    public string Rule { get; }
    
    public int PlayerId;

    public string PlayerName=null;

    /// <summary>
    /// ショット時の判定イベント
    /// </summary>
    public IDisposable ShotEvent = null;
    /// <summary>
    /// Orangeのカードが発生させるショット時判定イベント
    /// </summary>
    public IDisposable OrangeTrigger = null;

    /// <summary>
    /// 効果適用対象
    /// </summary>
    public List<int> EffectPrisePlayer_Id = new List<int>();

    /// <summary>
    /// 報酬対象 
    /// </summary>
    public List<int> EffectAwardPlayer_Id = new List<int>();

    /// <summary>
    /// 手札のカードリスト
    /// </summary>
    public List<ICard> HandCards = new List<ICard>();

    //個人ルール成功時の数字。（赤カードで変更される）
    public int RuleSuccessNum = 0;

    /// <summary>
    /// プレイヤーの点数
    /// </summary>
    public int PlayerPoint=0;

    #region カードの変数

    /// <summary>
    /// どの駒に効果が適応されるかどうか。
    /// </summary>
    public ReactiveProperty<ICard> Card_Blue_EffectPiece = new ReactiveProperty<ICard>();

    /// <summary>
    /// 報酬効果対象のカード
    /// </summary>
    public ReactiveProperty<ICard> Card_Blue_EffectAward = new ReactiveProperty<ICard>();

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

    #endregion


    /// <summary>
    /// プレイヤーの駒(駒を作成時にアタッチする）
    /// </summary>
    public GameObject Player_GamePiece;
    //場外判定
    public bool Death=false;

    /// <summary>
    /// 個人ルール判定成功すればTrue
    /// </summary>
    public bool SuccessPoint=false;

    /// <summary>
    /// 個人ルール成功時の関数
    /// </summary>
    public void Success()
    {
        SuccessPoint = true;
    }

    /// <summary>
    /// ショット時に判定を作る時。
    /// </summary>
    public void ShotPoint()
    {
        //判定作成
        Card_Orange.Value.CardNum();

        //終了時判定を行う
        Player_GamePiece.transform.ObserveEveryValueChanged(x => x.position)
            .Throttle(TimeSpan.FromSeconds(1))
            .Take(1)//一回で自然にDisposeするようにする。
            .Subscribe(x =>
            { 
                Debug.Log("ショット終了");

                if (SuccessPoint)
                {
                    RuleSucces();
                    SuccessPoint = false;
                }
            }) .AddTo(Player_GamePiece);
    }


    /// <summary>
    /// ターン終了時のあれこれ。
    /// </summary>
    public void TurnEnd()
    {

    }

    /// <summary>
    /// 個人ルール成功時のポイント。
    /// </summary>
    public void RuleSucces()
    {
        //個人ルール達成時のリワード
        Card_Yellow.Value.CardNum();
    }
    /// <summary>
    /// ゴール成功時のリワード
    /// </summary>
    public void GoalReward()
    {

    }
    
    /// <summary>
    /// 駒が盤面上に存在しない場合のスクリプト
    /// </summary>
    /// <param name="MyPiece"></param>
    public void PlayerPieceCreate()
    {
        switch (PlayerId) 
        {
        case 1:
                Player_GamePiece=UnityEngine.Object.Instantiate(gameSessionManager.PlayerGameObject_One,gameSessionManager.PieceStartPoint,Quaternion.identity);
                break;
        case 2:
                Player_GamePiece = UnityEngine.Object.Instantiate(gameSessionManager.PlayerGameObject_Two, gameSessionManager.PieceStartPoint, Quaternion.identity);
                break;
        case 3:
                Player_GamePiece = UnityEngine.Object.Instantiate(gameSessionManager.PlayerGameObject_Three, gameSessionManager.PieceStartPoint, Quaternion.identity);
                break;
        case 4:
                Player_GamePiece = UnityEngine.Object.Instantiate(gameSessionManager.PlayerGameObject_Four, gameSessionManager.PieceStartPoint, Quaternion.identity);
                break;
        }
        Death = false;
    }
}