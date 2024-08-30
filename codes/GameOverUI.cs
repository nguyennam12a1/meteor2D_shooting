using Godot;
using System;

public partial class GameOverUI : Node2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Play the Game Over soundtrack when switching to GameOver scene.
		GetNode<AudioStreamPlayer2D>(Constants.GAME_OVER_AUDIO).Play();

		// Update resulting score
		var GameOverScore = GetNode<VBoxContainer>(Constants.V_NOTIFICATIONS_CONTAINER).GetNode<Label>(Constants.GAME_OVER_SCORE);
		GameOverScore.Text += PlayerVariables.Instance.Score.ToString();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnRestartButtonPressed()
	{
		// Reset Score to 0 when starting a new game.
		PlayerVariables.Instance.Score = 0;
		GetTree().ChangeSceneToFile(Constants.MAIN_LEVEL_SCENE);
	}
}
