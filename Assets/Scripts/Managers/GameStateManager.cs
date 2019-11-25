/* 13506593 - Jonathan Lee */
using UnityEngine;

/** Tracks and manages the current state of the game */
public class GameStateManager : MonoBehaviour
{
	/** Singleton instance of GameManager */
	public static GameStateManager Instance { get; private set; }

	/** Current Game-State */
	private GameState _gameState;

	/** Various states in which the game can be at any given moment */
	public enum GameState
	{
		NOT_IN_GAME,
		PLAYING,
		PAUSED,
		GAME_OVER
	}

	/** Ensure that only one instance of the GameStateManager shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
			_gameState = GameState.NOT_IN_GAME;
		}
		else {
			Destroy(gameObject);// Destroy further instances of GameStateManager
		}
	}

	/** Returns the current game state */
	public GameState GetGameState() {
		return _gameState;
	}

	/** Perfrom appropriate check/action required when changing game state e.g. turn off music */
	public void UpdateGameState(GameState gameState) {
		switch (gameState) {
			case GameState.NOT_IN_GAME:
				break;
			case GameState.PLAYING:
				break;
			case GameState.PAUSED:
				break;
			case GameState.GAME_OVER:
				break;
		}

		_gameState = gameState;
	}
}
