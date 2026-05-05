using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class KnifePieceTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] textComponents = { };
    [SerializeField] string text = "THINGY_";

    static readonly string conversion = "THINGY_";

    public void UpdateText(int newValue)
    {
        string replacement = Regex.Replace(text, conversion, newValue.ToString());
        foreach (TextMeshProUGUI textCom in textComponents)
        {
            textCom.text = replacement;
        }
    }
}
