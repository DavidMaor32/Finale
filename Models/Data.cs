using System;

using Finale.Enums;

namespace Finale.Models {
    [Serializable]
    public class Data {
        private ushort  lives;
        private TimeSpan time;
        private RoomCode[]  solved_rooms;

        private static Data instance;

        private Data(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            this.solved_rooms = record.solved_rooms;
        }

        public static Data Instance() {
            if (instance == null)
                instance = new Data(RecordData.Default());

            return instance;
        }

        public void Update(RecordData record) {
            this.lives = record.lives;
            this.time = record.time;
            this.solved_rooms = record.solved_rooms;
        }

        public void AddInterval(TimeSpan interval) {
            this.time += interval;
        }

        public RecordData Record() {
            return new RecordData(this.time, this.lives, this.solved_rooms);
        }

        public override string ToString() {
            return $"time:{time.ToString()} lives:{lives} rooms:{solved_rooms.ToString()}";
        }
    }
}
