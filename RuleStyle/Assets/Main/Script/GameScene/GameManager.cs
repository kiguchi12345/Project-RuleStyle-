using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ゲームマネージャー
/// </summary>
public class GameManager : SingletonMonoBehaviourBase<GameManager>
{
    [Header("プレイヤーの人数")]
    public int PlayerNum = 4;

    /// <summary>
    /// 永続データ
    /// </summary>
    public static Dictionary<int, variable_playerdata> Variable_Data { get; private set; }

    public List<int> Number = null;

    /// <summary>
    /// クリアする為の点数
    /// </summary>
    public int ClearPoint = 0;

    /// <summary>
    /// 初期化
    /// </summary>
    [RuntimeInitializeOnLoadMethod()]
    public static void Init()
    {
        Instance().VariableDataInit();
    }

    /// <summary>
    /// プレイヤーのデータを初期化
    /// </summary>
    public void VariableDataInit()
    {
        Variable_Data = new Dictionary<int, variable_playerdata>()
        {
            { 1, new variable_playerdata(1,"Player1") }
            ,
            { 2, new variable_playerdata(2,"Player2") }
            , 
            { 3, new variable_playerdata(3,"Player3") }
            ,
            { 4, new variable_playerdata(4,"Player4") }
        };
    }


}

public enum GameMode
{
    PlayerOnly
}