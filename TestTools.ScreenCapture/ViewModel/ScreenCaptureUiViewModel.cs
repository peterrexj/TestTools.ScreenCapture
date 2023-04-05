using Pj.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.ScreenCapture.ViewModel
{
    public class ScreenCaptureUiViewModel : BaseViewModel
    {
        private FileSystemWatcher watcher;
        private Action actionToCallbackOnForm;
        public ScreenCaptureUiViewModel(Action callbackOnView)
        {
            watcher = new FileSystemWatcher();
            watcher.Filter = "*.png";
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            actionToCallbackOnForm = callbackOnView;
            TextOnGenerateButton = "Generate Doc";
        }

        private string _targetImageStoreFolder;
        public string TargetImageStoreFolder
        {
            get
            {
                return _targetImageStoreFolder;
            }
            set
            {
                watcher.Created -= Watcher_Created;

                IoHelper.CreateDirectory(value);
                _targetImageStoreFolder = value;
                watcher.Path = value;
                watcher.Created += Watcher_Created;
                watcher.EnableRaisingEvents = true;

                ComputeTotalImageFiles();
                OnPropertyChanged("TotalImagesCaptured");
            }
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            actionToCallbackOnForm();
            //ComputeTotalImageFiles();
            //OnPropertyChanged("TotalImagesCaptured");
        }

        public void ComputeTotalImageFiles()
        {
            TotalImagesCaptured = Directory.Exists(TargetImageStoreFolder) ? Directory.EnumerateFiles(TargetImageStoreFolder, "*.png").Count() : 0;
        }

        public List<string> Screens { get; set; }
        public Screen? SelectedScreen { get; set; }

        private bool _enableCapture;
        public bool EnableCapture
        {
            get
            {
                return _enableCapture;
            }
            set
            {
                _enableCapture = value;
                OnPropertyChanged();
                OnPropertyChanged("TextOnToggleCaptureButton");
            }
        }
        public string TextOnToggleCaptureButton => EnableCapture ? "Status: ON" : "Status: OFF";
        public Color ColorOnToggleCaptureButton => EnableCapture ? Color.PaleTurquoise : Color.LightPink;

        private string _textOnGenerateButton;
        public string TextOnGenerateButton
        {
            get { return _textOnGenerateButton; }
            set
            {
                _textOnGenerateButton = value;
                OnPropertyChanged("TextOnGenerateButton");
            }
        }

        public int _totalImagesCaptured;
        public int TotalImagesCaptured
        {
            get
            {
                return _totalImagesCaptured;
            }
            set
            {
                _totalImagesCaptured = value;
                OnPropertyChanged("TotalImagesCaptured");
            }
        }

        public bool IncludePdf { get; set; }
        public bool IncludeXaml { get; set; }
        public bool IncludeXps { get; set; }
        public bool IncludeHtml { get; set; }
    }
}
