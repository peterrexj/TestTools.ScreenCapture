using System.Drawing;
using TestTools.ScreenCapture.ViewModel;

namespace TestTools.ScreenCapture.Tests
{
    public class Tests
    {
        private ScreenCaptureUiViewModel viewModel;
        private string targetImageStoreFolder;

        [SetUp]
        public void SetUp()
        {
            targetImageStoreFolder = Path.Combine(Path.GetTempPath(), "TestImages");
            Directory.CreateDirectory(targetImageStoreFolder);

            viewModel = new ScreenCaptureUiViewModel(() => { });
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(targetImageStoreFolder, true);
        }

        [Test]
        public void Watcher_Created_ShouldInvokeCallback()
        {
            // Arrange
            bool callbackInvoked = false;
            viewModel = new ScreenCaptureUiViewModel(() => callbackInvoked = true);
            viewModel.TargetImageStoreFolder = targetImageStoreFolder;

            // Act
            string testFilePath = Path.Combine(targetImageStoreFolder, "test.png");
            File.WriteAllText(testFilePath, "Test content");

            // Wait for the watcher event to be triggered (if necessary)

            // Assert
            Assert.IsTrue(callbackInvoked);
        }

        [Test]
        public void ComputeTotalImageFiles_ShouldReturnCorrectCount()
        {
            // Arrange
            viewModel.TargetImageStoreFolder = targetImageStoreFolder;

            string filePath1 = Path.Combine(targetImageStoreFolder, "file1.png");
            File.WriteAllText(filePath1, "Test content");

            string filePath2 = Path.Combine(targetImageStoreFolder, "file2.png");
            File.WriteAllText(filePath2, "Test content");

            // Act
            viewModel.ComputeTotalImageFiles();

            // Assert
            Assert.AreEqual(2, viewModel.TotalImagesCaptured);
        }

        [Test]
        public void EnableCapture_Set_ShouldUpdateProperties()
        {
            // Act
            viewModel.EnableCapture = true;

            // Assert
            Assert.IsTrue(viewModel.EnableCapture);
            Assert.AreEqual("Status: ON", viewModel.TextOnToggleCaptureButton);
            Assert.AreEqual(Color.PaleTurquoise, viewModel.ColorOnToggleCaptureButton);
        }
    }
}