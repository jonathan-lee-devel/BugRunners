/* 13506593 - Jonathan Lee */
using UnityEngine;
using System.Collections.Generic;

/** Manages audio for the game, essentiall offers global, safe & persistent access to audio */
public class AudioManager : MonoBehaviour
{
	/** Singleton instance of AudioManager */
	public static AudioManager Instance { get; private set; }

	/** List of file paths pretaining to all required sound files to be loaded at startup */
	private static readonly string[] AudioClipFilePaths = { "Sounds/Songs/theme", "Sounds/Effects/jump" };

	/** List of AudioSources loaded and available to be played at any given moment */
	private readonly List<Sound> _sounds = new List<Sound>(AudioClipFilePaths.Length);

	/** Current song that is playing, null for none */
	private Sound _song;

	/** enum constants by which specific sounds are to be referenced/played */
	public enum SoundReference
	{
		SONG_THEME,
		SONG_IN_GAME,
		EFFECT_JUMP
	}

	/** Ensure that only one instance of AudioManager shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;

			/* Load all sounds */
			for (int i = 0; i < AudioClipFilePaths.Length; i++) {
				// Create sound from resource loaded from given path and add to list
				Sound sound = new Sound(gameObject.AddComponent<AudioSource>(), Resources.Load<AudioClip>(AudioClipFilePaths[i]));

				// Determine if sound loaded is a song or not based on file path
				bool isSong = AudioClipFilePaths[i].Contains("Song");
				// Set initial values accordingly
				sound.SetLoop(isSong);
				sound.SetVolume((isSong) ? 0.5f : 1.0f);
				sound.SetPitch(1.0f);
			}

		}
		else {
			Destroy(gameObject);// Destroy further instances of AudioManager
		}
	}

	private Sound GetSoundBySoundReference(SoundReference soundReference) {
		switch (soundReference) {
			case SoundReference.SONG_THEME:
				return _sounds[0];
			default:
				Debug.LogWarning($"AudioManager.Instance.GetAudioSourceByEnum returned empty sound on soundReference: {soundReference}");
				return _sounds[0];
		}
	}

	public void PlaySong(SoundReference songReference) {
		switch (songReference) {
			case SoundReference.SONG_THEME:
				GetSoundBySoundReference(songReference).Play();
				break;
			default:
				Debug.LogWarning($"Attempted to play non-song SoundReference: {songReference} as a song, no action taken");
				break;
		}
	}

	public void PlaySoundEffect(SoundReference soundEffectReference) {
		switch (soundEffectReference) {
			case SoundReference.EFFECT_JUMP:
				GetSoundBySoundReference(soundEffectReference).Play();
				break;
			default:
				Debug.LogWarning($"Attempted to play non-sound-effect: {soundEffectReference} as a sound effect, no action taken");
				break;
		}
	}

}
