/* 13506593 - Jonathan Lee */
using UnityEngine;

[RequireComponent(typeof(Transform))]
/**
 * NON-ORIGINAL CODE - See SOURCES.md
 * Follows the specified target transform according to given offset and smooth-speed (Attached to camera)
 */
public class CameraSmoothFollowHandler : MonoBehaviour
{
	/** Transform of the GameObject which the camera is to follow */
	private Transform _target;

	/** Offset from the target at which the camera should aim to reside */
	private Vector3 _offset;

	/** Amount by which to delay when re-positioning camera to allow for smoother action (Higher = Smoother) */
	private float _smoothSpeed;

	/** Desired position of the camera, i.e. the offset position of the target transform */
	private Vector3 _desiredPosition;

	/** Smoothed position of the camera, i.e. position which the camera will snap to once ensuring smoothness is accounted for */
	private Vector3 _smoothedPostion;

	/** Camera follow logic is called in the Physics loop, the rigid timing of th physics loops provides smoother & more consistent camera movement */
	private void FixedUpdate() {
		SmoothFollowTarget();
	}

	/** Smoothly re-position and re-direct camera in order to smoothly follow the target according to the _smoothSpeed multiplier */
	private void SmoothFollowTarget() {

		_desiredPosition = _target.position + _offset;// Update desired position to offset _target position
		_smoothedPostion = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);// Calculate smoothed position according to _smoothSpeed
		transform.position = _smoothedPostion;// Set camera position to calculated _smoothedPosition

		transform.LookAt(_target);// Re-direct camera to look at the updated position of the _target transform
	}

}
