/* 13506593 - Jonathan Lee */
using UnityEngine;

[RequireComponent(typeof(ResourcePoolManager))]
[RequireComponent(typeof(GUIManager))]
[RequireComponent(typeof(SceneSelectManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(GameStateManager))]
[RequireComponent(typeof(DontDestroyOnLoad))]
/** Managers overall flow / program control */
public class GameManager : MonoBehaviour
{
	/** Singleton instance of GameManager */
	public static GameManager Instance { get; private set; }

	/** Current GameHandler instance, used for managing game-specific mechanics such as score */
	private GameHandler _gameHandler;

	/** Ensure that only one instance of GameManager shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(gameObject);// Destory further instances of GameManager
		}
	}

	public void StartNewGame() {

	}

	public void GameOver() {

	}

	public void ExitGameApplication() {
		Application.Quit();
	}

	/* Getters and Setters */

	public GameHandler GetGameHandler() {
		return _gameHandler;
	}

	private void SetGameHandler(GameHandler gameHandler) {
		_gameHandler = gameHandler;
	}

}
