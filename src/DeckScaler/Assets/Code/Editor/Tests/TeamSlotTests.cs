using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Systems;
using DeckScaler.Utils;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace DeckScaler.Editor.Tests
{
    public class TeamSlotTests
    {
        private Entitas.Systems _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = new Entitas.Systems();
            Contexts.Instance.InitializeScope<Game>();

            Services.Setup<IFactories>(new Factories());
            Services.Setup<IProgress>(new Mocks.Progress());

            Services.Get<IProgress>().StartNewRun();
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var entity in Contexts.Instance.Get<Game>().GetEntities())
                entity.Destroy(); // TODO: destroy component?

            _feature.Dispose();
        }

        [Test]
        public void _010_WhenCreate1Ally_And0Enemy_ThenShouldBe1TeamSlot()
        {
            // Arrange.
            var contexts = Contexts.Instance;

            // Act.
            CreateEntity.New()
                        .Add<UnitID, string>("dummy")
                        .Is<Queued>(true)
                ;
            _feature
                .Add(new PutNewUnitInFirstAvailableSlot())
                .Add(new SpawnTeamSlotForQueuedUnits())
                .Update()
                ;

            // Assert.
            var entities = contexts.Get<Game>().GetGroup(ScopeMatcher<Game>.Get<TeamSlot>());
            var teamSlotsCount = entities.count;
            teamSlotsCount.Should().Be(1);
        }
    }
}