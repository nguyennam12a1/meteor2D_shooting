using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private PackedScene MeteorScene;
	private Vector2 Direction = Vector2.Down;
	private Vector2 size;
	private Vector2 spawnPosition = Vector2.Zero;

	public void InitRandomizer()
	{
		GD.Randomize();
		GD.Seed(123);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitRandomizer();
		// Load Meteor Scene but not initialize it.
		MeteorScene = GD.Load<PackedScene>("res://scenes/meteor.tscn");

		// GetNode<Timer>("StartSpawn").Start();

		// Get the size of the main screen
		size = GetViewport().GetVisibleRect().Size;

		// Start the Meteor Spawn and also, the game
		var timer = GetNode<Timer>("SpawnTimer");
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnTimerTimeOut()
	{
		// Console.WriteLine("Timer has been called!");
		var meteor = MeteorScene.Instantiate<Meteor>();

		// Get random angle for the meteor
		float rotation_angle = GD.RandRange(-1, 1);

		// Create new direction vector
		Vector2 newDirection = new Vector2(rotation_angle, (float)1.0);

		// Get random speed for each meteor
		float speed = GD.RandRange(100, 300);

		// Get the random spawn location on the X axis.
		spawnPosition.X = (float)GD.RandRange(0, size.X);

		// Update meteor's spawn location. It must be coming out of the window's border and fly towards the Player direction.
		meteor.Position = spawnPosition;

		// Set the falling direction
		meteor.SetDirection(newDirection);

		// Set the Speed for each Meteor
		meteor.SetSpeed(speed);

		// Connect Meteor hit signal to a custom function declared in the Level.tscn scene
		meteor.PlayerHit += OnPlayerHit;

		// Add Meteor instance to another child node
		GetNode<Node2D>("Meteors").AddChild(meteor);
	}

	// When mouse left-click detected, fire laser bullet in the given direction.
	private void OnPlayerShoot(PackedScene LaserScene, float direction, Vector2 position)
	{
		var bullet = LaserScene.Instantiate<Laser>();
		AddChild(bullet);

		// Move the firing position to be a little bit above the head of Player's object, so it looks more realistic.
		bullet.Position = position + Vector2.Up * 70;
	}

	// When the player got hit by the Meteor, destroy the player.
	private void OnPlayerHit()
	{
		GetNode<CharacterBody2D>("Player").QueueFree();
		GetNode<Timer>("SpawnTimer").Stop();
		GetNode<Node2D>("Meteors").QueueFree();
	}
}
