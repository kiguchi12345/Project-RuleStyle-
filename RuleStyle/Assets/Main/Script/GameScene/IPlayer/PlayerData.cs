using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データ
/// </summary>
[Serializable]
public class PlayerData
{
    /// <summary>
    /// ルール全文
    /// </summary>
    public string Rule { get; }

    /// <summary>
    /// カード要項一つ目
    /// </summary>
    public ICard card_One;
    /// <summary>
    /// カード要項二つ目
    /// </summary>
    public ICard card_Two;

    public ICard card_Three;

    public ICard card_Four;

    public ICard card_Five;
    /// <summary>
    /// プレイヤーの駒
    /// </summary>
    public GameObject Player_GamePiece;
}