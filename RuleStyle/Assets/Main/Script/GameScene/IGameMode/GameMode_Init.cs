using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_Init :IGameMode
{
    GameSceneManager GameSceneManager;
    public GameMode_Init(GameSceneManager gameSceneManager)
    {
        GameSceneManager = gameSceneManager;
    }

    void IGameMode.Init()
    {
        //キーのデータ挿入
        GameSceneManager.gameManager.Key_playerdata = new Dictionary<int, PlayerData> {
            {1,GameSceneManager.gameManager.playerData_One },
            {2,GameSceneManager.gameManager.playerData_Two },
            {3,GameSceneManager.gameManager.playerData_Three },
            {4,GameSceneManager.gameManager.playerData_Four }
        };

        //プレイヤーのデータの初期化
        //流石に人数毎に作るのはよろしくないので。
        switch (GameSceneManager.gameManager.PlayerNum)
        {
            case 2:
                GameSceneManager.gameManager.Number = new List<int> { 1, 2 };

                GameSceneManager.gameManager.playerData_One = new PlayerData();
                GameSceneManager.gameManager.playerData_Two = new PlayerData();
                break;
            case 3:
                GameSceneManager.gameManager.Number = new List<int> { 1, 2, 3 };

                GameSceneManager.gameManager.playerData_One = new PlayerData();
                GameSceneManager.gameManager.playerData_Two = new PlayerData();
                GameSceneManager.gameManager.playerData_Three = new PlayerData();
                break;
            case 4:
                GameSceneManager.gameManager.Number = new List<int> { 1, 2, 3, 4 };

                GameSceneManager.gameManager.playerData_One = new PlayerData();
                GameSceneManager.gameManager.playerData_Two = new PlayerData();
                GameSceneManager.gameManager.playerData_Three = new PlayerData();
                GameSceneManager.gameManager.playerData_Four = new PlayerData();
                break;
            default:
                Debug.Log("エラーが出ています(プレイヤーの人数の異常)");
                break;
        }

        //順番シャッフル
        GameSceneManager.Shuffle(GameSceneManager.gameManager.Number);
    }

    void IGameMode.Update()
    {
    }
    

    void IGameMode.FixUpdate()
    {
    }

    void IGameMode.Exit()
    {

    }
}
