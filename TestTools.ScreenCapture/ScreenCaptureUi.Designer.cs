namespace TestTools.ScreenCapture
{
    partial class ScreenCaptureUi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEnableCapture = new Button();
            txtFolderPath = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnRefreshPreview = new Button();
            picScreenPreview = new PictureBox();
            cboMonitors = new ComboBox();
            btnGenerateWordDoc = new Button();
            label2 = new Label();
            lblTotalFiles = new Label();
            btnLoadPath = new Button();
            chkIncludePdf = new CheckBox();
            chkIncludeXps = new CheckBox();
            chkIncludeHtml = new CheckBox();
            chkIncludeXaml = new CheckBox();
            btnHelp = new Button();
            btnAbout = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picScreenPreview).BeginInit();
            SuspendLayout();
            // 
            // btnEnableCapture
            // 
            btnEnableCapture.Location = new Point(28, 45);
            btnEnableCapture.Name = "btnEnableCapture";
            btnEnableCapture.Size = new Size(145, 45);
            btnEnableCapture.TabIndex = 0;
            btnEnableCapture.Text = "Enable Capture";
            btnEnableCapture.UseVisualStyleBackColor = true;
            btnEnableCapture.Click += btnCapture_Click;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(28, 284);
            txtFolderPath.Multiline = true;
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(376, 81);
            txtFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 266);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 2;
            label1.Text = "Folder path to store screenshots";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefreshPreview);
            groupBox1.Controls.Add(picScreenPreview);
            groupBox1.Controls.Add(cboMonitors);
            groupBox1.Location = new Point(32, 130);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 121);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitors";
            // 
            // btnRefreshPreview
            // 
            btnRefreshPreview.BackgroundImage = Properties.Resources.Refresh_PNG_Transparent_Image;
            btnRefreshPreview.BackgroundImageLayout = ImageLayout.Stretch;
            btnRefreshPreview.Location = new Point(118, 51);
            btnRefreshPreview.Name = "btnRefreshPreview";
            btnRefreshPreview.Size = new Size(42, 44);
            btnRefreshPreview.TabIndex = 2;
            btnRefreshPreview.UseVisualStyleBackColor = true;
            btnRefreshPreview.Click += btnRefreshPreview_Click;
            // 
            // picScreenPreview
            // 
            picScreenPreview.Location = new Point(171, 22);
            picScreenPreview.Name = "picScreenPreview";
            picScreenPreview.Size = new Size(162, 93);
            picScreenPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            picScreenPreview.TabIndex = 1;
            picScreenPreview.TabStop = false;
            // 
            // cboMonitors
            // 
            cboMonitors.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonitors.FormattingEnabled = true;
            cboMonitors.Location = new Point(6, 22);
            cboMonitors.Name = "cboMonitors";
            cboMonitors.Size = new Size(154, 23);
            cboMonitors.TabIndex = 0;
            cboMonitors.SelectedIndexChanged += cboMonitors_SelectedIndexChanged;
            // 
            // btnGenerateWordDoc
            // 
            btnGenerateWordDoc.BackColor = Color.PaleTurquoise;
            btnGenerateWordDoc.Location = new Point(28, 423);
            btnGenerateWordDoc.Name = "btnGenerateWordDoc";
            btnGenerateWordDoc.Size = new Size(145, 45);
            btnGenerateWordDoc.TabIndex = 5;
            btnGenerateWordDoc.Text = "Generate Doc";
            btnGenerateWordDoc.UseVisualStyleBackColor = false;
            btnGenerateWordDoc.Click += btnGenerateWordDoc_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 368);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 6;
            label2.Text = "Total files in the folder:";
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.AutoSize = true;
            lblTotalFiles.Location = new Point(160, 368);
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new Size(13, 15);
            lblTotalFiles.TabIndex = 7;
            lblTotalFiles.Text = "0";
            // 
            // btnLoadPath
            // 
            btnLoadPath.BackColor = Color.PaleTurquoise;
            btnLoadPath.Location = new Point(410, 284);
            btnLoadPath.Name = "btnLoadPath";
            btnLoadPath.Size = new Size(38, 56);
            btnLoadPath.TabIndex = 8;
            btnLoadPath.Text = "...";
            btnLoadPath.UseVisualStyleBackColor = false;
            btnLoadPath.Click += btnLoadPath_Click;
            // 
            // chkIncludePdf
            // 
            chkIncludePdf.AutoSize = true;
            chkIncludePdf.Location = new Point(179, 423);
            chkIncludePdf.Name = "chkIncludePdf";
            chkIncludePdf.Size = new Size(89, 19);
            chkIncludePdf.TabIndex = 9;
            chkIncludePdf.Text = "Include PDF";
            chkIncludePdf.UseVisualStyleBackColor = true;
            // 
            // chkIncludeXps
            // 
            chkIncludeXps.AutoSize = true;
            chkIncludeXps.Location = new Point(179, 448);
            chkIncludeXps.Name = "chkIncludeXps";
            chkIncludeXps.Size = new Size(87, 19);
            chkIncludeXps.TabIndex = 10;
            chkIncludeXps.Text = "Include Xps";
            chkIncludeXps.UseVisualStyleBackColor = true;
            // 
            // chkIncludeHtml
            // 
            chkIncludeHtml.AutoSize = true;
            chkIncludeHtml.Location = new Point(288, 423);
            chkIncludeHtml.Name = "chkIncludeHtml";
            chkIncludeHtml.Size = new Size(95, 19);
            chkIncludeHtml.TabIndex = 11;
            chkIncludeHtml.Text = "Include Html";
            chkIncludeHtml.UseVisualStyleBackColor = true;
            // 
            // chkIncludeXaml
            // 
            chkIncludeXaml.AutoSize = true;
            chkIncludeXaml.Location = new Point(288, 448);
            chkIncludeXaml.Name = "chkIncludeXaml";
            chkIncludeXaml.Size = new Size(151, 19);
            chkIncludeXaml.TabIndex = 12;
            chkIncludeXaml.Text = "Include Xaml Flow Pack";
            chkIncludeXaml.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(179, 45);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(59, 45);
            btnHelp.TabIndex = 13;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnAbout
            // 
            btnAbout.Location = new Point(244, 45);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(59, 45);
            btnAbout.TabIndex = 14;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // ScreenCaptureUi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 480);
            Controls.Add(btnAbout);
            Controls.Add(btnHelp);
            Controls.Add(chkIncludeXaml);
            Controls.Add(chkIncludeHtml);
            Controls.Add(chkIncludeXps);
            Controls.Add(chkIncludePdf);
            Controls.Add(btnLoadPath);
            Controls.Add(lblTotalFiles);
            Controls.Add(label2);
            Controls.Add(btnGenerateWordDoc);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtFolderPath);
            Controls.Add(btnEnableCapture);
            MaximizeBox = false;
            Name = "ScreenCaptureUi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Capture Tools";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picScreenPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEnableCapture;
        private TextBox txtFolderPath;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnGenerateWordDoc;
        private Label label2;
        private Label lblTotalFiles;
        private PictureBox picScreenPreview;
        private ComboBox cboMonitors;
        private Button btnLoadPath;
        private Button btnRefreshPreview;
        private CheckBox chkIncludePdf;
        private CheckBox chkIncludeXps;
        private CheckBox chkIncludeHtml;
        private CheckBox chkIncludeXaml;
        private Button btnHelp;
        private Button btnAbout;
    }
}