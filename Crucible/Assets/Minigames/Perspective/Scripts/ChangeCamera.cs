using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera topDownCam;
    public Animator topToSideAnimator;

    public Camera sideCam;
    public Animator sideToTopAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // start game in top down view
        topDownCam.enabled = true;
        sideCam.enabled = false;

        topToSideAnimator = topDownCam.GetComponent<Animator>();
        sideToTopAnimator = sideCam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // play animation depending on which camera is on
            if (topDownCam.enabled)
            {
                topToSideAnimator.Play("ShiftToSide");
                print("moving to side");
            }
            else // sideCam.enabled
            {
                sideToTopAnimator.Play("ShiftToTop");
                print("moving up");
            }

            // switch view to other camera
            StartCoroutine(WaitAndSwitchCamera());
        }
    }

    // Wait one second (length of animation) before switching to other camera
    IEnumerator WaitAndSwitchCamera()
    {
        yield return new WaitForSeconds(1f);
        topDownCam.enabled = !topDownCam.enabled;
        sideCam.enabled = !sideCam.enabled;
    }
}
