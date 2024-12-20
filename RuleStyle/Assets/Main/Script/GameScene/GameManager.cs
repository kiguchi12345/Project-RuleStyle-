using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :SingletonMonoBehaviourBase<GameManager>
{

    [SerializeField]
    public int PlayerNum=0;

    /// <summary>
    /// プレイヤーの人数
    /// </summary>
    public PlayerData playerData_One=null;
    public PlayerData playerData_Two=null;
    public PlayerData playerData_Three = null;
    public PlayerData playerData_Four = null;

    /// <summary>
    /// クリアする為の点数
    /// </summary>
    public int ClearPoint=0;
    /// <summary>
    /// プレイヤーの人数次第
    /// </summary>
    /// <param name="_playernum"></param>
    public void GameInit(int _playernum)
    {
        //プレイヤーのデータの初期化
        //流石に人数毎に作るのはよろしくないので。
        switch (_playernum)
        {
            case 2:
                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                break;
            case 3:
                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                playerData_Three= new PlayerData();
                break;
            case 4:
                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                playerData_Three = new PlayerData();
                playerData_Four= new PlayerData();
                break;
            default:
                Debug.Log("エラーが出ています(プレイヤーの人数の異常)");
                break;
        }
    }
}

public enum GameMode
{
    PlayerOnly
}