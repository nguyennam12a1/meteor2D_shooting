using Godot;
using System;

public partial class MeteorRain : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private PackedScene MeteorScene = GD.Load<PackedScene>("res://scenes/meteor.tscn");
	private Vector2 Direction = Vector2.Down;
	private Vector2 size;
	private Vector2 position = Vector2.Zero;
	public override void _Ready()
	{
		GD.Randomize();
		GD.Seed(123);
		GetNode<Timer>("StartSpawn").Start();
		size = GetViewport().GetVisibleRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnTimerTimeOut()
	{
		Console.WriteLine("Timer has been called!");
		var meteor = MeteorScene.Instantiate<Meteor>();
		AddChild(meteor);

		// Get random angle for the meteor
		float rotation_angle = GD.Randi() % 50;

		// Get random speed for each meteor
		float speed = GD.RandRange(100, 300);
		// Get the random spawn location on the X axis.
		position.X = (float)GD.RandRange(0, size.X);

		// Update meteor's spawn location
		meteor.Position = position;
	}
}
