using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Animation_Controller : MonoBehaviour
{


    [Header("Obscuring")]
    public Image obscureImage;
    public AnimationCurve curve;
    private float ObsElapsed = 0f;
    public float ObsDur = 0.3f;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            fadeInTransition();
        }
    }

    public void fadeInNOutTransition()
    {
        StartCoroutine(InNOut());
    }

    public void fadeInTransition()
    {
        StartCoroutine(obscuring());
    }

    public void fadeOutTransition()
    {
        StartCoroutine(Unobscuring());
    }

    public IEnumerator InNOut()
    {
                yield return StartCoroutine(obscuring());
                yield return new WaitForSeconds(1);
                yield return StartCoroutine(Unobscuring());
    }
    private IEnumerator obscuring()
    {
        float percentageDur = 0;


        Color start = new Color(0f, 0f, 0f, 0f); // black
        Color end = new Color(0f, 0f, 0f, 255f / 255f); // obscure

        while (ObsElapsed < ObsDur)
        {

            percentageDur = ObsElapsed / ObsDur;

            obscureImage.color = Color.Lerp(start, end, curve.Evaluate(percentageDur));

            ObsElapsed += Time.deltaTime;
            yield return null;

        }
        obscureImage.color = end;


        ObsElapsed = 0;

    }

    private IEnumerator Unobscuring()
    {
        float percentageDur = 0;

        Color start = new Color(0f, 0f, 0f, 255f / 255f); // obscure
        Color end = new Color(0f, 0f, 0f, 0f); // black

        while (ObsElapsed < ObsDur)
        {

            percentageDur = ObsElapsed / ObsDur;

            obscureImage.color = Color.Lerp(start, end, curve.Evaluate(percentageDur));

            ObsElapsed += Time.deltaTime;
            yield return null;

        }
        obscureImage.color = end;


        ObsElapsed = 0;

    }
}
