/* 13506593 - Jonathan Lee */
using System.Collections;
using UnityEngine;

[System.Serializable]
/**
 * NON-ORIGINAL CODE - See SOURCES.md
 * 
 * The code has been altered quite a lot but the original design came from that sourced in SOURCES.md
 * 
 * Simple data class for containing audio clips, allows for easier
 * and more reliable access to sounds for the AudioManager class
 */
public class Sound : MonoBehaviour
{
	/** enum constant reference from AudioManager which pretains to sound represented by this instance of Sound */
	private AudioManager.SoundReference _soundReference;

	/** AudioSource attached in order for AudioClip to be played */
	private AudioSource _audioSource;

	/** AudioClip for the sound */
	private AudioClip _audioClip;

	/*
	 * Adjustable settings for the Sound
	 */

	/** Whether or not the audio clip should be played in a looping style */
	private bool _loop;

	[Range(0.0f, 1.0f)]
	/** Volume at which the clip should be played */
	private float _volume;

	[Range(0.1f, 3.0f)]
	/** Pitch at which the clip should be played */
	private float _pitch;

	/** Constructor with mandatory AudioSource argument */
	public Sound(AudioSource audioSource, AudioClip audioClip) {
		_audioSource = audioSource;
		_audioClip = audioClip;
	}

	/** Plays the AudioSource contained by the sound */
	public void Play() {
		if (_audioSource != null)
			_audioSource.Play();
	}

	/** Updates the volume of the sound smoothly (intended to be called while the sound is playing) */
	public void SmoothUpdateVolume(float targetVolume) {
		StartCoroutine(SmoothUpdateVolumeCoroutine(targetVolume, 0.0f));
	}

	private IEnumerator SmoothUpdateVolumeCoroutine(float targetVolume, float delayTime) {
		yield return new WaitForSeconds(delayTime);
		// Update volume and call recursively
	}

	/** Updates the pitch of the sound smoothly (intended to be called while the sound is playing */
	public void SmoothUpdatePitch(float targetPitch) {
		StartCoroutine(SmoothUpdatePitchCoroutine(targetPitch, 0.0f));
	}

	private IEnumerator SmoothUpdatePitchCoroutine(float targetPitch, float delayTime) {
		yield return new WaitForSeconds(delayTime);
		// Update pitch and call recursively
	}

	/*
	 * Getters and Setters
	 */

	public bool GetLoop() {
		return _loop;
	}

	public void SetLoop(bool loop) {
		_loop = loop;
	}

	public float GetVolume() {
		return _volume;
	}

	public void SetVolume(float volume) {
		_volume = volume;
	}

	public float GetPitch() {
		return _pitch;
	}

	public void SetPitch(float pitch) {
		_pitch = pitch;
	}

}
