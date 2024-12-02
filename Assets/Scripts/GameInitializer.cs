using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public NPCSpawner npcSpawner; // Assign in Inspector
    public int npcCount = 10;

    private void Start()
    {
        if (npcSpawner != null)
        {
            npcSpawner.SpawnMultipleNPCs(npcCount);
        }
    }
}
