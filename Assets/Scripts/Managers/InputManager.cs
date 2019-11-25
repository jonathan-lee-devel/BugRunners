/* 13506593 - Jonathan Lee */
using UnityEngine;

/** Manages input for the game, allows for easier key re-mapping etc. */
public class InputManager : MonoBehaviour
{
	/** Singleton instance of InputManager */
	public static InputManager Instance { get; private set; }

	/*
	 * Re-assignable control keys
	 */
	public static KeyCode AssignedControlPauseKey { get; private set; }
	public static KeyCode AssignedControlExitKey { get; private set; }

	/*
	 * Re-assignable in-game keys
	 */
	public static KeyCode AssignedSprintKey { get; private set; }
	public static KeyCode AssignedJumpKey { get; private set; }
	public static KeyCode AssignedAttackKey { get; private set; }
	public static KeyCode AssignedThrowKey { get; private set; }

	/*
	 * Assigned-key states
	 */
	public bool _isSprintKeyPressed { get; private set; }
	public bool _isJumpKeyPressed { get; private set; }
	public bool _isAttackKeyPressed { get; private set; }
	public bool _isThrowKeyPressed { get; private set; }

	/*
	 * Allows for global access to current axis input values (updated constantly)
	 */
	public float _verticalAxisInput { get; private set; }
	public float _horizontalAxisInput { get; private set; }

	/** Ensure that only one instance of InputManager instance shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
			InitializeAssignedKeys();
		}
		else {
			Destroy(gameObject);// Destroy further instances of InputManager
		}
	}

	private void InitializeAssignedKeys() {
		/* Initialize control keys */
		AssignedControlPauseKey = KeyCode.P;
		AssignedControlExitKey = KeyCode.Escape;

		/* Initialize in-game keys */
		AssignedSprintKey = KeyCode.LeftShift;
		AssignedJumpKey = KeyCode.Space;
		AssignedAttackKey = KeyCode.Mouse0;
		AssignedThrowKey = KeyCode.E;
	}

	/** Updates state of all necessary input values
	 * (Possibly causing serious runtime ineficciency as you probably wouldn't have this many Input.Get() calls per frame
	 */
	private void Update() {
		_verticalAxisInput = Input.GetAxis("Vertical");
		_horizontalAxisInput = Input.GetAxis("Horizontal");
		_isSprintKeyPressed = Input.GetKey(AssignedSprintKey);
		_isJumpKeyPressed = Input.GetKey(AssignedJumpKey);
		_isAttackKeyPressed = Input.GetKey(AssignedAttackKey);
		_isThrowKeyPressed = Input.GetKey(AssignedThrowKey);
	}

}
