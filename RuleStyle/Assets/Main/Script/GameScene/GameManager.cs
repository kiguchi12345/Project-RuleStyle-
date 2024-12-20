using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :SingletonMonoBehaviourBase<GameManager>
{
    [Header("プレイヤーの人数")]
    public int PlayerNum=0;

    #region プレイヤーのデータ
    public PlayerData playerData_One=null;
    public PlayerData playerData_Two=null;
    public PlayerData playerData_Three = null;
    public PlayerData playerData_Four = null;
    #endregion

    public Dictionary<int, PlayerData> Key_playerdata;

    public List<int> Number=null;

    /// <summary>
    /// クリアする為の点数
    /// </summary>
    public int ClearPoint=0;    
}

public enum GameMode
{
    PlayerOnly
}