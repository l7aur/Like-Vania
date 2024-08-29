using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [Header("Fast Beat")]
    [SerializeField] Sprite[] fastBeat;
    [Header("Slow Beat")]
    [SerializeField] Sprite[] slowBeat;
    [Header("Metadata")]
    [SerializeField] int framesPerSprite = 20;
    [SerializeField] Image[] images = new Image[3];

    int slowBeatSize = 0;
    int fastBeatSize = 0;
    int animationIndex = 1;
    int frame = 0;
    int index = 0;

    private void Awake()
    {
        fastBeatSize = fastBeat.Length;
        slowBeatSize = slowBeat.Length;
    }

    void Update()
    {
        frame++;
        if (frame % framesPerSprite == 0)
        {
            frame = 0;
            if (animationIndex == 0)
            {
                images[0].sprite = images[1].sprite = images[2].sprite = fastBeat[index];
                index = (index + 1) % fastBeatSize;
            }
            else if (animationIndex == 1)
            {
                images[0].sprite = images[1].sprite = images[2].sprite = slowBeat[index];
                index = (index + 1) % slowBeatSize;
            }
        }
    }

    public void ChangeAnimation(int newValue)
    {
        animationIndex = newValue;
        frame = framesPerSprite - 1;
        index = 0;
    }

    public Image[] getImages() { return images; }
}
