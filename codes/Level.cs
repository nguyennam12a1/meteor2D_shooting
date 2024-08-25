using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPlayerShoot(PackedScene LaserScene, float direction, Vector2 position)
	{
		var bullet = LaserScene.Instantiate<Laser>();
		AddChild(bullet);
		bullet.Position = position + Vector2.Up * 70;
	}
}
