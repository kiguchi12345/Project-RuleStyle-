using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RuleChange : MonoBehaviour
{
    [SerializeField]
    private Rule_UI_RuleComponent PlayerOne;
    [SerializeField]
    private Rule_UI_RuleComponent PlayerTwo;
    [SerializeField]
    private Rule_UI_RuleComponent PlayerThree;
    [SerializeField]
    private Rule_UI_RuleComponent PlayerFour;


    public void UIChange()
    {
        GameSessionManager manager=GameSessionManager.Instance();

        foreach(var userdata in manager.Session_Data)
        {
            switch (userdata.Key)
            {
                case 1:
                    
                    //PlayerOne.Red_Card_EffectAward=userdata.Value.Card_Blue_EffectAward;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
    /// <summary>
    /// UI変更
    /// </summary>
    /// <param name="UICompo"></param>
    void LoadUI (Rule_UI_RuleComponent UICompo)
    {
       
    }
    /// <summary>
    /// プレイヤーデータを参照にUIにイベントを付けて行く作業
    /// </summary>
    public void AddOnClick(PlayerSessionData playerdata)
    {

    }
}

