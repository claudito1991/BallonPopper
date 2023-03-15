using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallonControler : MonoBehaviour
{
    public static Action BallonPoped;
    [SerializeField]
    int clicksToPop = 3;
    [SerializeField]
    int currentClicks=0;

    [SerializeField]
    GameObject particleSystem;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    void OnMouseDown()
    {
        currentClicks +=1;
        transform.localScale += new Vector3(0.2f,0.2f,0.2f);
        Debug.Log(currentClicks);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentClicks == clicksToPop)
        {
            BallonPoped?.Invoke();
            //Destroy(gameObject);
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            particleSystem.SetActive(true);
            Destroy(this);
        
        }
    }

}
