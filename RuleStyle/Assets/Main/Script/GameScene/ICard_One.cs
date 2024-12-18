using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カード一つ目
/// </summary>
public interface ICard_One 
{
    /// <summary>
    /// カードの文章
    /// </summary>
    string CardName { get;}

    /// <summary>
    /// カード効果
    /// </summary>
    void CardNum();
}
