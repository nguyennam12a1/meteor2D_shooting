using Godot;
using System;

public partial class Meteor : Area2D
{
	// Default HP for each Meteor instance. When the HP goes down to 0, the meteor will be destroyed.
	private int HP = 100;

	// Default falling _Direction for each Meteor. From Top -> Bottom.
	private Vector2 _Direction = Vector2.Down;

	// Default moving _Speed for each Meteor.
	private float _Speed = 0;

	[Signal]
	public delegate void PlayerHitEventHandler();

	[Signal]
	public delegate void LaserHitEventHandler();

	public float GetSpeed()
	{
		return this._Speed;
	}
	public void SetSpeed(float speed)
	{
		this._Speed = speed;
	}

	public Vector2 GetDirection()
	{
		return this._Direction;
	}

	public void SetDirection(Vector2 direction)
	{
		this._Direction = direction;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() { }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Set Velocity for each instance of Meteor.
		Vector2 velocity = this._Speed * this._Direction * (float)delta;

		// Update movement
		Position += velocity;
	}

	// When the Meteor hits the Player body object, signal the Level.tscn scene and delegate from there.
	private void OnBodyEntered(Node2D collisionObject)
	{
		// Check if the collided object was of type "CharacterBody2D", which is the class type Player object is built on.
		if (collisionObject.IsClass("CharacterBody2D"))
		{
			Console.WriteLine("We got him");

			// Send the signal. Signal can also be declared in code as class's attribute. So you can reference it anywhere.
			// When connect custom signal to custom handling function, only the words before "EventHandler" are cut off and used as Signal name.
			EmitSignal(SignalName.PlayerHit);
		}
	}

	/** 
	When the laser hit the meteor, decrease HP by 25.
	The meteor object will be destroyed and its process will also be terminated to prevent memory dump.
	**/
	private void OnLaserEntered(Area2D CollisionObject)
	{
		// Reduce HP
		this.HP -= 100;
		if (this.HP == 0)
		{
			EmitSignal(SignalName.LaserHit);
			// Terminate the instance's process when it's out of the current frame.
			QueueFree();
		}
	}

	// Destroy Meteor instance when out of screen to save memory.
	private void OnMeteorExitOnScreen()
	{
		QueueFree();
	}
}
