using Godot;
using System;

public partial class Meteor : Area2D
{
	private int HP = 100;
	private Vector2 Direction = Vector2.Down;
	private float Speed = 300;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Speed * Direction * (float)delta;
		Position += velocity;
	}

	private void OnBodyEntered(Node2D CollisionObject)
	{
		Console.WriteLine("GAME OVER DUDE...");
	}

	private void OnLaserEntered(Area2D CollisionObject)
	{
		Console.WriteLine("The laser has hit the meteor");
		// Reduce HP
		this.HP -= 25;
		if (this.HP == 0)
		{
			Hide();
		}
	}
}
