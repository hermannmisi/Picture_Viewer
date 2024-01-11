using System.Windows.Forms;
using FileOperations;
using LanguageOperations;

namespace Picture_Viewer
{
    public partial class Viewer : Form
    {
        bool nonNumberEntered = false;
        private string[] images;
        private int index;
        string fileExtensions = @"*.bpm,*.jpg,*.jpeg,*.emf,*.exif,*.gif,*.icon,*.png,*.tiff,*.tif,*.wmf,*.jpe,*.jif,*.jfif,*.jfi,*.apng,*.mng,*.gfa,*.gifv,*.tf8,*.btf)|*.bmp; *.jpg; *.jpeg; *.emf; *.exif; *.gif; *.icon; *.png; *.tiff; *.tif; *.wmf; *.jpe; *.jif;*.jfif; *.jfi; *.apng; *.mng; *.gfa; *.gifv; *.tf8; *.btf";

        public Viewer(string fileName)
        {
            InitializeComponent();
            FileOperation.MainFile = "PictureViewer";

            FileOperation.ActualFolder = Directory.GetCurrentDirectory();

            FileOperation.ReadSettings();
            FileOperation.allSettings.Settings.UsageCounter += 1;

            Language.ReadLanguage(FileOperation.allSettings.Settings.UsedLanguage);

            SetGUI();
            SetLanguage();

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
                        Filter = $@"Picture files ({fileExtensions})"
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
        }

        private void SetGUI()
        {
            switch (FileOperation.allSettings.Interface.FullScreen)
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

            Width = FileOperation.allSettings.Interface.WindowWith;
            Height = FileOperation.allSettings.Interface.WindowHeight;
            Location = new Point(FileOperation.allSettings.Interface.StartPositionX, FileOperation.allSettings.Interface.StartPositionY);
        }

        private void SetLanguage()
        {
            this.Text = Language.allLanguageItems.Text.Title;
            MenuItemFile.Text = Language.allLanguageItems.Text.MenuFile;
            SubMenuItemOpen.Text = $"{Language.allLanguageItems.Text.Open}...";
            SubMenuItemExit.Text = Language.allLanguageItems.Text.Exit;

            MenuItemLanguage.Text = Language.allLanguageItems.Text.Language;

            MenuItemSettings.Text = Language.allLanguageItems.Text.Settings;

            MenuItemHelp.Text = Language.allLanguageItems.Text.Help;
            SubMenuItemUpdate.Text = $"{Language.allLanguageItems.Text.Update}...";
            SubMenuItemAbout.Text = $"{Language.allLanguageItems.Text.About}...";
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

            switch (e.KeyCode)
            {
                case Keys.PageDown:
                case Keys.Right:
                case Keys.Space:
                case Keys.Down:
                    nonNumberEntered = true;

                    if (index == 0)
                    {
                        index = images.Length - 1;
                    }
                    else
                    {
                        index--;
                    }
                    break;

                case Keys.PageUp:
                case Keys.Left:
                case Keys.Back:
                case Keys.Up:
                    nonNumberEntered = true;

                    if (index == (images.Length - 1))
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    break;

                case Keys.Delete:
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
                    break;

                case Keys.Escape:
                    nonNumberEntered = true;
                    Viewer_FormClosing(this, null);
                    break;

                default:
                    break;
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

        private void Viewer_FormClosing(object sender, FormClosingEventArgs? e)
        {
            FileOperation.WriteSettings();
        }

        private void Viewer_LocationChanged(object sender, EventArgs e)
        {
            FileOperation.allSettings.Interface.StartPositionX = Location.X;
            FileOperation.allSettings.Interface.StartPositionY = Location.Y;
        }

        private void Viewer_ResizeEnd(object sender, EventArgs e)
        {
            FileOperation.allSettings.Interface.WindowWith = Width;
            FileOperation.allSettings.Interface.WindowHeight = Height;
        }

        private void ExitSubMenuItem_Click(object sender, EventArgs e)
        {
            Viewer_FormClosing(this, null);
            Close();
        }
    }
}
