using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム初期化の後、ゲームの演出後、MainModeに移行する。
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
        GameSceneManager.TurnList.Clear();
        GameSceneManager.Session_Data.Clear();

        //新しく人数を参照して新しくデータを作成する
        switch (GameSceneManager.gameManager.PlayerNum)
        {
            case 2:
                GameSceneManager.Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() },
                    {2,new PlayerSessionData() }
                };
                GameSceneManager.TurnList = new List<int> {
                    1,2
                };
                GameSceneManager.cards = new List<ICard>
                {
                    new Card_Blue_EffectOne(),
                    new Card_Blue_EffectTwo(),
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
                break;
            case 3:
                GameSceneManager.Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() },
                    {2,new PlayerSessionData() },
                    {3,new PlayerSessionData() }
                };
                GameSceneManager.TurnList = new List<int> {
                    1,2,3
                };

                GameSceneManager.cards = new List<ICard>
                {
                    new Card_Blue_EffectOne(),
                    new Card_Blue_EffectTwo(),
                    new Card_Blue_EffectThree(),
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
                break;
            case 4:
                GameSceneManager.Session_Data = new Dictionary<int, PlayerSessionData>
                {
                    {1,new PlayerSessionData() },
                    {2,new PlayerSessionData() },
                    {3,new PlayerSessionData() },
                    {4,new PlayerSessionData() }
                };
                GameSceneManager.TurnList = new List<int> {
                    1,2,3,4
                };

                GameSceneManager.OnLoadSessionData();

                GameSceneManager.cards = new List<ICard>
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
                break;
        }
        GameSceneManager.TurnList = GameSceneManager.Shuffle(GameSceneManager.TurnList);

        
        
        GameSceneManager.sceneContext.Mode_Change(new GameMode_MainMode(GameSceneManager));
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
