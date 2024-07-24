using System.Windows.Forms;

using Finale.Forms.Rooms;

namespace Finale {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            RoomSimonSays roomSymonSays = new RoomSimonSays();
            Hide();
            roomSymonSays.Show();

        }
    }
}
