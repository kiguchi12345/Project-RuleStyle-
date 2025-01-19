using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‹î“¯m‚ª‚Ô‚Â‚©‚Á‚½‚É”­“®‚·‚é
/// </summary>
public class Card_Orange_Attack : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    Card_Pattern ICard.card_pattern => Card_Pattern.Orange;

    /// <summary>
    /// ƒJ[ƒh–¼
    /// </summary>
    string ICard.CardName => "‹î‚ª‘Šè‚Ì‹î‚É“–‚½‚é‚±‚Æ‚Å";

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
