using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :SingletonMonoBehaviourBase<GameManager>
{

    [SerializeField]
    public int PlayerNum=0;

    /// <summary>
    /// プレイヤーの人数
    /// </summary>
    public PlayerData playerData_One=null;
    public PlayerData playerData_Two=null;
    public PlayerData playerData_Three = null;
    public PlayerData playerData_Four = null;


    public Dictionary<int, PlayerData> Key_playerdata;

    public List<int> Number=null;

    /// <summary>
    /// クリアする為の点数
    /// </summary>
    public int ClearPoint=0;
    /// <summary>
    /// プレイヤーの人数次第
    /// </summary>
    /// <param name="_playernum"></param>
    public void GameInit(int _playernum)
    {
        //キーのデータ挿入
        Key_playerdata=new Dictionary<int, PlayerData> {
            {1,playerData_One },
            {2,playerData_Two },
            {3,playerData_Three },
            {4,playerData_Four }
        };
       
        //プレイヤーのデータの初期化
        //流石に人数毎に作るのはよろしくないので。
        switch (_playernum)
        {
            case 2:
                Number =new List<int>{1,2};

                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                break;
            case 3:
                Number = new List<int> { 1, 2 ,3};

                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                playerData_Three= new PlayerData();
                break;
            case 4:
                Number = new List<int> { 1, 2, 3 };

                playerData_One = new PlayerData();
                playerData_Two = new PlayerData();
                playerData_Three = new PlayerData();
                playerData_Four= new PlayerData();
                break;
            default:
                Debug.Log("エラーが出ています(プレイヤーの人数の異常)");
                break;
        }
    }

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

public enum GameMode
{
    PlayerOnly
}