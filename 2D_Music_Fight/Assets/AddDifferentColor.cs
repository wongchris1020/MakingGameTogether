using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDifferentColor : MonoBehaviour
{
    public float speed;
    public Gradient gradient;
    float startTime;
    public List<Transform> Objs;
    void Start()
    {

        StartCoroutine(ChangeEngineColour());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ChangeEngineColour()
    {
        Debug.Log(Objs);
        float tick = 0f;
        while(true)
		{
            foreach (Transform Tform in Objs)
            {
                
                tick += Time.maximumDeltaTime * speed;
                Tform.GetComponent<Renderer>().material.color = gradient.Evaluate(tick);
                yield return null;
                //yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
            if(tick>=1)
			{
                tick = 0;
			}
        }
    }

    private IEnumerator ChangeSingleColourOnce()
    {
        Debug.Log(Objs);
        while (true)
        {

            foreach (Transform Tform in Objs)
            {
                float tick = 0f;
                while (tick <= 1)
                {
                    tick += Time.maximumDeltaTime * speed;
                    Tform.GetComponent<Renderer>().material.color = gradient.Evaluate(tick);
                    yield return null;
                    //yield return new WaitForSeconds(0.1f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
