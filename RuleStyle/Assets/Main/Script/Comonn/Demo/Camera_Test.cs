using UnityEngine;

public class Camera_Test : MonoBehaviour
{
    //カメラの位置
    public Transform Camera;

    /// <summary>
    /// 中心
    /// </summary>
    public Vector3 Cont = new Vector3(0, 0, 0);

    /// <summary>
    /// 変更する数値
    /// </summary>
    public int ChangeMeter = 0;

    public int Dist=10;

    private void Update()
    {
        //上限値に行けば数値を戻す
        if (ChangeMeter >=361)
        {
            ChangeMeter = 0;
        }
        if (ChangeMeter < 0)
        {
            ChangeMeter = 360;
        }
        //数値を変更
        if (Input.GetMouseButton(2))
        {
            ChangeMeter++;
        }
        if (Input.GetMouseButton(1))
        {
            ChangeMeter--;
        }

        //ラジアン変換
        float test=ChangeMeter * Mathf.Deg2Rad;
        //移動するべき地点を算出
        float b = Mathf.Cos(test);
        float a=Mathf.Sin(test);
        //地点作成
        Vector3 t = new Vector3(b*Dist, 10, a*Dist);
        //カメラの位置を変更
        Camera.transform.position = t;
        
        Vector3 direction=Cont - t;
        Debug.Log(direction);
        // カメラの回転を計算
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // X 軸の回転を強制的に設定
        Vector3 eulerRotation = targetRotation.eulerAngles;
        eulerRotation.x = 30f; // 任意の角度に固定、例えば30度
        targetRotation = Quaternion.Euler(eulerRotation);

        // 回転を適用
        Camera.rotation = targetRotation;

    }
}
