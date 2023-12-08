using System.Windows.Forms;
using FileOperations;

namespace Picture_Viewer
{
    public partial class Viewer : Form
    {
        AllSettings JsonAllSettings = new();
        bool nonNumberEntered = false;
        private string[] images;
        private int index;

        public Viewer(string fileName)
        {
            InitializeComponent();
            FileOperation.MainFile = "PictureViewer";

            JsonAllSettings = FileOperation.GetDefaultSettings();

            FileOperation.ActualFolder = Directory.GetCurrentDirectory();

            JsonAllSettings = FileOperation.ReadSettings();

            JsonAllSettings.JsonSettings.UsageCounter += 1;

            if (!string.IsNullOrEmpty(fileName))
            {
                GetFilesInFolder(fileName);

                PicBx.Image = new Bitmap(fileName);
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i] == fileName)
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(FileOperation.LastPath))
                {
                    OpenFileDialog openFileDialog = new()
                    {
                        Filter = @"Picture files (*.bpm,*.jpg,*.jpeg,*.emf,*.exif,*.gif,*.icon,*.png,*.tiff,*.tif,*.wmf,*.jpe,*.jif,*.jfif,*.jfi,*.apng,*.mng,*.gfa,*.gifv,*.tf8,*.btf)|*.bmp; *.jpg; *.jpeg; *.emf; *.exif; *.gif; *.icon; *.png; *.tiff; *.tif; *.wmf; *.jpe; *.jif; *.jfif; *.jfi; *.apng; *.mng; *.gfa; *.gifv; *.tf8; *.btf"
                    };
                    openFileDialog.ShowDialog();
                    if (openFileDialog.FileName != "")
                    {
                        FileOperation.LastPath = Path.GetDirectoryName(openFileDialog.FileName);
                        GetFilesInFolder(openFileDialog.FileName);
                        LoadNewImage();
                    }
                }
                else
                {
                    GetFilesInFolder(FileOperation.LastPath);
                }
            }

            SetGUI();
        }

        private void SetGUI()
        {
            switch (JsonAllSettings.JsonInterface.FullScreen)
            {
                case "Normal":
                    WindowState = FormWindowState.Normal;
                    break;
                case "":
                    WindowState = FormWindowState.Normal;
                    break;
                case "Minimized":
                    WindowState = FormWindowState.Minimized;
                    break;
                case "Maximized":
                    WindowState = FormWindowState.Maximized;
                    break;
                default: break;
            }

            Width = JsonAllSettings.JsonInterface.WindowWith;
            Height = JsonAllSettings.JsonInterface.WindowHeight;
            Location = new Point(JsonAllSettings.JsonInterface.StartPositionX, JsonAllSettings.JsonInterface.StartPositionY);
        }

        private void GetFilesInFolder(string fileName)
        {
            fileName = string.IsNullOrEmpty(fileName) ? FileOperation.ActualFolder : fileName;
            var imageList = Directory.EnumerateFiles(Path.GetDirectoryName(fileName), "*.*", SearchOption.AllDirectories)
        .Where(s => s.EndsWith(".bmp") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".emf") || s.EndsWith(".exif") || s.EndsWith(".gif") ||
        s.EndsWith(".icon") || s.EndsWith(".png") || s.EndsWith(".tiff") || s.EndsWith(".tif") || s.EndsWith(".wmf") || s.EndsWith(".jpe") ||
        s.EndsWith(".jif") || s.EndsWith(".jfif") || s.EndsWith(".jfi") || s.EndsWith(".apng") || s.EndsWith(".mng") || s.EndsWith(".gfa") ||
        s.EndsWith(".gifv") || s.EndsWith(".tf8") || s.EndsWith(".btf"));
            images = imageList.ToArray();

            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] == fileName)
                {
                    index = i;
                    break;
                }
            }
        }

        private void Viewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }

        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Right || e.KeyCode == Keys.Space || e.KeyCode == Keys.Down)
            {
                nonNumberEntered = true;

                if (index == 0)
                {
                    index = images.Length - 1;
                }
                else
                {
                    index--;
                }
            }
            else if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Left || e.KeyCode == Keys.Back || e.KeyCode == Keys.Up)
            {
                nonNumberEntered = true;

                if (index == (images.Length - 1))
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                nonNumberEntered = true;

                for (int i = 0; i < images.Length; i++)
                {
                    if (i >= index)
                    {
                        images[i] = images[i + 1];

                        if (i == images.Length - 1)
                        {
                            images[i] = "";
                            Array.Resize<string>(ref images, i - 1);
                        }
                    }
                }
            }

            LoadNewImage();
        }

        private void LoadNewImage()
        {
            if (!string.IsNullOrEmpty(images[index]))
            {
                PicBx.Image = new Bitmap(images[index]);
                lblActualImageFilePath.Text = images[index].ToString();
            }
        }

        private void Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileOperation.WriteSettings(JsonAllSettings);
        }

        private void Viewer_LocationChanged(object sender, EventArgs e)
        {
            JsonAllSettings.JsonInterface.StartPositionX = Location.X;
            JsonAllSettings.JsonInterface.StartPositionY = Location.Y;
        }

        private void Viewer_ResizeEnd(object sender, EventArgs e)
        {
            JsonAllSettings.JsonInterface.WindowWith = Width;
            JsonAllSettings.JsonInterface.WindowHeight = Height;
        }
    }
}
