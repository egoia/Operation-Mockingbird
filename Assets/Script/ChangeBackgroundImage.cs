using UnityEngine;

public class DisplayImage3D : MonoBehaviour
{
    public Texture2D[] textures;
    private int currentIndex = 0;

    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();

        if (textures.Length == 0)
        {
            return;
        }

        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        r.material = new Material(shader);
        r.material.mainTexture = textures[currentIndex];
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
        if (textures.Length == 0)
        {
            return;
        }

        ++currentIndex;
        if (currentIndex >= textures.Length)
        {
            currentIndex = 0;
        }

        r.material.mainTexture = textures[currentIndex];
    }

    /*
    /// <summary>
    /// Switch to the previous texture
    /// </summary>
    public void PreviousTexture()
    {
        if (textures.Length == 0)
        {
            return;
        }

        --currentIndex;
        if (currentIndex < 0)
        {
            currentIndex = textures.Length - 1;
        }

        r.material.mainTexture = textures[currentIndex];
    }
    */
}
