using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ゴールポイントにアタッチされているかどうかで判定する
/// （あまりこちらで判定させる想定ではない）
/// </summary>
public class GoalObject : MonoBehaviour
{

    /// <summary>
    /// Debug用
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ゴールに入っています");
    }
}
