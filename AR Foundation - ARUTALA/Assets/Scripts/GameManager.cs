using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject canvasModel;
    public GameObject fireParticle;
    public GameObject fireParticleBlue;

    [Header("Other")]
    public Model model;
    public Text blinkingText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BlinkingObject()
    {
        if (model.isBlinkActive)
        {
            model.isBlinkActive = false;
            blinkingText.text = "Start\nBlinking";
        }
        else
        {
            model.isBlinkActive = true;
            blinkingText.text = "Stop\nBlinking";
        }
    }

    public void ScreenShoot()
    {
        canvasModel.SetActive(false);
        ScreenCapture.CaptureScreenshot("ARUTALA.png");
        StartCoroutine(ShowCanvas());
    }

    IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(3f);
        canvasModel.SetActive(true);
    }

    public void ChangeParticle()
    {
        bool isRed = model.ChangeColor();
        if (isRed)
        {
            fireParticle.SetActive(true);
            fireParticleBlue.SetActive(false);
        }
        else
        {
            fireParticle.SetActive(false);
            fireParticleBlue.SetActive(true);
        }
    }
}
