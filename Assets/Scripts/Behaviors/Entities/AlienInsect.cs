/* 13506593 - Jonathan Lee */
using UnityEngine;

[RequireComponent(typeof(Animator))]
/** Behavior Script for the AlienInsect model and corresponding animations */
public class AlienInsect : MonoBehaviour
{
	/** Reference to the animator for the AlienInsect */
	private Animator _animator;

	/** Current velocity of the AlienInsect */
	private float velocity;

	/** On Awake simply obtain reference to Animator component */
	private void Awake() {
		_animator = GetComponent<Animator>();
	}

	/** Perform input & animation logic in physics loop */
	private void FixedUpdate() {

		// Update animator values
		_animator.SetFloat("forwardMovement", InputManager.Instance._verticalAxisInput);

		// If attack key is pressed, trigger attack animation
		if (InputManager.Instance._isAttackKeyPressed)
			_animator.SetTrigger("attack");
	}

}
