using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
   public TextMeshProUGUI text;
    public GameMonitor monitor;

 
    void Update()
    {
        int leveIndex = monitor.LevelIndex + 1;
        text.text = leveIndex.ToString();
    }
}
