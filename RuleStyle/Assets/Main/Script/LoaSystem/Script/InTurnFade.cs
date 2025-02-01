using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTurnFade : MonoBehaviour
{
    [SerializeField]
    RectMask2D[] rctMasks;


    Vector2 dspsize = new Vector2(Screen.width, Screen.height);
    float maxTime = 1;

    int num = 3;

    bool conp = false;

    private void Awake()
    {
        MaskReset();
        GameManager gameManager = GameManager.Instance();
        StartCoroutine(FadeNumWait(gameManager.PlayerNum-1));
    }

    /// <summary>
    /// mask‚ðreset‚·‚é
    /// </summary>
    public void MaskReset()
    {
        for (int i = 0; i < rctMasks.Length; i++)
        {
            rctMasks[i].padding = new Vector4(0, (dspsize.y + 300), 0, -300);
        }
    }

    IEnumerator FadeNumWait(int i)
    {
        num = i;
        conp = false;
        Time_TimerManager time_TimerManager = Time_TimerManager.Instance();
        time_TimerManager.Fade(FadeWait, maxTime, FadeSpecified._1to0);

        yield return new WaitUntil(() => conp);
        yield return new WaitForSeconds(0.5f);
        if (i > 0) { StartCoroutine(FadeNumWait((i-1))); }
    }

    void FadeWait(float perc)
    {
        rctMasks[num].padding = new Vector4(0, (dspsize.y + 300) * perc, 0, -300);
        if (perc == 0) { conp = true; }
    }
}
