using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// “¾“_‚ğæ“¾‚·‚éB
/// </summary>
public class Card_Yellow_Point : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public int? ProbabilityNum => null;
    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    string ICard.CardName => "“¾“_";

    /// <summary>
    /// PlayerData
    /// </summary>
    void ICard.CardNum()
    {
        if (PlayerData!=null)
        {
            
        }
    }
}
