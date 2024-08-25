using Godot;
using System;

public partial class Meteor : Area2D
{
	// Default HP for each Meteor instance. When the HP goes down to 0, the meteor will be destroyed.
	private int HP = 100;

	// Default falling direction for each Meteor. From Top -> Bottom.
	private Vector2 Direction = Vector2.Down;

	// Default moving speed for each Meteor.
	private float Speed = 0;

	public float GetSpeed()
	{
		return this.Speed;
	}

	public void SetSpeed(float speed)
	{
		this.Speed = speed;
	}

	public Vector2 GetDirection()
	{
		return this.Direction;
	}

	public void SetDirection(Vector2 direction)
	{
		this.Direction = direction;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = this.Speed * this.Direction * (float)delta;
		Position += velocity;
	}

	// When the Meteor hits the Player body object, finish the game.
	private void OnBodyEntered(Node2D CollisionObject)
	{
		Console.WriteLine("GAME OVER DUDE...");
	}

	/** 
	When the laser hit the meteor, decrease HP by 25.
	The meteor object will be destroyed and its process will also be terminated to prevent memory dump.
	**/
	private void OnLaserEntered(Area2D CollisionObject)
	{
		Console.WriteLine("The laser has hit the meteor");
		// Reduce HP
		this.HP -= 25;
		if (this.HP == 0)
		{
			// Terminate the instance's process when it's out of the current frame.
			QueueFree();
		}
	}
}
