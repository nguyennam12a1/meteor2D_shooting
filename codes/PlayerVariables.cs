using Godot;

public partial class PlayerVariables : Node
{
    public static PlayerVariables Instance { get; private set; }

    public int Score { get; set; }

    public override void _Ready()
    {
        Instance = this;
        this.Score = 0;
    }
}