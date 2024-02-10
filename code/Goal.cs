using Sandbox;
using static Sandbox.Component;

public sealed class Goal : Component, ITriggerListener
{
	[Property] public GameObject Ball { get; set; }
	[Property] public GameObject BallRespawn { get; set; }

	void BallSpawn()
	{
		var rigid = Ball.Components.Get<Rigidbody>();
		Ball.Transform.Position = BallRespawn.Transform.Position;
		rigid.Velocity = 0;
		rigid.AngularVelocity = 0;
	}

	void ITriggerListener.OnTriggerEnter( Collider other )
	{
		BallSpawn();
	}

	void ITriggerListener.OnTriggerExit( Collider other )
	{
		
	}
}
