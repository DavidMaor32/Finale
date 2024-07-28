using System;
using System.Collections.Generic;

using Finale.Enums;

namespace Finale.Models {
    [Serializable]
    public class Data {
        private ushort  lives;
        private TimeSpan time;
        private List<RoomCode>  solved_rooms;

        public RoomCode[] Solved {
            get {
                return this.solved_rooms.ToArray();
            }
        }
        public string Name {
            get; set;
        }

        private static Data instance;

        private Data(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            Name = record.name;
            this.solved_rooms = new List<RoomCode>();
            foreach (RoomCode c in record.solved_rooms)
                this.solved_rooms.Add(c);
        }

        public static Data Instance() {
            if (instance == null)
                instance = new Data(RecordData.Default());

            return instance;
        }

        public void Update(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            Name = record.name;
            this.solved_rooms = new List<RoomCode>();
            foreach (RoomCode c in record.solved_rooms)
                this.solved_rooms.Add(c);
        }

        public void AddInterval(TimeSpan interval) {
            this.time += interval;
        }

        public void AddRoom(RoomCode code) {
            if (this.solved_rooms.Contains(code))
                return;

            this.solved_rooms.Add(code);
        }

        public RecordData Record() {
            return new RecordData(this.time, this.lives, this.solved_rooms.ToArray(), Name);
        }
    }
}
