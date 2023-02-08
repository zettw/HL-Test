using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendShapeLoop : MonoBehaviour
{

    int blendShapeCount;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int playIndex = 0;
    


    void Start ()
    {
        
    }

    void OnEnable()
    {
        
        

        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();

        skinnedMeshRenderer.enabled = true;

        skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;


        blendShapeCount = skinnedMesh.blendShapeCount; 

        

        
        InvokeRepeating("BlendShapeUpdate", 0, 0.02f);  //zero seconds delay, repeat every 0.02s
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }


    void BlendShapeUpdate() 
    {
        

        skinnedMeshRenderer.SetBlendShapeWeight (playIndex, 100f);

        if (playIndex == 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount - 1,0f);
        }

        if (playIndex > 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(playIndex-1, 0f);
        }
        
        
        if (playIndex < blendShapeCount-1)
        {
            playIndex++;
        }
    }

    void OnDisable()
    {
        CancelInvoke();

        if(skinnedMeshRenderer.GetBlendShapeWeight(blendShapeCount-1) != 100f)
        {
            for (int i = 0; i < blendShapeCount-1; i++)
            {
                skinnedMeshRenderer.SetBlendShapeWeight (i, 0f);
            }

            playIndex = 0;

            skinnedMeshRenderer.SetBlendShapeWeight (0, 100f);

            
        }     

    }

    

    

}
