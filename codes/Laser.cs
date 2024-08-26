using Godot;
using System;

public partial class Laser : Area2D
{
	//Default speed of the laser bullet.
	private float Speed = 1000;
	// Default firing direction
	private Vector2 Direction = Vector2.Up;
	// Called when the node enters the scene tree for the first time.

	private Vector2 Velocity = Vector2.Zero;
	public void SetSpeed(float speed)
	{
		this.Speed = speed;
	}

	public float GetSpeed()
	{
		return this.Speed;
	}

	public void SetVelocity(Vector2 velocity)
	{
		this.Velocity = velocity;
	}

	public Vector2 GetVelocity()
	{
		return this.Velocity;
	}
	public override void _Ready()
	{
		Vector2 velocity = this.Speed * this.Direction;
		SetVelocity(velocity);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float calculated_delta = (float)delta;

		// Update laser's position/Laser moving up at given speed.
		Position += this.Velocity * calculated_delta;
	}

	// When the laset hit an object, stop the laser.
	private void OnBodyEntered(Node2D collisionObject)
	{
		Console.WriteLine("Hitting the object, and the type is:" + collisionObject.GetType());
		QueueFree();
	}
}
