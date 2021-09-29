using System;
using Psim.Particles;
using Psim.Geometry2D;

namespace Psim
{
	class Program
	{
		static void Main(string[] args)
		{
			//Phonon p = new Phonon(1);

			//System.Console.WriteLine(p);

			//p.Drift(10);

   //         Console.WriteLine(p);

			Phonon p1 = new Phonon(1);
			p1.Update(0, 10, Polarization.LA);
			p1.SetDirection(1, 1);
			p1.Drift(7);
            Console.WriteLine(p1);
			p1.SetDirection(-1, 1);
			p1.Drift(3);
			Console.WriteLine(p1);
			Console.ReadKey(true);
		}
	}
}