using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// ゲームシーン時、アタッチされている事を想定しています。
/// </summary>
public class GameSessionManager : MonoBehaviour
{
    /// <summary>
    /// ゲームマネージャーにプレイヤー情報を持たせておく必要があるのか？
    /// 解決策。ゲーム的情報はこちらで取得させておくことで
    ///　プレイヤ―ネーム等の情報はゲームマネージャーで設定させておく
    /// </summary>
    public GameManager gameManager;

    #region Static化
    protected static GameSessionManager instance;
    /// <summary>
    /// ゲームシーンマネージャーに接続する為の関数
    /// </summary>
    /// <returns></returns>
    public static GameSessionManager Instance()
    {
        return instance;
    }
    #endregion

    /// <summary>
    /// 現在の操作
    /// </summary>
    public IGameMode gamemode;

    public Dictionary<int, PlayerSessionData> Session_Data = null;

    public GameSceneContext sceneContext = new GameSceneContext();

    #region プレイヤーの駒の変数。
    [SerializeField]
    private GameObject PlayerGameObject_One;

    [SerializeField]
    private GameObject PlayerGameObject_Two;

    [SerializeField] 
    private GameObject PlayerGameObject_Three;

    [SerializeField] 
    private GameObject PlayerGameObject_Four;
    #endregion

    /// <summary>
    /// MainのUI
    /// </summary>
    public Main_UI_Component UI;

    /// <summary>
    /// 順番
    /// </summary>
    public List<int> TurnList = new List<int>();

    void Start()
    {
        TurnList.Clear();

        //もう既にアタッチされていることが想定されている為
        instance = this;
        //
        gameManager = GameManager.Instance();
        
        sceneContext.Mode_Change(new GameMode_Init(this));

        //新しく人数を参照して新しくデータを作成する
        switch (gameManager.PlayerNum)
        {
            case 2:
                Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() },
                    {2,new PlayerSessionData() }
                };
                TurnList = new List<int> {
                    1,2
                };
                break;
            case 3:
                Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() },
                    {2,new PlayerSessionData() },
                    {3,new PlayerSessionData() }
                };
                TurnList = new List<int> {
                    1,2,3
                };
                break;
            case 4:
                Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() }, 
                    {2,new PlayerSessionData() },
                    {3,new PlayerSessionData() },
                    {4,new PlayerSessionData() }
                };
                TurnList = new List<int> {
                    1,2,3,4
                };
                break;
                }
        TurnList = Shuffle(TurnList);

    }
    /// <summary>
    /// カードをドローする。
    /// </summary>
    public void DeckDraw(PlayerSessionData player,int num)
    {
        //全カード
        List<ICard> cards = new List<ICard>
                {
                    new Card_Blue_EffectOne(),
                    new Card_Blue_EffectTwo(),
                    new Card_Blue_EffectThree(),
                    new Card_Blue_EffectFour(),
                    new Card_Blue_Other_than(),
                    new Card_Blue_MySelf(),
                    new Card_Green_Minus(),
                    new Card_Green_Plus(),
                    new Card_Green_Multiplication(),
                    new Card_Orange_Attack(),
                    new Card_Orange_OverField(),
                    new Card_Orange_Goal(),
                    new Card_Red_One(),
                    new Card_Red_Two(),
                    new Card_Red_Three(),
                    new Card_Yellow_CardDraw(),
                    new Card_Yellow_Point()
                };
        //複数回ドローも可能
        for (var i = 0; i < num; i++)
        {
            float Max = 0;
            float Current = 0;

            //確率総和
            foreach (var x in cards)
            {
                if (x.ProbabilityNum != null)
                {
                    Max += (float)x.ProbabilityNum;
                }
            }

            var random = UnityEngine.Random.Range(0, Max);

            bool DrawSuccess = false;
            foreach (var x in cards)
            {
                if (x.ProbabilityNum != null)
                {
                    Current += (float)x.ProbabilityNum;

                    if (Max<Current)
                    {
                        player.HandCards.Add(x);
                        DrawSuccess = true;
                        break;
                    }
                }
            }
            //乱数が総和以上の時末尾要素に
            if (DrawSuccess == false)
            {
                player.HandCards.Add(cards[cards.Count]);
            }
        }
    }



    /// <summary>
    /// GameManagerからGameSessionManagerにデータを代入させていく。
    /// </summary>
    public void OnLoadSessionData()
    {
        //プレイヤー名とプレイヤーIDの代入
        foreach (var i in Session_Data) {
            i.Value.PlayerId=GameManager.Variable_Data[i.Key].Id;
            i.Value.PlayerName = GameManager.Variable_Data[i.Key].PlayerName;
        }
    }
    private void Update() => sceneContext._currentgameMode?.Update();

    private void FixedUpdate() => sceneContext._currentgameMode?.FixUpdate();

    /// <summary>
    /// 順番シャッフル
    /// </summary>
    public List<int> Shuffle(List<int> array)
    {
        for (var i = array.Count - 1; i > 0; --i)
        {
            // 0以上i以下のランダムな整数を取得
            // Random.Rangeの最大値は第２引数未満なので、+1することに注意
            var j = UnityEngine.Random.Range(0, i + 1);

            // i番目とj番目の要素を交換する
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        return array;
    }

    private void OnDestroy()
    {
        Debug.Log("破壊");
        foreach (var t in Session_Data)
        {
            t.Value.Dispose();
        }
    }
}
