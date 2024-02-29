using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public enum ItemType
   {
    ExtraBomb,
    BlastRadius,
    SpeedIncreace,
   }
public ItemType type;

public void OnItemPickup(GameObject player)
{
    switch (type)
    {
        case ItemType.ExtraBomb:
            player.GetComponent<BombController>().AddBomb();
            break;

        case ItemType.BlastRadius:
            player.GetComponent<BombController>().explosionRadius++;
            break;

        case ItemType.SpeedIncreace:
            player.GetComponent<MovementController>().speed++;
            break;    

    }

    Destroy(gameObject);
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")) {
        OnItemPickup(other.gameObject);

    }
}

}
