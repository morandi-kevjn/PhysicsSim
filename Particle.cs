using System.Numerics;

public class Particle
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public Vector2 Acceleration { get; set; }

    public float Mass { get; set; }

    public Particle(Vector2 position, Vector2 velocity, float mass)
    {
        Position = position;
        Velocity = velocity;
        Acceleration = Vector2.Zero;
        Mass = mass;
    }

    public void ApplyForce(Vector2 force)
    {
        Acceleration += force / Mass;
    }

    public void Update(float deltaTime)
    {
        Velocity += Acceleration * deltaTime;
        Position += Velocity * deltaTime;
        Acceleration = Vector2.Zero; // Reset acceleration after each update
    }
}