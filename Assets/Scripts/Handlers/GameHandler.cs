/* 13506593 - Jonathan Lee */
using UnityEngine;

/** Handles in-game specifics & mechanics such as score etc.
 * One instance per-game
 */
public class GameHandler : MonoBehaviour
{
	/*
	 * Default values
	 */
	private static readonly float DefaultTimeLimit = 60 * 60 * 10;// 10 Minutes

	/** Time limit for the game */
	private float _timeLimit;

	/** Time at which the game was started */
	private float _timeStarted;

	/** Time at which teh game was ended */
	private float _timeEnded;

	/** Current amount of time that has elapsed since the game has started */
	private float _timePlayed;

	/** Current score which the player has obtained */
	private int _score;

	/** Initialize values to their respective defaults */
	private void Awake() {
		ResetValues();
	}

	/** Sets fields to their respective defaults */
	public void ResetValues() {
		_timeLimit = DefaultTimeLimit;
		_timeStarted = 0.0f;
		_timeEnded = 0.0f;
		_timePlayed = 0.0f;
		_score = 0;
	}

	/** Kills the requested player */
	public void KillPlayer(GameObject playerGameObject) {
		Debug.Log("GameHandler.KillPlayer called");
	}

	/** Starts a new game (does not affect game-state) */
	public void StartGame() {
		_timeStarted = Time.time;
	}

	/** Ends the current game (does not affect game-state) */
	public void EndGame() {
		_timeEnded = Time.time;
	}

}