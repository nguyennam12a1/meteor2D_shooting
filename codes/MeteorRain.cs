using Godot;
using System;
using System.Text.RegularExpressions;

public partial class MeteorRain : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private PackedScene MeteorScene;
	private Vector2 Direction = Vector2.Down;
	private Vector2 size;
	private Vector2 position = Vector2.Zero;

	public void InitRandomizer()
	{
		GD.Randomize();
		GD.Seed(123);
	}

	public override void _Ready()
	{
		InitRandomizer();
		// Load Meteor Scene but not initialize it.
		MeteorScene = GD.Load<PackedScene>("res://scenes/meteor.tscn");

		// GetNode<Timer>("StartSpawn").Start();

		// Get the size of the main screen
		size = GetViewport().GetVisibleRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// When the timer is out, start spawning Meteors.
	private void OnTimerTimeOut()
	{
		Console.WriteLine("Timer has been called!");
		var meteor = MeteorScene.Instantiate<Meteor>();

		// Add Meteor instance to the parent tree
		AddChild(meteor);

		// Get random angle for the meteor
		float rotation_angle = GD.RandRange(-1, 1);

		// Create new direction vector
		Vector2 newDirection = new Vector2(rotation_angle, (float)1.0);

		// Get random speed for each meteor
		float speed = GD.RandRange(100, 300);

		// Get the random spawn location on the X axis.
		position.X = (float)GD.RandRange(0, size.X);

		// Update meteor's spawn location. It must be coming out of the window's border and fly towards the Player direction.
		meteor.Position = position;

		// Set the falling direction
		meteor.SetDirection(newDirection);

		// Set the Speed for each Meteor
		meteor.SetSpeed(speed);
	}
}
;