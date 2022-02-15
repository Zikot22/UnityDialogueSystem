using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "Dialog")]
public class Dialogue: ScriptableObject
{
    [TextArea(3, 10)]
    public string[] sentences;
}