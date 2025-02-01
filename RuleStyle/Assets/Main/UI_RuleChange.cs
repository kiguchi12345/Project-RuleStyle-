using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RuleChange : MonoBehaviour
{
    [SerializeField]
    private UI_RuleComponent PlayerOne;
    [SerializeField]
    private UI_RuleComponent PlayerTwo;
    private UI_RuleComponent PlayerThree;
    private UI_RuleComponent PlayerFour;
}

/// <summary>
/// RuleïœçXâÊñ ÇÃUI
/// </summary>
[Serializable]
public class UI_RuleComponent
{
    public Button PlayerImage;
    public Button Red_Card_EffectPiece;
    public Button Blue_Card;
    public Button Red_Card_EffectAward;
    public Button Yellow_Card;
    public Button Green_Card;
    public Button Purple_Card;


    public TMPro.TextMeshPro RuleText;
}
