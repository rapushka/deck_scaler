using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

namespace DeckScaler.Editor.Tests
{
    public class TeamSlotEnumerationTests
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
        public void _010_WhenCreate1TeamSlot_ThenTeamSlotShouldHaveIndex1()
        {
            // Arrange.
            var factory = Services.Get<IFactories>();

            // Act.
            var entity = factory.CreateTeamSlot();

            // Assert.
            var slotNumber = entity.Get<TeamSlot>().Value;
            slotNumber.Should().Be(0);
        }

        [Test]
        public void _010_WhenCreate2TeamSlot_ThenTeamSlotShouldHaveIndex2()
        {
            // Arrange.
            var factory = Services.Get<IFactories>();

            // Act.
            factory.CreateTeamSlot();
            var secondEntity = factory.CreateTeamSlot();

            // Assert.
            var slotNumber = secondEntity.Get<TeamSlot>().Value;
            slotNumber.Should().Be(1);
        }
    }
}