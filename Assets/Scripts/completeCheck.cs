using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class completeCheck : MonoBehaviour
{
    GameObject greenCheckMark;
    GameObject NextStepText;

    

    // Start is called before the first frame update
    void Start()
    {
        greenCheckMark = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Slider>().value >= 1f)
        {
            

            greenCheckMark.SetActive(true);

            transform.GetChild(1).gameObject.SetActive(false);

            
            string currentstep = transform.GetChild(3).gameObject.transform.name;
            transform.parent.parent.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = currentstep + " Completed! \n" + "Tap Here To Proceed...";
            transform.parent.parent.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = true;

            
            if(transform.parent.parent.gameObject.transform.name == "wirelock1-insertBend1-Step1")
            {
                // disable the touch & hold hand animation
                transform.parent.parent.GetChild(3).gameObject.SetActive(false);
            }


            
        }
    }

    
}
