/* 13506593 - Jonathan Lee */
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
/** Handles player movement (attached to player object) */
public class PlayerMovementHandler : MonoBehaviour
{
	/** Reference to the Player object's CharacterController */
	private CharacterController _characterController;

	/** Walk speed for the player */
	private float _walkMovementMultiplier;

	/** Sprint speed for the player */
	private float _sprintMovementMultiplier;

	/** Current speed for the player */
	private float _movementMultipler;

	/** Current rotation speed for the player */
	private float _rotationMultipler;

	/** Obtain reference to the Player object's CharacterController component */
	private void Awake() {
		_characterController = GetComponent<CharacterController>();
	}

	/** Player movmement logic is processed within the physics loop, found to be smoother than main Update during testing */
	private void FixedUpdate() {
		MovePlayer();
		JumpPlayer();
	}

	/** Moves the player according to current input values */
	private void MovePlayer() {


	}

	/** Player will jump if the required conditions are satisfied */
	private void JumpPlayer() {

		// Update movement multiplier depending on whether or not the sprint key is pressed */
		_movementMultipler = (InputManager.Instance._isSprintKeyPressed) ? _sprintMovementMultiplier : _walkMovementMultiplier;
	}

}
