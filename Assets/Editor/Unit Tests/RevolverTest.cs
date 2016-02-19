using Brainz.Demo.TDD.Gun;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Tests
{
	[TestFixture]
	public class RevolverTest
	{
		private const string SHOULD_BE_DESTROYED_TAG = "ShouldBeDestroyedOnTearDown";

		private IObjectInstantiator instantiator;
		private Revolver revolver;
		private GameObject bullet;

		[SetUp]
		public void MakeRevolver()
		{
			DiContainer container = new DiContainer();

			instantiator = Substitute.For<IObjectInstantiator>();
			container.Bind<IObjectInstantiator>().ToInstance(instantiator);

			bullet = MockBullet();
			container.Bind<GameObject>("Bullet").ToInstance(bullet);

			revolver = new Revolver();
			container.Inject(revolver);
		}

		private GameObject MockBullet()
		{
			GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			bullet.tag = SHOULD_BE_DESTROYED_TAG;
			return bullet;
		}

		[TearDown]
		public void CleanBullets()
		{
			GameObject[] bullets = GameObject.FindGameObjectsWithTag(SHOULD_BE_DESTROYED_TAG);
			foreach (GameObject toDestroy in bullets)
				GameObject.DestroyImmediate(toDestroy);
		}

		[Test]
		public void InstantiatesBulletOnShoot()
		{
			revolver.Shoot();
			instantiator.Received().Instantiate(bullet);
		}
	}
}