using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDifferentColor : MonoBehaviour
{
    public float speed;
    public float ColorChangeIndex;
    public Gradient gradient;
    float startTime;
    public List<Transform> Objs;

    public AnimationCurve animationCurve;

    void Start()
    {
        //ssasds
        StartCoroutine(ChangeEngineColour());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ChangeEngineColour()
    {
        float tick = 0f;
        bool revise = false;
        float Timer = 0f;
        while (true)
		{
            float ObjectIndex = 0;
            foreach (Transform Tform in Objs)
            {
                ObjectIndex += 1/ ColorChangeIndex;
                tick = ObjectIndex;
                if (tick >= 1)
                {
                    tick -= 1;
                }
                //tick += Mathf.Abs(Mathf.Sin(Time.time*speed
                Timer = Time.time*speed % 1;
                tick += Mathf.Abs(animationCurve.Evaluate(Timer));
                if (tick >= 1)
                {
                    tick -= 1;
                }
                #region
                //            if(tick<=1 && revise==false)
                //{
                //                tick += Time.maximumDeltaTime * speed;
                //                revise = false;
                //}
                //            else if(tick>= 0)
                //{
                //                tick -= Time.maximumDeltaTime * speed;
                //                revise = true;
                //}
                //else
                //{
                //                revise = false;
                //            }
                #endregion
                Tform.GetComponent<Renderer>().material.color = gradient.Evaluate(tick);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    #region randomColorSingleLine
    private IEnumerator randomColorSingleLine()
    {
        float tick = 0f;
        bool revise = false;
        while (true)
        {
            Debug.Log(tick);
            Debug.Log(revise);
            foreach (Transform Tform in Objs)
            {
                tick = Mathf.Abs(Mathf.Sin(Time.time));
                #region
                //            if(tick<=1 && revise==false)
                //{
                //                tick += Time.maximumDeltaTime * speed;
                //                revise = false;
                //}
                //            else if(tick>= 0)
                //{
                //                tick -= Time.maximumDeltaTime * speed;
                //                revise = true;
                //}
                //else
                //{
                //                revise = false;
                //            }
                #endregion
                Tform.GetComponent<Renderer>().material.color = gradient.Evaluate(tick);
                yield return null;
                yield return new WaitForSeconds(1 / speed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
	#endregion
	#region SingleLineChange
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
                    Debug.Log(tick);
                    yield return null;
                   
                    //yield return new WaitForSeconds(0.1f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
	#endregion
}
