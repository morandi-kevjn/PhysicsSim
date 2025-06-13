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

    public void CheckBounds(float minX, float maxX, float minY, float maxY)
    {
        if (Position.X < minX || Position.X > maxX)
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reflect velocity on X bounds
            Position = new Vector2(
                Math.Clamp(Position.X, minX, maxX),
                Position.Y
            );
        }

        if (Position.Y < minY || Position.Y > maxY)
        {
            Velocity = new Vector2(Velocity.X, -Velocity.Y); // Reflect velocity on Y bounds
            Position = new Vector2(
                Position.X,
                Math.Clamp(Position.Y, minY, maxY)
            );
        }
    }
}