using UnityEngine;
using System.Collections;

public class GrowSpikes : MonoBehaviour
{

    private bool isGrowing = false;
    private bool isHiding = false;
    private int frame = 0;
    private float time = 0f;
	
	// Update is called once per frame
	void Update () {
	    if (isGrowing)
	    {
	        if (time < 2f)
	        {
	            gameObject.transform.localScale += new Vector3(0, 1f, 0);
	            time += Time.deltaTime;
	        }
	        else
	        {
	            isGrowing = false;
	            isHiding = true;
	            time = 0f;
	        }
	    }
	    else if(isHiding)
	    {
	        if (time < 2f)
	        {
                gameObject.transform.localScale += new Vector3(0, 1f, 0);
                time += Time.deltaTime;
            }
            else
            {
                isHiding = false;
                Destroy(gameObject);
            }
        }
	}

    public void GrowAndAttack()
    {
        if (!isGrowing && !isHiding)
        {
            isGrowing = true;
        }
    }
}
