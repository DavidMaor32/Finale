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
                return solved_rooms.ToArray();
            } 
        }

        private static Data instance;

        private Data(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            this.solved_rooms = new List<RoomCode>();
            foreach(RoomCode c in record.solved_rooms)
                solved_rooms.Add(c);
        }

        public static Data Instance() {
            if (instance == null)
                instance = new Data(RecordData.Default());

            return instance;
        }

        public void Update(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            this.solved_rooms = new List<RoomCode>();
            foreach (RoomCode c in record.solved_rooms)
                solved_rooms.Add(c);
        }

        public void AddInterval(TimeSpan interval) {
            this.time += interval;
        }

        public void AddRoom(RoomCode code) {
            if(solved_rooms.Contains(code)) return;

            solved_rooms.Add (code);
        }

        public RecordData Record() {
            return new RecordData(this.time, this.lives, this.solved_rooms.ToArray());
        }

        public bool Exists(RoomCode code) => solved_rooms.Contains(code);

        public override string ToString() {
            return $"time:{time.ToString()} lives:{lives} rooms:{solved_rooms.ToString()}";
        }
    }
}
