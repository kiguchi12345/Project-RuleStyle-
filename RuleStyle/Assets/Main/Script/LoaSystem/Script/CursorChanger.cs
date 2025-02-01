using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorTexture; // カーソル用のテクスチャ
    public Vector2 hotSpot = Vector2.zero; // カーソルのホットスポット

    void Start()
    {
        ChangeCursor();
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursor()
    {
        if (cursorTexture != null)
        {
            // 画像の中央上部をホットスポットに設定
            Vector2 hotSpot = new Vector2(cursorTexture.width / 2, 0);
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
        else
        {
            Debug.LogError("カーソルのテクスチャが設定されていません！");
        }
    }
}
