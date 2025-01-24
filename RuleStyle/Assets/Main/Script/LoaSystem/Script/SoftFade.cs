using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoftFade : MonoBehaviour
{
    [SerializeField]
    Button my;
    [SerializeField]
    RectMask2D mask;

    [SerializeField, Header("完了までの時間")]
    float timeToComplete = 2;
    float timer = 0;

    Vector2 dspsize = new Vector2(Screen.width, Screen.height);

    BitArray bit = new BitArray(4,false);
    private void Awake()
    {
        my.transform.gameObject.SetActive(false);
        Debug.Log("/x:" + mask.padding.x+"/y:" + mask.padding.y + "/z:" + mask.padding.z + "/z:" + mask.padding.w);
        MaskReset();
    }


    public void MaskReset()
    {
        mask.padding = new Vector4(0, dspsize.y, 0,-300);
        my.transform.gameObject.SetActive(false);
    }

    public void NoneMask()
    {
        my.transform.gameObject.SetActive(true);
        mask.padding = new Vector4(0, -300, 0, -300);
    }

    public void StartFade()
    {
        StartCoroutine(OnFade());
    }

    IEnumerator OnFade()
    {
        yield return new WaitForSeconds(1 / 30);
        timer = (timer + Time.deltaTime > timeToComplete) ? timeToComplete : timer + Time.deltaTime;
        bit[2] = (timer == timeToComplete) ? false : true;
        // フェードイン/アウト比率設定
        float fadePerc = Mathf.Abs((timer / timeToComplete) - 1);

        float dis = ((dspsize.y + 300f) * fadePerc) - 300f;

        mask.padding = new Vector4(0, dis, 0, -300);

        if (bit[2])
        {
            StartCoroutine(OnFade());
        }
        else
        {
            my.onClick.AddListener(Onclick);
        }

    }

    void Onclick()
    {
        MaskReset();
        UISceneManager uISceneManager = UISceneManager.Instance();
        uISceneManager.CallAdvent(Call.GameUIchangeCard);

    }

}
