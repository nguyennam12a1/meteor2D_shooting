using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private PackedScene MeteorScene, LaserScene;
	private Vector2 _Direction = Vector2.Down;
	private Vector2 _size;
	private Vector2 _SpawnPosition = Vector2.Zero;

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
		LaserScene = GD.Load<PackedScene>("res://scenes/laser.tscn");

		// Get the _size of the main screen
		_size = GetViewport().GetVisibleRect().Size;

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

		// Create new _Direction vector
		Vector2 new_Direction = new Vector2(rotation_angle, (float)1.0);

		// Get random speed for each meteor
		float speed = GD.RandRange(100, 300);

		// Get the random spawn location on the X axis.
		_SpawnPosition.X = (float)GD.RandRange(0, _size.X);

		// Update meteor's spawn location. It must be coming out of the window's border and fly towards the Player _Direction.
		meteor.Position = _SpawnPosition;

		// Set the falling _Direction
		meteor.SetDirection(new_Direction);

		// Set the Speed for each Meteor
		meteor.SetSpeed(speed);

		// Connect Meteor hit signal to a custom function declared in the Level.tscn scene
		meteor.PlayerHit += OnPlayerHit;

		meteor.LaserHit += UpdatePlayerScore;

		// Add Meteor instance to another child node
		GetNode<Node2D>("Meteors").AddChild(meteor);
	}

	// When mouse left-click detected, fire laser bullet in the given _Direction.
	private void OnPlayerShoot(float _Direction, Vector2 position)
	{
		var bullet = this.LaserScene.Instantiate<Laser>();
		AddChild(bullet);

		// Move the firing position to be a little bit above the head of Player's object, so it looks more realistic.
		bullet.Position = position + Vector2.Up * 70;
	}

	// When the player got hit by the Meteor, destroy the player.
	private void OnPlayerHit()
	{
		this.GameOver();
	}

	// Load GameOver scene when the game ends.
	private void GameOver()
	{
		// Destroy unused nodes
		GetNode<CharacterBody2D>("Player").QueueFree();
		GetNode<Timer>("SpawnTimer").Stop();
		GetNode<Node2D>("Meteors").QueueFree();
		GetNode<Node2D>("Lasers").QueueFree();

		// Load GameOver scene
		GetTree().ChangeSceneToFile("res://scenes/gameoverui.tscn");
	}

	// Start a new game after game over.
	private void OnStartGame()
	{
		GetTree().ChangeSceneToFile("res://scenes/level.tscn");
	}
	private void UpdatePlayerScore()
	{
		PlayerVariables.Instance.Score += 1;
		Console.WriteLine(PlayerVariables.Instance.Score);
	}
}
