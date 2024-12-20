using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームシーン時、アタッチされている事を想定しています。
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    public GameManager gameManager;

    /// <summary>
    /// 現在の操作
    /// </summary>
    public IGameMode gamemode;

    public GameSceneContext sceneContext = new GameSceneContext();
    void Start()
    {
        gameManager = GameManager.Instance();
        gameManager.PlayerNum = 4;
        sceneContext.Mode_Change(new GameMode_Init(this));
    }


    private void Update() => sceneContext._currentgameMode?.Update();

    private void FixedUpdate() => sceneContext._currentgameMode?.FixUpdate();

    /// <summary>
    /// 順番シャッフル
    /// </summary>
    public void Shuffle(List<int> array)
    {
        for (var i = array.Count - 1; i > 0; --i)
        {
            // 0以上i以下のランダムな整数を取得
            // Random.Rangeの最大値は第２引数未満なので、+1することに注意
            var j = Random.Range(0, i + 1);

            // i番目とj番目の要素を交換する
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
