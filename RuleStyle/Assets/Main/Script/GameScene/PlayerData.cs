using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データ
/// </summary>
public class PlayerData
{
    public string Rule { get; }

    /// <summary>
    /// カード要項一つ目
    /// </summary>
    public ICard_One card_One;
    /// <summary>
    /// カード要項二つ目
    /// </summary>
    public ICard_Two card_Two;
}
