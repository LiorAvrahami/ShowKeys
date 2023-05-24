using System.Runtime.InteropServices;
using static KeyboardHook;

namespace ShowKeys {
    public partial class Form1 : Form {

        int[] INITUATOR_KEYS = { 81, 19 };

        KeyboardHook keyboardHook;

        bool inituator_pressed;

        public Form1() {
            InitializeComponent();
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyIntercepted += On_Global_Key_Update;
            keyboardHook.ShouldBlockKey += should_supress;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            // label1.Text = e.KeyValue.ToString();
        }

        public void On_Global_Key_Update(KeyboardHookEventArgs e) {
            if (INITUATOR_KEYS.Contains(e.KeyCode)) {
                if (e.IsPressed) {
                    if (inituator_pressed == false) {
                        inituator_pressed = true;
                        this.bring_to_front();
                    }
                } else {
                    if (inituator_pressed) {
                        inituator_pressed = false;
                        Hide();
                    }
                }
            }

            int selectted_key = -1;
            if (e.IsPressed) {
                selectted_key = e.KeyCode;
                label1.Text = e.KeyName;
            }

        }

        public bool should_supress(KeyboardHookEventArgs e) {
            if (INITUATOR_KEYS.Contains(e.KeyCode)) {
                return true;
            }
            return inituator_pressed;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr SetForegroundWindow();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void bring_to_front() {
            // don't know why, but this seems to always bring this from to the front.
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Enabled = false;
            Hide();
        }
    }
}