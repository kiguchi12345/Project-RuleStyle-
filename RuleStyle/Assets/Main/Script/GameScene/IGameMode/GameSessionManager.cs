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

    
    /// <summary>
    /// 順番
    /// </summary>
    public List<int> TurnList = new List<int>();

    void Start()
    {
        TurnList.Clear();

        //もう既にアタッチされていることが想定されている為
        instance = this;

        gameManager = GameManager.Instance();


        gameManager.PlayerNum = 4;
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
                return;
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
                return;
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
                return;
        }

        Shuffle(TurnList);
    }

    public void OnLoadSessionData()
    {
        //gameManager.
        Debug.Log(GameManager.Variable_Data);
    }
    private void Update() => sceneContext._currentgameMode?.Update();

    private void FixedUpdate() => sceneContext._currentgameMode?.FixUpdate();

    /// <summary>
    /// 順番シャッフル
    /// </summary>
    public void Shuffle(List<int> array)
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
    }
}
