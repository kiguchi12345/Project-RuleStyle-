using UnityEngine;

public class Player_Attach : MonoBehaviour
{
    public PlayerSessionData _playerData=null;

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
