using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapshot : MonoBehaviour
{
    public void TakeScreenShot()
    {
        StartCoroutine(CaptureScreenShot());
    }

    public IEnumerator CaptureScreenShot()
    {
        string timestamp = System.DateTime.Now.ToString("dd-MM-yyyy");
        string fileName = "Image_" + timestamp + ".jpg";

        ScreenCapture.CaptureScreenshot(fileName);

        yield return new WaitForEndOfFrame();
    }
}
