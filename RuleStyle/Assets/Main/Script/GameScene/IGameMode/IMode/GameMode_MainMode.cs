using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_MainMode : IGameMode
{
    GameSessionManager GameSceneManager;

    PlayerSessionData player;

    //カメラの位置
    //public Transform Camera;
    /// <summary>
    /// 中心
    /// </summary>
    public Vector3 Cont = new Vector3(0, 0, 0);
    public int Dist = 10;
    public GameMode_MainMode(GameSessionManager gameSceneManager)
    {
        GameSceneManager = gameSceneManager;
    }

    /// <summary>
    /// 変更する数値
    /// </summary>
    public int ChangeMeter = 0;

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

        //現在のキャラクターの地点
        Cont = player.Player_GamePiece.transform.position;
    }

    /// <summary>
    /// ショット等を作成する。
    /// </summary>
    void IGameMode.Update()
    {
        CameraRole();
    }

    /// <summary>
    /// カメラ制御とカメラの回転
    /// </summary>
    void CameraRole()
    {
        //上限値に行けば数値を戻す
        if (ChangeMeter >= 361)
        {
            ChangeMeter = 0;
        }
        if (ChangeMeter < 0)
        {
            ChangeMeter = 360;
        }
        //数値を変更
        if (Input.GetMouseButton(1))
        {
            ChangeMeter++;
        }
        if (Input.GetMouseButton(2))
        {
            ChangeMeter--;
        }

        //ラジアン変換
        float test = ChangeMeter * Mathf.Deg2Rad;
        //移動するべき地点を算出
        float b = Mathf.Cos(test);
        float a = Mathf.Sin(test);
        //地点作成
        Vector3 t = new Vector3(b * Dist, 10, a * Dist);
        //カメラの位置を変更
        GameSceneManager.CameraPosition.transform.position = t;

        Vector3 direction = Cont - t;
        
        // カメラの回転を計算
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // X 軸の回転を強制的に設定
        Vector3 eulerRotation = targetRotation.eulerAngles;
        eulerRotation.x = 30f; // 任意の角度に固定、例えば30度
        targetRotation = Quaternion.Euler(eulerRotation);

        // 回転を適用
        GameSceneManager.CameraPosition.rotation = targetRotation;

    }

    void IGameMode.FixUpdate()
    {
    }

    void IGameMode.Exit()
    {

    }
}