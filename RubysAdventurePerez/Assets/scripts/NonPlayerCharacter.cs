using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharcter: MonoBehaviour
{ 
    public float displaytime = 4.0f;
    public GameObject dialogBox;
float timerDispalay;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDispalay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDispalay < 0)
        {
            timerDispalay -= Time.deltaTime;
            if (timerDispalay < 0 )
            {
                dialogBox.SetActive(false );
            }
        }
    }

    public void DisplayDiaLog()
    {
        timerDispalay = displaytime;
        dialogBox.SetActive(true);
    }
}
