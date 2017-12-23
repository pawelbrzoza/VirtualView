using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SphereChanger : MonoBehaviour {

    //This object should be called 'Fader' and placed over the camera
    GameObject m_Fader;
	float MyTime = 0f;
	public Transform RadialProgress;
	public Transform nextSphere{ get; set; }

	void Awake()
	{
		//Find the fader object
		m_Fader = GameObject.Find("Fader");

		//Check if we found something
		if (m_Fader == null)
			Debug.LogWarning("No Fader object found on camera.");
	}

	void Start(){
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
	}

	void Update(){

		MyTime += Time.deltaTime;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime/3;

		if (MyTime >= 3f) {
			ChangeSphere (nextSphere);
		}
	}
		
	public void Resetinator(){
		MyTime = 0f;
		RadialProgress.GetComponent<Image> ().fillAmount = 0f;
	}

	public void ChangeSphere(Transform nextSphere)
    {
		StartCoroutine(FadeCamera(nextSphere));
    }

    IEnumerator FadeCamera(Transform nextSphere)
    {
		
        //Ensure we have a fader object
        if (m_Fader != null)
        {
            //Fade the Quad object in and wait 0.75 seconds
            StartCoroutine(FadeIn(0.75f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.75f);

            //Change the camera position
            Camera.main.transform.parent.position = nextSphere.position;

            //Fade the Quad object out 
            StartCoroutine(FadeOut(0.8f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.8f);
        }
        else
        {
            //No fader, so just swap the camera position
            Camera.main.transform.parent.position = nextSphere.position;
        }
    }
		
    IEnumerator FadeOut(float time, Material mat)
    {
        //While we are still visible, remove some of the alpha colour
        while (mat.color.a > 0.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
		
    IEnumerator FadeIn(float time, Material mat)
    {
        //While we aren't fully visible, add some of the alpha colour
        while (mat.color.a < 1.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }
}