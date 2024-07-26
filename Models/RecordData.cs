using System;

using Finale.Enums;

namespace Finale.Models {
    [Serializable]
    public readonly struct RecordData {
        private static readonly TimeSpan    DEFAULT_TIME =          TimeSpan.Zero;
        private static readonly ushort      DEFAULT_LIFE =          3;
        private static readonly RoomCode[]  DEFAULT_SOLVED_ROOMS =  { };


        public readonly TimeSpan time;
        public readonly ushort lives;
        public readonly RoomCode[] solved_rooms;

        public RecordData(TimeSpan t, ushort l, RoomCode[] solved) {
            this.time = t;
            this.lives = l;

            RoomCode[] temp = new RoomCode[solved.Length];
            solved.CopyTo(temp, 0);             //deep copy! not shallow copy
            this.solved_rooms = temp;
        }

        public static RecordData Default() {
            return new RecordData(DEFAULT_TIME, DEFAULT_LIFE, DEFAULT_SOLVED_ROOMS);
        }

        public override string ToString() {
            return $"time:{this.time.ToString()} lives:{this.lives} rooms:{this.solved_rooms.ToString()}";
        }
    }

}