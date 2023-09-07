using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
   private bool isTakingScreenshot = false;

    public GameObject[] panelsToHide; // Assign panels to hide in the Inspector

    public void TakeScreenshot()
    {
        if (!isTakingScreenshot)
        {
            StartCoroutine(TakeScreenshotCoroutine());
        }
    }

    private IEnumerator TakeScreenshotCoroutine()
    {
        isTakingScreenshot = true;

        // Hide the panels and canvases
        foreach (GameObject panel in panelsToHide)
        {
            panel.SetActive(false);
        }

        yield return new WaitForEndOfFrame();

        // Take a screenshot
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] screenshotBytes = screenshotTexture.EncodeToPNG();

        // Generate a unique filename
        string screenshotFileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

        // Save the screenshot to persistent data path
        string screenshotPath = System.IO.Path.Combine(Application.persistentDataPath, screenshotFileName);
        System.IO.File.WriteAllBytes(screenshotPath, screenshotBytes);

        // Show the panels and canvases again
        foreach (GameObject panel in panelsToHide)
        {
            panel.SetActive(true);
        }

        // Refresh the media scanner to show the screenshot in the gallery
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        mediaScanner.CallStatic("scanFile", new object[] { Application.persistentDataPath, null, null, null });

        isTakingScreenshot = false;
    }
}
