using System;
using UnityEngine;
using static Mission;

public class DisplayImage3D : MonoBehaviour
{
    [Serializable]
    public class Background
    {
        public Texture2D texture;
        public PhotoProp prop;
    }
    public Background[] backgroundImages;
    private int currentIndex = 0;

    public Renderer r;

    void Start()
    {

        if (backgroundImages.Length == 0)
        {
            return;
        }

        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        r.material = new Material(shader);
        r.material.mainTexture = backgroundImages[currentIndex].texture;
    }

    private void Update()
    {
        // For demonstration purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextTexture();
        }
    }

    /// <summary>
    /// Switch to the next texture
    /// </summary>
    public void NextTexture()
    {
        if (backgroundImages.Length == 0)
        {
            return;
        }

        ++currentIndex;
        if (currentIndex >= backgroundImages.Length)
        {
            currentIndex = 0;
        }

        r.material.mainTexture = backgroundImages[currentIndex].texture;
    }

    public PhotoProp GetProp()
    {
        return backgroundImages[currentIndex].prop;
    }

    /*
    /// <summary>
    /// Switch to the previous texture
    /// </summary>
    public void PreviousTexture()
    {
        if (backgroundImage.Length == 0)
        {
            return;
        }

        --currentIndex;
        if (currentIndex < 0)
        {
            currentIndex = backgroundImage.Length - 1;
        }

        r.material.mainTexture = backgroundImage[currentIndex];
    }
    */
}
