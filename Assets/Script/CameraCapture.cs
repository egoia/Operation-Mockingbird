using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    [SerializeField]
    public int fileCounter;
    public KeyCode screenshotKey;
    public Camera Camera;
    //public PhysiclImageController phImgController;

    void Start()
    {
        var dir = new DirectoryInfo(Application.dataPath + "/Resources");
        FileInfo[] fileInfo = dir.GetFiles();
        foreach (FileInfo file in fileInfo)
            file.Delete();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            Capture();
        }
    }

    public void Capture()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = Camera.targetTexture;

        Camera.Render();

        Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);

        image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
        image.Apply();

    

        RenderTexture.active = activeRenderTexture;

        byte[] bytes = image.EncodeToPNG();
        //Destroy(image);

        Directory.CreateDirectory(Application.dataPath + "/Resources");

        string fileName = fileCounter + ".png";
        Debug.Log("?");
        File.WriteAllBytes(Application.dataPath + "/Resources/"+fileName, bytes);
        AssetDatabase.Refresh();
        Debug.Log("??");
        //phImgController.setSprite(fileCounter);
        fileCounter++;
    }


}