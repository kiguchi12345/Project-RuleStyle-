using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_MainMode : IGameMode
{
    GameSessionManager GameSceneManager;

    PlayerSessionData player;
    public GameMode_MainMode(GameSessionManager gameSceneManager)
    {
        GameSceneManager = gameSceneManager;
    }



    /// <summary>
    /// ここで次のプレイヤーの情報を入れる
    /// </summary>
    void IGameMode.Init()
    {
        player=GameSceneManager.NowPlayer();

        //盤面上に存在しない場合。
        if (player.Player_GamePiece==null)
        {
            player.PlayerPieceCreate();
        }


    }

    /// <summary>
    /// ショット等を作成する。
    /// </summary>
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
