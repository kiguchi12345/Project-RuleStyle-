using UnityEngine;
using System;
using UniRx.Triggers;
public class Player_Attach : MonoBehaviour
{
    PlayerSessionData _playerData=null;

    /// <summary>
    /// 削除された時
    /// </summary>
    private void OnDestroy()
    {
        if(_playerData != null)
        {
            _playerData.Death = true;
        }
    }
}
