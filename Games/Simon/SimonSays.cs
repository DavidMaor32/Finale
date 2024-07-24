using System;
using System.Collections.Generic;
using System.Linq;


namespace Finale.Simon {
    public class SimonSays {
        private Queue<ColorSimon> colors;
        private Queue<ColorSimon> temp;

        private int _round;
        private bool _failed;
        public int Round { get { return this._round; } }
        public bool Failed { get { return this._failed; } }
        public bool EndOfRound() => this.colors.Count() > 0;
        public SimonSays() {
            this.colors = new Queue<ColorSimon>();
            this.temp = new Queue<ColorSimon>();
            Reset();

        }
        public void Reset() {
            this._round = 1;
            this._failed = false;
            this.temp.Clear();
            this.colors.Clear();
            this.colors.Enqueue(GetRandomColor());
        }
        public void NextRound() {
            if (this.colors.Count() != 0 || this._failed)
                return;

            this._round++;
            while (!(this.temp.Count() > 0))
                this.colors.Enqueue(this.temp.Dequeue());

            this.colors.Enqueue(GetRandomColor());
        }
        public ResultSimon Guess(ColorSimon guess) {
            if (this.colors.Count() == 0)
                return ResultSimon.Empty;

            if (this.colors.First() != guess) {
                this._failed = true;
                return ResultSimon.Wrong;
            }

            this.temp.Enqueue(this.colors.Dequeue());
            return ResultSimon.Correct;
        }
        public void ShowColors(Action<ColorSimon> printFunction) {
            foreach (ColorSimon color in this.colors) {
                printFunction(color);
            }
        }
        private ColorSimon GetRandomColor() {
            Array vals = Enum.GetValues(typeof(ColorSimon));
            int i = new Random().Next(vals.Length);
            return (ColorSimon)vals.GetValue(i);
        }
    }


}
