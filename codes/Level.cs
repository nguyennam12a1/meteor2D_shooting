using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// var test = GetNode<Node2D>("MeteorRain");
		// var timer = test.GetNode<Timer>("StartSpawn");
		// timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// When mouse left-click detected, fire laser bullet in the given direction.
	private void OnPlayerShoot(PackedScene LaserScene, float direction, Vector2 position)
	{
		var bullet = LaserScene.Instantiate<Laser>();
		AddChild(bullet);

		// Move the firing position to be a little bit above the head of Player's object, so it looks more realistic.
		bullet.Position = position + Vector2.Up * 70;
	}
}
