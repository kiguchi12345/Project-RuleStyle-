using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //public PlayerSessionData playerSessionData=new PlayerSessionData();
    // Start is called before the first frame update

    public ICard card ;

    void Start()
    {
       card=new Card_Blue_EffectFour(null);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerSessionData.Card_Blue.Value = new Card_Blue_MySelf(playerSessionData);
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            playerSessionData.Card_Blue.Value = new Card_Blue_Other_than(playerSessionData);
        } ;
        */
    }

    private void OnDestroy()
    {
        Debug.Log("test");
        //playerSessionData.Dispose();
    }
}
