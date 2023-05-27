namespace ShowKeys {
    partial class KeyBoardMapCreationForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            mDummyControl = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 401);
            button1.Name = "button1";
            button1.Size = new Size(96, 37);
            button1.TabIndex = 0;
            button1.Text = "Done";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 360);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(449, 401);
            label1.Name = "label1";
            label1.Size = new Size(339, 33);
            label1.TabIndex = 2;
            label1.Text = "Not Filled Out";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(61, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(727, 23);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Name";
            // 
            // mDummyControl
            // 
            mDummyControl.Location = new Point(218, 411);
            mDummyControl.Name = "mDummyControl";
            mDummyControl.Size = new Size(100, 23);
            mDummyControl.TabIndex = 5;
            mDummyControl.KeyDown += KeyBoardMapCreationForm_KeyDown;
            // 
            // KeyBoardMapCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 443);
            Controls.Add(mDummyControl);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "KeyBoardMapCreationForm";
            Text = "KeyBoardMapCreationForm";
            Load += KeyBoardMapCreationForm_Load;
            KeyDown += KeyBoardMapCreationForm_KeyDown;
            Resize += KeyBoardMapCreationForm_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox mDummyControl;
    }
}