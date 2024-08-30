using Godot;
using System;

public partial class WelcomeScreen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<AudioStreamPlayer2D>(Constants.WELCOME_AUDIO).Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Start the game
	private void OnStartGame()
	{
		GetTree().ChangeSceneToFile(Constants.MAIN_LEVEL_SCENE);
	}
}
