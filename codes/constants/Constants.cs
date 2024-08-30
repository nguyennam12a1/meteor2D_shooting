using System;
using Godot;


public static class Constants
{

    // Scene's file path
    public static readonly String MAIN_LEVEL_SCENE = "res://scenes/level.tscn";
    public static readonly String LASER_SCENE = "res://scenes/laser.tscn";
    public static readonly String METEOR_SCENE = "res://scenes/meteor.tscn";
    public static readonly String PLAYER_SCENE = "res://scenes/player.tscn";
    public static readonly String GAME_OVER_SCENE = "res://scenes/gameover_screen.tscn";
    public static readonly String WELCOME_SCREEN_SCENE = "res://scenes/welcome_screen.tscn";

    // User movement input
    public static readonly String USER_INPUT_LEFT = "left";
    public static readonly String USER_INPUT_RIGHT = "right";
    public static readonly String USER_INPUT_UP = "up";
    public static readonly String USER_INPUT_DOWN = "down";

    // Audio
    public static readonly String LASER_FIRING_AUDIO = "LaserFiringAudio";
    public static readonly String GAME_OVER_AUDIO = "GameOverAudio";
    public static readonly String WELCOME_AUDIO = "WelcomeAudio";

    // Godot's Nodes
    public static readonly String GAME_OVER_SCORE = "GameOverScore";

    public static readonly String V_NOTIFICATIONS_CONTAINER = "VNotificationsContainer";
}

