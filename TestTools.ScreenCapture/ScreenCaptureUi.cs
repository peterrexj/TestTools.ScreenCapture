using Pj.Library;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestTools.ScreenCapture.Library;
using TestTools.ScreenCapture.ViewModel;

namespace TestTools.ScreenCapture
{
    public partial class ScreenCaptureUi : Form
    {
        private string _TempPath_ScreenshotPreview = IoHelper.CombinePath(PjUtility.Runtime.ExecutingFolder, "Preview", "PreviewImageMonitor.png");

        #region Key Capture
        private const int MOD_ALT = 0x0001;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;
        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int hotKeyId = 0;

        private void RegisterHotkey()
        {
            try
            {
                hotKeyId = GetHashCode();
                if (!RegisterHotKey(this.Handle, hotKeyId, 0, (int)Keys.PrintScreen))
                {
                    MessageBox.Show("Failed to register hotkey", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == hotKeyId)
                {
                    if (viewModel.SelectedScreen != null)
                    {
                        ScreenshotHelper.TakeScreenshot(IoHelper.CombinePath(txtFolderPath.Text, $"{Guid.NewGuid()}.png"), viewModel.SelectedScreen);
                    }
                }
                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }

        #endregion

        private void EventOnFileWatch()
        {
            this.BeginInvoke(() => viewModel?.ComputeTotalImageFiles());
        }
        public ScreenCaptureUiViewModel viewModel;
        public ScreenCaptureUi()
        {
            InitializeComponent();

            viewModel = new ScreenCaptureUiViewModel(EventOnFileWatch);

            try
            {
                btnEnableCapture.DataBindings.Add(nameof(btnEnableCapture.Text), viewModel, nameof(viewModel.TextOnToggleCaptureButton), true, DataSourceUpdateMode.OnPropertyChanged);
                btnEnableCapture.DataBindings.Add(nameof(btnEnableCapture.BackColor), viewModel, nameof(viewModel.ColorOnToggleCaptureButton), true, DataSourceUpdateMode.OnPropertyChanged);
                cboMonitors.DataBindings.Add(nameof(cboMonitors.DataSource), viewModel, nameof(viewModel.Screens), true, DataSourceUpdateMode.OnPropertyChanged);
                txtFolderPath.DataBindings.Add(nameof(txtFolderPath.Text), viewModel, nameof(viewModel.TargetImageStoreFolder), true, DataSourceUpdateMode.OnPropertyChanged);
                lblTotalFiles.DataBindings.Add(nameof(lblTotalFiles.Text), viewModel, nameof(viewModel.TotalImagesCaptured), true, DataSourceUpdateMode.OnPropertyChanged);
                chkIncludePdf.DataBindings.Add(nameof(chkIncludePdf.Checked), viewModel, nameof(viewModel.IncludePdf), true, DataSourceUpdateMode.OnPropertyChanged);
                chkIncludeHtml.DataBindings.Add(nameof(chkIncludeHtml.Checked), viewModel, nameof(viewModel.IncludeHtml), true, DataSourceUpdateMode.OnPropertyChanged);
                chkIncludeXps.DataBindings.Add(nameof(chkIncludeXps.Checked), viewModel, nameof(viewModel.IncludeXps), true, DataSourceUpdateMode.OnPropertyChanged);
                chkIncludeXaml.DataBindings.Add(nameof(chkIncludeXaml.Checked), viewModel, nameof(viewModel.IncludeXaml), true, DataSourceUpdateMode.OnPropertyChanged);

                IoHelper.RecursiveDeleteFolder(_TempPath_ScreenshotPreview);
                IoHelper.CreateDirectory(_TempPath_ScreenshotPreview);

                viewModel.TargetImageStoreFolder = IoHelper.CombinePath(PjUtility.Runtime.ExecutingFolder, "Capture", DateTimeEx.GetDateTimeReadable());
                viewModel.Screens = Screen.AllScreens.Select(f => f.DeviceName).ToList();
                viewModel.IncludePdf = true;
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                UnregisterHotKey(this.Handle, hotKeyId);
                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private void ShowMessage(string message) => MessageBox.Show(message);
        private void ShowMessageError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private bool ValidateLogic()
        {
            try
            {
                if (viewModel.TargetImageStoreFolder.IsEmpty())
                {
                    ShowMessage("Missing [Folder path to store screenshots]");
                    return false;
                }
                if (viewModel.TargetImageStoreFolder.HasValue())
                {
                    IoHelper.CreateDirectory(viewModel.TargetImageStoreFolder);
                }
                if (Directory.Exists(viewModel.TargetImageStoreFolder) == false)
                {
                    ShowMessage($"Cannot create folder: [{viewModel.TargetImageStoreFolder}]");
                    return false;
                }

                if (viewModel.SelectedScreen == null)
                {
                    ShowMessage("Choose a screen to capture screenshots");
                    return false;
                }

            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
                return false;
            }
            return true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateLogic())
                {
                    viewModel.EnableCapture = !viewModel.EnableCapture;

                    if (viewModel.EnableCapture)
                    {
                        RegisterHotkey();
                    }
                    else
                    {
                        UnregisterHotKey(this.Handle, hotKeyId);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private void cboMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedDisplay = ((ComboBox)sender).SelectedItem.ToString();
                RefreshPreview(selectedDisplay);
                viewModel.SelectedScreen = GetSelectedScreen(selectedDisplay);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private void btnRefreshPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMonitors.SelectedItem != null)
                {
                    var selectedDisplay = cboMonitors.SelectedItem.ToString();
                    RefreshPreview(selectedDisplay);
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private void RefreshPreview(string tryScreenName)
        {
            try
            {
                if (tryScreenName.HasValue())
                {
                    foreach (var screen in Screen.AllScreens)
                    {
                        if (screen.DeviceName == tryScreenName)
                        {
                            ScreenshotHelper.TakeScreenshot(_TempPath_ScreenshotPreview, screen);
                            picScreenPreview.ImageLocation = _TempPath_ScreenshotPreview;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private Screen? GetSelectedScreen(string tryScreenName)
        {
            try
            {
                if (tryScreenName.HasValue())
                {
                    foreach (var screen in Screen.AllScreens)
                    {
                        if (screen.DeviceName == tryScreenName)
                        {
                            return screen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }

            return null;
        }
        private void btnLoadPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                // Set the dialog properties
                dialog.Description = "Select a folder";
                dialog.ShowNewFolderButton = false;
                dialog.SelectedPath = txtFolderPath.Text;

                // Show the dialog and get the result
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    viewModel.TargetImageStoreFolder = dialog.SelectedPath ?? "";
                    EventOnFileWatch();
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }
        }
        private void btnGenerateWordDoc_Click(object sender, EventArgs e)
        {
            EventOnFileWatch();
            if (viewModel.TotalImagesCaptured == 0)
            {
                ShowMessage("There are no images captured, folder is empty!");
                return;
            }

            try
            {
                var inputFile = IoHelper.CombinePath(viewModel.TargetImageStoreFolder, $"InputTemplate.docx");
                IoHelper.DeleteFile(inputFile);
                using (FileStream inputStrm = File.Open(inputFile, FileMode.CreateNew))
                using (Stream strm = AssemblyEx.GetEmbeddedResourceAsStream(PjUtility.Runtime.GetAssembly("TestTools.ScreenCapture"),
                    $"TestTools.ScreenCapture.Library.input.docx"))
                {
                    strm.CopyTo(inputStrm);
                }

                var outputFile = IoHelper.CombinePath(viewModel.TargetImageStoreFolder, $"OutputScreenshots_{DateTimeEx.GetTimestamp()}.docx");
                AsposeWordHelper.GenerateWordDocWithImages(viewModel.TargetImageStoreFolder, inputFile, outputFile,
                    viewModel.IncludePdf, viewModel.IncludeXaml, viewModel.IncludeHtml, viewModel.IncludeXaml);
                IoHelper.DeleteFile(inputFile);
                ShowMessage("Document generated and ready!");
            }
            catch (Exception ex)
            {
                ShowMessageError(ex.Message);
            }

            try
            {
                Process.Start(viewModel.TargetImageStoreFolder);
            }
            catch (Exception)
            {
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHelp frmHelp = new frmHelp("Help");
            frmHelp.ShowDialog();
            this.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHelp frmHelp = new frmHelp("About");
            frmHelp.ShowDialog();
            this.Show();
        }
    }
}