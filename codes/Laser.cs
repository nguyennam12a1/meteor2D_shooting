using Godot;
using System;

public partial class Laser : Area2D
{
	private float Speed = 1000;
	private Vector2 Direction = Vector2.Up;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float calculated_delta = (float)delta;
		Vector2 velocity = Speed * Direction;
		// Update laser's position/Laser moving up at given speed.
		Position += velocity * calculated_delta;
	}
}
