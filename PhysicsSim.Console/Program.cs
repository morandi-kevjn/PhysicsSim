using System.Net;
using System.Numerics;

partial class Program
{
    static void Main()
    {
        var particles = new List<Particle>
        {
            new Particle(new Vector2(0, 0), new Vector2(1, 0), 1.0f),
            new Particle(new Vector2(2, 0), new Vector2(-1, 0), 2.0f),
            new Particle(new Vector2(-1, -1), new Vector2(0, 0), 0.5f)
        };

        var graivity = new Vector2(0, -9.81f);
        var timeStep = 0.016f;

        for (int i = 0; i < 100; i++)
        {
            foreach (var particle in particles)
            {
                particle.ApplyForce(graivity * particle.Mass);
                particle.Update(timeStep);
                particle.CheckBounds(-5, 5, -5, 5);
            }
           
            Console.WriteLine($"Time: {i * timeStep:F2}s");
            foreach (var particle in particles)
            {
                Console.WriteLine($"Particle at {particle.Position}");
            }
        }
    }
}

