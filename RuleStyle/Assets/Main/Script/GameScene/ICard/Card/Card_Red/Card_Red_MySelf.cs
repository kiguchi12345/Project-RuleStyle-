using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 青カード。対象者はカードプレイヤー
/// </summary>
public class Card_Red_MySelf : ICard,ICard_Red
{
    public PlayerSessionData PlayerData { get; set; } = null;

    /// <summary>
    /// 基準カードの影響の為プレイヤーはこのカードを引くことはない（故にNULL）
    /// </summary>
    public float? ProbabilityNum => null;
    Card_Pattern ICard.card_pattern => Card_Pattern.Red;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "自分自身の";

    /// <summary>
    /// カードBlueの時のみの実装となる。
    /// </summary>
    public List<int> EffectMember => new List<int> {};
    /// <summary>
    /// 青は全て返り値で効果を行う
    /// </summary>
    void ICard.CardNum()
    {
        //カードプレイヤー自身にデータを帰属させる（要検討
        //PlayerData.EffectPlayer_Id.Add(PlayerData.PlayerId);

        //カードプレイヤーを対象にする。
        EffectMember.Add(PlayerData.PlayerId);
    }
}
