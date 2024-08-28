using Godot;
using System;
using System.ComponentModel.DataAnnotations.Schema;

/*
NOTES: 
	As the Player is built upon "CharacterBody2D" class, it does not provide any area/body entered detection.
	You must implement collision response on other objects that are not of "CharacterBody2D" type.
	For example: RigidBody2D, Area2D, StaticBody2D,...

	Create custom signal using code: https://docs.godotengine.org/en/stable/getting_started/step_by_step/signals.html
*/
public partial class Player : CharacterBody2D
{
	// Default player's movement speed
	private const float _Speed = 300.0f;

	// 
	public PackedScene LaserScene = GD.Load<PackedScene>("res://scenes/laser.tscn");
	[Signal]
	public delegate void ShootEventHandler(PackedScene LaserScene, float direction, Vector2 position);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() { }

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
			{
				EmitSignal(SignalName.Shoot, Rotation, Position);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Get player's direction
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * _Speed;

		// Enable movement
		MoveAndSlide();
	}
}
