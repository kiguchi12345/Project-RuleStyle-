using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DragLine : MonoBehaviour
{
    public ReactiveProperty<bool> dragged=new ReactiveProperty<bool>(false);

    public Vector3 position;

    public GameObject dragObject;
    public Rigidbody rb;


    public Vector3 dragOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = dragObject.GetComponent<Rigidbody>();

        dragged.Where(_ => _==true).Subscribe(_ => {
            position=Input.mousePosition;
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        Line();
    }

    public void Line()
    {
        if (Input.GetMouseButton(1))
        {
            dragged.Value = true;

            //ドラッグ開始からの差値のベクトル
            Vector3 direction =Input.mousePosition - position ;
            //距離を求める
            //Debug.Log(direction.magnitude);

            //ラジアン角度抽出
            var rad=Mathf.Atan2(direction.y,direction.x);
            Debug.Log(rad);

            float x=Mathf.Cos(rad);
            float z=Mathf.Sin(rad);
            
            //ベクトル作成
            dragOffset = new Vector3(x,0,z);

            //長さが200以降だった場合
            if (direction.magnitude > 10)
            {
                Debug.DrawLine(dragObject.transform.position, new Vector3(dragOffset.x*10,1,dragOffset.z*10), Color.black);
            }
            //長さが200以前だった場合
            else
            {
                Debug.DrawLine(dragObject.transform.position, new Vector3(dragOffset.x * direction.magnitude, 1, dragOffset.z * direction.magnitude), Color.black);
            }
            
        }
        //離した時
        else if (dragged.Value==true)
        {
            dragged.Value = false;
            
            rb.AddForce(dragOffset*10,ForceMode.Impulse);
        }
    }
}
