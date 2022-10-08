using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    public GameObject fireParticle;
    public GameObject fireParticleBlue;
    public Text blinkingText;
    public bool isBlinkActive = false;
    public bool isColorRed = true;
    public int rotateSpeed = 15;
    Animator animator;
    GameObject gameObjectLogo;
    Renderer renderer;
    Color activeColor = new Color();
    private float initialDistance;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameObjectLogo = GameObject.Find("Model");
        renderer = GetComponent<Renderer>();
        activeColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            animator.enabled = false;
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, screenTouch.deltaPosition.x * -1 * Time.deltaTime * rotateSpeed, 0f);
            }
        }
        else
        {
            animator.enabled = true;
        }

        GetComponent<MeshRenderer>().material.color = activeColor;

        if (Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
            touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = gameObjectLogo.transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }

                var factor = currentDistance / initialDistance;
                gameObjectLogo.transform.localScale = initialScale * factor;
            }
        }

        if (isBlinkActive)
        {
            if (Time.fixedTime % .5 < .2)
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
            }
        }
        else { renderer.enabled = true; }
    }

    public bool ChangeColor()
    {
        if (isColorRed)
        {
            isColorRed = false;
            activeColor = Color.blue;
        }
        else
        {
            isColorRed = true;
            activeColor = Color.red;
        }
        return isColorRed;
    }
}