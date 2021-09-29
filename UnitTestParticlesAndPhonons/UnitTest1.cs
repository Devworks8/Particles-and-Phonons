using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Psim.Geometry2D;
using Psim.Particles;

namespace UnitTestParticlesAndPhonons
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PhononConstructor()
        {
            Phonon p = new Phonon(1);

            Assert.AreEqual(0, p.Position.X);
            Assert.AreEqual(0, p.Position.Y);
        }

        [TestMethod]
        public void PhononDriftSingleMovement()
        {
            Phonon p = new Phonon(1);
            p.SetDirection(1,1);
            p.Update(0, 10, Polarization.LA);

            Assert.AreEqual(10, p.Speed);
            p.Drift(10);

            Assert.AreEqual(100, p.Position.X);
            Assert.AreEqual(100, p.Position.Y);
        }

        [TestMethod]
        public void PhononDriftTravel()
        {
            Phonon p = new Phonon(1);
            p.SetDirection(1, 1);
            p.Update(0, 10, Polarization.LA);

            Assert.AreEqual(10, p.Speed);
            p.Drift(10);

            Assert.AreEqual(100, p.Position.X);
            Assert.AreEqual(100, p.Position.Y);

            p.SetDirection(-1, 0);
            p.Drift(3);

            Assert.AreEqual(70, p.Position.X);
            Assert.AreEqual(100, p.Position.Y);

            p.SetDirection(0, 1);
            p.Drift(15);

            Assert.AreEqual(70, p.Position.X);
            Assert.AreEqual(250, p.Position.Y);

            p.SetDirection(1, -1);
            p.Drift(10);

            Assert.AreEqual(170, p.Position.X);
            Assert.AreEqual(150, p.Position.Y);
        }

    }
}
