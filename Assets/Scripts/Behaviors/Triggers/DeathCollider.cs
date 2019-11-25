/* 13506593 - Jonathan Lee */
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
/** Script responsible for notifying GameHandler when a player object has gone out of bounds
 * Example: player has fallen off the map
 */
public class DeathCollider : MonoBehaviour
{
	/** On trigger-activation, notify current game handler if the collider was a Player object and hence should be killed */
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals("Player"))
			GameManager.Instance.GetGameHandler().KillPlayer(other.gameObject);
	}

}
