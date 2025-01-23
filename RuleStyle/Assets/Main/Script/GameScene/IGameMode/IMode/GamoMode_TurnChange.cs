using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_TurnChange : IGameMode
{
     
   
        GameSessionManager GameSceneManager;
        public GameMode_TurnChange(GameSessionManager gameSceneManager)
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
