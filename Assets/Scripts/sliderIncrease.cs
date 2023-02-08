using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderIncrease : MonoBehaviour
{

    Slider _slider; 
    float sliderValue;
    float fillTime = 0f;
    public int blendShapeCount;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    void OnEnable()
    {
        blendShapeCount =  transform.parent.parent.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.blendShapeCount;
        _slider = GetComponent<Slider>();
        _slider.minValue = 0f;
        _slider.maxValue = 1f;
        sliderValue = 0f;

        InvokeRepeating("FillSlider", 0, 0.02f);  //zero seconds delay, repeat every 0.02s
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FillSlider()
    {
        
        _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, fillTime);
 
        fillTime += 1f / blendShapeCount;
    }

    

    public void ResetSlider()
    {
        _slider.value = _slider.minValue;
    }

    void OnDisable()
    {
        CancelInvoke("FillSlider");

        if (_slider.value != _slider.maxValue)
        {
            _slider.value = 0f;
            _slider.minValue = 0f;
            _slider.maxValue = 1f;
            fillTime = 0f;
        }
        
    }
}
