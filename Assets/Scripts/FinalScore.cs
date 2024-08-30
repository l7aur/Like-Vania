using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    static string score;

    private void Update()
    {
        text.text =  "You scored " + " " + score + " points!\nCongrats!";
    }

    static public void UpdateText(int value)
    {
       score = value.ToString();
    }
}
