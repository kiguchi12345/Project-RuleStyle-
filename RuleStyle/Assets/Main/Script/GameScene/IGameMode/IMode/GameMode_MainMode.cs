using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameMode_MainMode : IGameMode
{
    GameSessionManager GameSceneManager;

    PlayerSessionData player;

    #region カメラコンポーネント
    /// <summary>
    /// 中心
    /// </summary>
    public Vector3 Cont = new Vector3(0, 0, 0);
    public float Dist = 3f;
    #endregion

    public ReactiveProperty<bool> dragged = new ReactiveProperty<bool>(false);

    private Vector3 position;
    private Rigidbody rb;
    private Vector3 dragOffset;

    public GameMode_MainMode(GameSessionManager gameSceneManager)
    {
        GameSceneManager = gameSceneManager;
    }

    /// <summary>
    /// 変更する数値
    /// </summary>
    public float ChangeMeter = 0;

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
        Cont.y = 0;


        rb=player.Player_GamePiece.GetComponent<Rigidbody>();
        dragged.Where(_ => _ == true).Subscribe(_ => {
            position = Input.mousePosition;
        }).AddTo(player.Player_GamePiece);
    }

    /// <summary>
    /// ショット等を作成する。
    /// </summary>
    void IGameMode.Update()
    {
        CameraRole();

        Line();
    }

    void CameraRole()
    {
        // 上限値に行けば数値を戻す
        if (ChangeMeter >= 361)
        {
            ChangeMeter = 0;
        }
        if (ChangeMeter < 0)
        {
            ChangeMeter = 360;
        }

        // 数値を変更
        if (Input.GetMouseButton(2))
        {
            ChangeMeter += 0.3f;
        }
        if (Input.GetMouseButton(1))
        {
            ChangeMeter -= 0.3f;
        }

        //現在のキャラクターの地点
        Cont = player.Player_GamePiece.transform.position;
        Cont.y = 0;

        // ラジアン変換
        float test = ChangeMeter * Mathf.Deg2Rad;
        // 移動するべき地点を算出
        float b = Mathf.Cos(test);
        float a = Mathf.Sin(test);
        // 地点作成
        Vector3 t = new Vector3(b * Dist, 3f, a * Dist);
        // カメラの位置を変更
        GameSceneManager.CameraPosition.transform.position = t + Cont;

        // プレイヤーの方向を向かせる
        GameSceneManager.CameraPosition.transform.LookAt(player.Player_GamePiece.transform);

        // 特定のX軸角度を設定（例えば30度）
        float fixedXRotation = 30f;

        // 現在の回転を取得
        Vector3 fixedRotation = GameSceneManager.CameraPosition.transform.rotation.eulerAngles;

        // X軸回転を固定（特定の値に設定）
        fixedRotation.x = fixedXRotation;

        // Y軸とZ軸の回転を維持しつつ、X軸だけ更新
        GameSceneManager.CameraPosition.transform.rotation = Quaternion.Euler(fixedRotation);
    }
    /*
    public void Line()
    {
        Vector3 cameraoffset = player.Player_GamePiece.transform.position - GameSceneManager.CameraPosition.transform.position;
        if (Input.GetMouseButton(0))
        {
            dragged.Value = true;

            //ドラッグ開始からの差値のベクトル
            Vector3 direction = Input.mousePosition - position;
            

            //ラジアン角度抽出
            var rad = Mathf.Atan2(direction.y, direction.x);
            Debug.Log(rad);

            float x = Mathf.Cos(rad);
            float z = Mathf.Sin(rad);

            //ベクトル作成
            dragOffset = new Vector3(x, 0, z);

            
            //長さが10以降だった場合
            if (direction.magnitude > 10)
            {
                Debug.DrawLine(player.Player_GamePiece.transform.position, new Vector3(dragOffset.x * 10, 1, dragOffset.z * 10), Color.black);
            }
            //長さが10以前だった場合
            else
            {
                Debug.DrawLine(player.Player_GamePiece.transform.position, new Vector3(dragOffset.x * direction.magnitude, 1, dragOffset.z * direction.magnitude), Color.black);
            }

        }
        //離した時
        else if (dragged.Value == true)
        {
            dragged.Value = false;

            rb.AddForce(dragOffset * 27, ForceMode.Impulse);
        }
    }*/
    public void Line()
    {
        Vector3 cameraOffset = player.Player_GamePiece.transform.position - GameSceneManager.CameraPosition.transform.position;

        if (Input.GetMouseButton(0))
        {
            dragged.Value = true;

            // ドラッグ開始からの差分のベクトル
            Vector3 direction = Input.mousePosition - position;

            // ラジアン角度を計算
            var rad = Mathf.Atan2(direction.y, direction.x);
            Debug.Log(rad);

            // カメラの方向を基準にしたベクトルを作成
            // カメラの前方向と右方向を取得
            Vector3 cameraForward = GameSceneManager.CameraPosition.transform.forward;
            cameraForward.y = 0; // 垂直方向は無視
            cameraForward.Normalize(); // 正規化

            Vector3 cameraRight = GameSceneManager.CameraPosition.transform.right;
            cameraRight.y = 0; // 垂直方向は無視
            cameraRight.Normalize(); // 正規化

            // カメラの前方と右方向を基にドラッグ方向を設定
            Vector3 dragDirection = cameraForward * Mathf.Sin(rad) + cameraRight * Mathf.Cos(rad);

            // ベクトル作成
            dragOffset = dragDirection;

            // 長さが10以降だった場合
            if (direction.magnitude > 10)
            {
                Debug.DrawLine(player.Player_GamePiece.transform.position, new Vector3(dragOffset.x * 10, 1, dragOffset.z * 10), Color.black);
            }
            // 長さが10以前だった場合
            else
            {
                Debug.DrawLine(player.Player_GamePiece.transform.position, new Vector3(dragOffset.x * direction.magnitude, 1, dragOffset.z * direction.magnitude), Color.black);
            }
        }
        // 離した時
        else if (dragged.Value == true)
        {
            dragged.Value = false;

            // 移動量を加える
            rb.AddForce(-dragOffset * 27, ForceMode.Impulse);
        }
    }

    void IGameMode.FixUpdate()
    {
    }

    void IGameMode.Exit()
    {

    }
}