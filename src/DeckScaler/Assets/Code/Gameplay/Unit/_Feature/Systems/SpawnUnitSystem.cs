using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnUnitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SpawnUnitRequest>()
                    .And<OnSide>()
            );

        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        public void Execute()
        {
            foreach (var request in _requests)
            {
                var unitID = request.Get<SpawnUnitRequest, UnitIDRef>();
                var side = request.Get<OnSide, Side>();
                var isLead = request.Is<Lead>();

                request.Add<Destroy>();

                if (isLead)
                {
                    Factory.CreateLead(unitID);
                    continue;
                }

                // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault - fuck you
                _ = side switch
                {
                    Side.Player => Factory.CreateTeammate(unitID),
                    Side.Enemy  => Factory.CreateEnemy(unitID),
                    _           => throw new ArgumentOutOfRangeException(nameof(side), side, null),
                };
            }
        }
    }
}