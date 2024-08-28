using Godot;
using System;

public partial class Laser : Area2D
{
	//Default _Speed of the laser bullet.
	private float _Speed = 1000;
	// Default firing _Direction
	private Vector2 _Direction = Vector2.Up;
	// Called when the node enters the scene tree for the first time.

	private Vector2 _Velocity = Vector2.Zero;

	public void SetSpeed(float speed)
	{
		this._Speed = speed;
	}

	public float GetSpeed()
	{
		return this._Speed;
	}

	public void SetVelocity(Vector2 velocity)
	{
		this._Velocity = velocity;
	}

	public Vector2 GetVelocity()
	{
		return this._Velocity;
	}
	public override void _Ready()
	{
		Vector2 velocity = this._Speed * this._Direction;
		SetVelocity(velocity);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float calculated_delta = (float)delta;

		// Update laser's position/Laser moving up at given Speed.
		Position += this._Velocity * calculated_delta;
	}

	// When the laset hit an object, stop the laser.
	private void OnBodyEntered(Node2D collisionObject)
	{
		Console.WriteLine("Laser is hitting the object, object type is:" + collisionObject.GetType());
		QueueFree();
	}

	// Destroy Laser instance when hitting a Meteor object
	private void OnAreaEntered(Area2D collisionObject)
	{
		Console.WriteLine("Hitting the meteor and destroy laser bullet after hitting the target!");
		QueueFree();
	}
}
