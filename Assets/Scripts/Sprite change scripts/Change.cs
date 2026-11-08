

using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public Image targetImage;
    public Sprite state1;
    public Sprite state2;

    public Image targetImage2;
    public Sprite state3;
    public Sprite state4;

    public Image targetImage3;
    public Sprite state5;
    public Sprite state6;

    private bool isState2 = false;

    public void ChangeSprite()
    {
        isState2 = !isState2;

        if (isState2)
        {
            targetImage.sprite = state2;
            targetImage2.sprite = state4;
            targetImage3.sprite = state6;
        }
        else
        {
            targetImage.sprite = state1;
            targetImage2.sprite = state3;
            targetImage3.sprite = state5;
        }
    }
}
