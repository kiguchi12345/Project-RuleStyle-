using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期化の後、ゲームの演出後、MainModeに移行する。
/// </summary>

public class GameMode_Init :IGameMode
{
    GameSessionManager GameSceneManager;
    public GameMode_Init(GameSessionManager gameSceneManager)
    {
        GameSceneManager = gameSceneManager;
    }

    void IGameMode.Init()
    {
        
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
