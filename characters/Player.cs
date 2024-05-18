using Godot;

namespace RectangleRunner.Characters;
public partial class Player : CharacterBody2D
{
	private const float JumpVelocity = -600.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += _gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		if (Input.IsActionPressed("duck") && IsOnFloor())
		{
			Scale = new Vector2(1, 0.5f);
		}
		else
		{
			Scale = new Vector2(1, 1);
		}
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
