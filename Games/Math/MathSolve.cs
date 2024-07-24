using System;
namespace Finale.Games {
    public class MathQuiz {
        public static int add(int a, int b) => a + b;
        public static int sub(int a, int b) => a - b;
        public static int mul(int a, int b) => a * b;
        public static int div(int a, int b) => a / b;


        public Expr GetRandomExpression() {
            MathOperator opt = getRandomOpt();
            int a,b;
            if (opt == MathOperator.Div) {
                do {
                    a = new Random().Next(1, 10);
                    b = new Random().Next(1, 10);
                } while (a % b != 0);
            }
            else {
                a = new Random().Next(1, 10);
                b = new Random().Next(1, 10);
            }
            return new Expr(a, b, opt);
        }

        private static MathOperator getRandomOpt() {
            Array vals = Enum.GetValues(typeof(MathOperator));
            int i = new Random().Next(vals.Length);
#pragma warning disable CS8605 // Unboxing a possibly null value.
            return (MathOperator)vals.GetValue(i);
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }
    }
    public readonly struct Expr {
        public Expr(int a, int b, MathOperator op) {
        }
    }

}