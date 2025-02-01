using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour
{
    [SerializeField, Header("カーソルを変更する")]
    // カーソル用のテクスチャ
    Texture2D cursorTexture;


    // 点滅時のカーソル画像
    Texture2D blinkTexture;


    // 点滅の間隔（秒）
    float blinkInterval = 0.3f;


    // カーソルのホットスポット clickする位置
    // デフォルトは左上
    Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // 画像の中央上部をホットスポットに設定
        hotSpot = new Vector2(cursorTexture.width / 2, 0);

        // カーソルの点滅用にアルファ値を調整した画像を作成
        blinkTexture = ChangeTextureAlpha(cursorTexture, 0.5f);

        // 初期カーソルを設定
        ChangeCursor();

        StartCoroutine(BlinkCursor());
    }

    /// <summary>
    /// カーソル画像のアルファ値を変更する
    /// </summary>
    /// <param name="texture">元のテクスチャ</param>
    /// <param name="alpha">設定するアルファ値（0.0～1.0）</param>
    /// <returns>アルファ値を変更した新しいテクスチャ</returns>
    Texture2D ChangeTextureAlpha(Texture2D texture, float alpha)
    {
        // 新しいテクスチャを作成
        Texture2D newTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);

        // 全ピクセルの色を取得
        Color[] pixels = texture.GetPixels();

        // 各ピクセルのアルファ値を変更
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i].a *= alpha;
        }

        // 新しいテクスチャに変更を適用
        newTexture.SetPixels(pixels);
        newTexture.Apply();

        return newTexture;
    }

    /// <summary>
    /// カーソルを変更する
    /// </summary>
    public void ChangeCursor()
    {
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
        else
        {
            Debug.LogError("カーソルのテクスチャが設定されていません！");
        }
    }

    /// <summary>
    /// カーソルを点滅させるコルーチン
    /// </summary>
    IEnumerator BlinkCursor()
    {
        // 通常カーソル
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);

        // ボタンobjectにカーソルが重なっているかどうか
        // 確認する関数を呼び出して点滅を開始するか確認している
        yield return new WaitUntil(() => IsCursorOverButton());

        // 待機時間
        yield return new WaitForSeconds(blinkInterval);

        // 点滅カーソル（透明度を下げたもの）
        Cursor.SetCursor(blinkTexture, hotSpot, CursorMode.Auto);
        yield return new WaitForSeconds(blinkInterval);


        // 再帰
        StartCoroutine(BlinkCursor());
        
    }

    /// <summary>
    /// カーソルが指定した UI オブジェクト上にあるか確認する
    /// 今回はボタンに重なっているか確認中
    /// </summary>
    /// <param name="uiObject">チェックする UI の GameObject</param>
    /// <returns>カーソルが UI 上にある場合は true</returns>
    bool IsCursorOverButton()
    {
        // マウスの現在の位置を取得
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // UI の Raycast を取得
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        // カーソルが Button を持つ UI に重なっているか確認
        foreach (var result in results)
        {
            if (result.gameObject.GetComponent<Button>() != null) // Buttonコンポーネントを持っているか
            {
                return true;
            }
        }
        return false;
    }

}
