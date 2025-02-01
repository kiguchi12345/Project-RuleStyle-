using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTurnFade : MonoBehaviour
{
    [SerializeField]
    RectMask2D[] rctMasks; // 複数のRectMask2Dコンポーネントを保持する配列

    Vector2 dspsize = new Vector2(Screen.width, Screen.height); // 画面サイズ
    float maxTime = 0.05f; // フェードの最大時間
    float waitTime = 0.01f; // フェード事の待機時間

    int num = 3; // フェードするMaskのインデックス
    bool conp = false; // フェード完了フラグ

    private void Awake()
    {
        MaskReset(); // Maskを初期化
        GameManager gameManager = GameManager.Instance(); // ゲームマネージャのインスタンスを取得
        StartCoroutine(FadeNumWait(gameManager.PlayerNum - 1)); // プレイヤーの数に応じたフェード開始
    }

    /// <summary>
    /// RectMask2Dのpaddingをリセットする
    /// </summary>
    public void MaskReset()
    {
        // すべてのRectMask2Dのpaddingを画面外に設定
        for (int i = 0; i < rctMasks.Length; i++)
        {
            rctMasks[i].padding = new Vector4(0, (dspsize.y + 300), 0, -300); // 上下に画面サイズ + 300の余白を追加
        }
    }

    /// <summary>
    /// フェードを順番に待機して処理するコルーチン
    /// </summary>
    /// <param name="i">現在のプレイヤーインデックス</param>
    IEnumerator FadeNumWait(int i)
    {
        yield return new WaitForSeconds(0.5f); // 少し待機（0.5秒）
        num = i; // プレイヤー数に基づいてインデックスを設定
        conp = false; // フェード完了フラグをリセット
        Time_TimerManager time_TimerManager = Time_TimerManager.Instance(); // 時間管理マネージャを取得

        // フェード処理を呼び出し、完了を待機
        time_TimerManager.Fade(FadeWait, maxTime, FadeSpecified._1to0);

        // フェードが完了するまで待機
        yield return new WaitUntil(() => conp);

        // プレイヤー数が1より大きければ、次のインデックスで再度フェードを実行
        if (i > 0) { StartCoroutine(FadeNumWait((i - 1))); }
    }

    /// <summary>
    /// フェード時に呼び出されるコールバック関数
    /// </summary>
    /// <param name="perc">フェード進行状況（0～1）</param>
    void FadeWait(float perc)
    {
        // RectMask2Dのpaddingを進行状況に応じて変更（フェードを表示）
        rctMasks[num].padding = new Vector4(0, (dspsize.y + 300) * perc, 0, -300);

        // フェードが終了した場合、完了フラグをtrueに設定
        if (perc == 0) { conp = true; }
    }
}
