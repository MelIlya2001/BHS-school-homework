using UnityEngine;

[CreateAssetMenu(fileName = "levelPreviewData", menuName = "Levels/Preview")]
public class LevelPreviewData : ScriptableObject
{
    public Sprite Preview;
    public string Name;
    public int SceneIndex;
    public bool isAccesible;
}
