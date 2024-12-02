using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 5f; 

    private void Update()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        NPCInteract closestNPC = null;
        float closestDistance = interactRange;

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteract npcInteract))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNPC = npcInteract;
                }
            }
        }
    }
}

