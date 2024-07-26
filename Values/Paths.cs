using System.IO;

namespace Finale.Values {
    public static class Paths {
        private static readonly string s_base = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        public  static readonly string s_games = Path.Combine(s_base, "SavedGames");
    }
}
