using System.Numerics;

namespace PhysicsSim.Core
{
    public class Particle
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public float Mass { get; set; }

        public float Radius { get; set; } = 5f;

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
            // Basic Euler integration for position and velocity update
            Velocity += Acceleration * deltaTime;

            // Apply air drag
            float dragCoefficient = 0.95f; // Adjust as needed
            Velocity *= dragCoefficient;

            // Update position based on velocity
            Position += Velocity * deltaTime;

            // Reset acceleration for the next update
            Acceleration = Vector2.Zero; // Reset acceleration after each update
        }

        public void CheckBounds(float minX, float maxX, float minY, float maxY)
        {
            var updatePosition = Position;
            var updateVelocity = Velocity;
            float bounceDamping = 0.8f; // Damping factor for bounce

            if (updatePosition.X - Radius < minX)
            {
                updatePosition.X = minX + Radius; // Clamp to minX
                updateVelocity.X *= -bounceDamping; // Reflect velocity on X bounds
            }
            else if (updatePosition.X + Radius > maxX)
            {
                updatePosition.X = maxX - Radius; // Clamp to maxX
                updateVelocity.X *= -bounceDamping; // Reflect velocity on X bounds
            }
            if (updatePosition.Y - Radius < minY)
            {
                updatePosition.Y = minY + Radius; // Clamp to minY
                updateVelocity.Y *= -bounceDamping; // Reflect velocity on Y bounds
            }
            else if (updatePosition.Y + Radius > maxY)
            {
                updatePosition.Y = maxY - Radius; // Clamp to maxY
                updateVelocity.Y *= -bounceDamping; // Reflect velocity on Y bounds
            }
            
            Position = updatePosition;
            Velocity = updateVelocity;
        }
    }
}
