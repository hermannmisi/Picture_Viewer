namespace Picture_Viewer
{
    public partial class Viewer : Form
    {
        private string[] images;
        private int index;

        public Viewer()
        {
            Startup("");
        }

        public Viewer(string fileName)
        {
            Startup(fileName);
        }

        private void Startup(string fileName)
        {
            InitializeComponent();

            fileName = @"d:\Misi\Fejlesztesek\!Fajlok\color_Palette.bmp";
            if (!string.IsNullOrEmpty(fileName))
            {
                images = Directory.GetFiles(Path.GetDirectoryName(fileName));

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
        }
    }
}
