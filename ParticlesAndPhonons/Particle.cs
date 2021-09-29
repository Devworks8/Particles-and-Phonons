using System;
using Psim.Geometry2D;

namespace Psim.Particles
{
#if DEBUG
	public abstract class Particle
#else
	abstract class Particle
#endif
	{
		private Point position = new Point();
		private Vector direction = new Vector();
		public double Speed { get; protected set; }
		
		public Point Position
		{
			get => new Point(position.X, position.Y);
			set => position = value;
		}

		public Vector Direction
		{
			get => new Vector(direction.DX, direction.DY);
			set => direction = value;
		}

		/// <summary>
		/// The default constructor sets the particle position and direction vector to (0,0)
		/// and the speed to 0.
		/// </summary>
		public Particle() { }
		
		public Particle(Point position, Vector direction, double speed)
		{
			Position = position;
			Direction = direction;
			Speed = speed;
		}
		
		public Particle(Particle p)
		{
			position = p.Position;
			direction = p.Direction;
			Speed = p.Speed;
		}
		/// <summary>
		/// Sets the particle's position in 2D space
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void SetCoords(double? px, double? py)
		{
			position.SetCoords(px, py);
		}
		/// <summary>
		/// Get the x and y position coordinates of the particle
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void GetCoords(out double px, out double py)
		{
			px = position.X;
			py = position.Y;

		}
		/// <summary>
		/// Sets the particle's direction vector
		/// </summary>
		/// <param name="dx">The x component of the direction vector</param>
		/// <param name="dy">The y component of the direction vector</param>
		/// <exception cref="ArgumentOutOfRangeException">Throws if the x or y component is > 1 or < -1."</exception>
		public void SetDirection(double dx, double dy)
		{
			direction.Set(dx, dy);
		}
		/// <summary>
		/// Get the x and y components of the particle direction vector
		/// </summary>
		/// <param name="dx">The x coordinate</param>
		/// <param name="dy">The y coordinate</param>
		public void GetDirection(out double dx, out double dy)
		{
			dx = direction.DX;
			dy = direction.DY;
		}
		/// <summary>
		/// Drifts (moves) the particle in space
		/// </summary>
		/// <param name="time">The amount of time the particle drifts</param>
		public void Drift(double time)
		{
			/* At time 0, our particle is at position (x,y) with direction (i,j) and speed (v)
			 * If we move our particle for (t) seconds -> what will the new position be?
			 * distance moved in x direction = j*v*t
			 * distance moved in y direction = j*v*t
			 */
			SetCoords(position.X + CalculateDrift(direction.DX, Speed, time), position.Y + CalculateDrift(direction.DY, Speed, time));
		}

		/// <summary>
		/// Return calculated drift results
		/// </summary>
		/// <param name="coordinate">Current x/y coordinate</param>
		/// <param name="speed">Speed the particle is moving at</param>
		/// <param name="time">Duration of movement</param>
		/// <returns>Product of coordinate*speed*time</returns>
		private double CalculateDrift(double coordinate, double speed, double time)
        {
			return coordinate * speed * time;
		}
		/// <summary>
		/// Gives the particle a random direction vector
		/// </summary>
		/// <param name="r1">A random number in the interval [0,1]</param>
		/// <param name="r2">A random number in the interval [0,1]</param>
		public void SetRandomDirection(double r1, double r2)
		{
			double dx = 2 * r1 - 1;
			double dy = Math.Sqrt(1 - dx * dx) * Math.Cos(2 * Math.PI * r2);
			direction.Set(dx, dy);
		}
		public abstract void Update(double frequency, double speed, Polarization pol);
		public override string ToString()
		{
			return $"Position: {Position}\n" +
				   $"Direction: {Direction}\n" +
				   $"Speed: {Speed}\n";
		}
	}
}
