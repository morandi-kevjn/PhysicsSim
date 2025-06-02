using System.Net;
using System.Numerics;

class Program
{
    static void Main()
    {
        var particle = new Particle(new Vector2(0, 0), new Vector2(1, 0), 1.0f);
        var gravity = new Vector2(0, -9.81f);
        float deltaTime = 0.016f; // Assuming 60 FPS, so ~16ms per frame

        for (int i = 0; i < 100; i++)
        {
            particle.ApplyForce(gravity);
            particle.Update(deltaTime);
            Console.WriteLine($"Time: {i * deltaTime:F2}, Position: {particle.Position}, Velocity: {particle.Velocity}");
        }
    }
}

