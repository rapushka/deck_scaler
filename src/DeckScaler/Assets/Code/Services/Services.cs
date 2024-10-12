using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public class Services
    {
        public static void Init(Data data)
            => Instance = new Services(data);

        private Services(Data data)
        {
            UI = new UI();
            Cameras = new Cameras(data.CamerasData);
            StateMachine = data.StateMachine;
            Ecs = new Ecs();
        }

        public static Services Instance { get; private set; }

        public UI UI { get; }

        public Cameras Cameras { get; }

        public GameStateMachine StateMachine { get; }

        public Ecs Ecs { get; }

        public class Data
        {
            public GameStateMachine StateMachine;
            public Cameras.Data CamerasData;
            public Configs Configs;
        }
    }
}