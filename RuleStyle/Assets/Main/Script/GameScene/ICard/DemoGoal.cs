using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using System.Linq;
using System;

/// <summary>
/// ゴール用の
/// </summary>
public class Goal : MonoBehaviour
{
    IDisposable dispose;

    void Card()
    {
        dispose=this.OnTriggerEnterAsObservable()
            .Subscribe(collider => {
                //
                if (collider.gameObject.GetComponent<GoalObject>()!=null)
                {
                    Debug.Log("ゴール！！！");
                }
            }).AddTo(this);
    }

    private void Start()
    {
        Card();
    }
}
