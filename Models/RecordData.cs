using System;

using Finale.Enums;

namespace Finale.Models {
    [Serializable]
    public readonly struct RecordData {
        public static readonly TimeSpan    DEFAULT_TIME =          TimeSpan.Zero;
        public static readonly ushort      DEFAULT_LIFE =          3;
        public static readonly RoomCode[]  DEFAULT_SOLVED_ROOMS =  { };
        public static readonly string      DEFAULT_NAME =          "_";


        public readonly TimeSpan time;
        public readonly ushort lives;
        public readonly RoomCode[] solved_rooms;
        public readonly string name;

        public RecordData(TimeSpan t, ushort l, RoomCode[] solved, string n) {
            this.time = t;
            this.lives = l;
            this.name = n;

            RoomCode[] temp = new RoomCode[solved.Length];
            solved.CopyTo(temp, 0);             //deep copy! not shallow copy
            this.solved_rooms = temp;
        }

        public static RecordData Default() {
            return new RecordData(DEFAULT_TIME, DEFAULT_LIFE, DEFAULT_SOLVED_ROOMS, DEFAULT_NAME);
        }

        public override string ToString() {
            return $"name:{this.name} time:{this.time.ToString()} lives:{this.lives} rooms:{this.solved_rooms.ToString()}";
        }
    }

}