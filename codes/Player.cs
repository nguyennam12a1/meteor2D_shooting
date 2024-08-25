using Godot;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public PackedScene LaserScene = GD.Load<PackedScene>("res://scenes/laser.tscn");
	[Signal]
	public delegate void ShootEventHandler(PackedScene LaserScene, float direction, Vector2 position);
	public override void _Ready()
	{
	}
	

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
			{
				EmitSignal(SignalName.Shoot, LaserScene, Rotation, Position);
				// Console.WriteLine("Bullet Position" + bullet.Position);
			}
		}
	}
	public override void _Process(double delta)
	{
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * Speed;
		MoveAndSlide();
		// Console.WriteLine(Position);
	}
}
