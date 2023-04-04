namespace TestTools.ScreenCapture
{
    partial class frmHelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextbox = new RichTextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // richTextbox
            // 
            richTextbox.Location = new Point(0, -1);
            richTextbox.Name = "richTextbox";
            richTextbox.Size = new Size(536, 627);
            richTextbox.TabIndex = 0;
            richTextbox.Text = "";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(435, 630);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmHelp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 661);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(richTextbox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmHelp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Capture Tools - Help";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextbox;
        private Button btnClose;
    }
}