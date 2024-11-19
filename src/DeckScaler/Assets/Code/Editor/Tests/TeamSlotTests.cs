using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

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

            Contexts.Instance.EntityIDIndex().Initialize();

            Services.Setup<IFactories>(new Mocks.Factories());

            // ReSharper disable once Unity.UnknownResource - it actually exists
            Services.Setup<IConfigs>(Resources.Load<Configs>("Configs"));

            Services.Setup<IProgress>(new Mocks.Progress());
            Services.Get<IProgress>().StartNewRun();
        }

        [TearDown]
        public void TearDown()
        {
            _feature.Dispose();
            Contexts.Instance.Get<Game>().DestroyAllEntities();
        }

        [Test]
        public void _000_WhenCreate0Allies_And0Enemies_ThenShouldBe0TeamSlot()
        {
            TestTeamSlotsSpawn(
                teammateCount: 0,
                enemyCount: 0,
                expectedSlotCount: 0
            );
        }

        [Test]
        public void _010_WhenCreate1Ally_And0Enemies_ThenShouldBe1TeamSlot()
        {
            TestTeamSlotsSpawn(
                teammateCount: 1,
                enemyCount: 0,
                expectedSlotCount: 1
            );
        }

        [Test]
        public void _020_WhenCreate0Allies_And1Enemy_ThenShouldBe1TeamSlot()
        {
            TestTeamSlotsSpawn(
                teammateCount: 0,
                enemyCount: 1,
                expectedSlotCount: 1
            );
        }

        [Test]
        public void _030_WhenCreate2Allies_And0Enemies_ThenShouldBe2TeamSlots()
        {
            TestTeamSlotsSpawn(
                teammateCount: 2,
                enemyCount: 0,
                expectedSlotCount: 2
            );
        }

        [Test]
        public void _040_WhenCreate1Allies_And1Enemies_ThenShouldBe1TeamSlots()
        {
            TestTeamSlotsSpawn(
                enemyCount: 1,
                teammateCount: 1,
                expectedSlotCount: 1
            );
        }

        [Test]
        public void _050_WhenCreate2Allies_And1Enemies_ThenShouldBe2TeamSlots()
        {
            TestTeamSlotsSpawn(
                enemyCount: 2,
                teammateCount: 1,
                expectedSlotCount: 2
            );
        }

        [Test]
        public void _060_WhenCreate2Allies_And3Enemies_ThenShouldBe3TeamSlots()
        {
            TestTeamSlotsSpawn(
                enemyCount: 2,
                teammateCount: 3,
                expectedSlotCount: 3
            );
        }

        private void TestTeamSlotsSpawn(int teammateCount, int enemyCount, int expectedSlotCount)
        {
            // Arrange.
            var contexts = Contexts.Instance;

            // Act.
            for (var i = 0; i < teammateCount; i++)
            {
                CreateEntity.New()
                            .Add<UnitID, string>(string.Empty)
                            .Is<Queued>(true)
                            .Is<Teammate>(true)
                    ;
            }

            for (var i = 0; i < enemyCount; i++)
            {
                CreateEntity.New()
                            .Add<UnitID, string>(string.Empty)
                            .Is<Queued>(true)
                            .Is<Enemy>(true)
                    ;
            }

            _feature.Add(new TeamSlotsFeature()).Update();

            // Assert.
            var entities = contexts.Get<Game>().GetGroup(ScopeMatcher<Game>.Get<TeamSlot>());
            var teamSlotsCount = entities.count;
            teamSlotsCount.Should().Be(expectedSlotCount);
        }
    }
}