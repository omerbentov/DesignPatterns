using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public static class AlbumsOps
    {
        private const int k_PictureSize = 200;
        private const string k_SorText = "Sort by number of photos";

        private static Point s_DeafulteBaseLocation = new Point(20, 10);
        private static Size s_AlbumPictureSize = new Size(150, 150);

        public static int NumInArow
        {
            get
            {
                return MainFeedForm.DefaultCenterWidth / k_PictureSize;
            }
        }

        private static Point m_PicLocation = new Point(20, 10);

        public static void addAlbums(Point? i_BaseLocation,int i_NumOfAlbums, Control i_ControlGroup, FacebookObjectCollection<Album> i_Albums)
        {
            if (i_BaseLocation == null)
            {
                Button sortBtn = new Button();
                sortBtn.Text = k_SorText;
                sortBtn.Location = s_DeafulteBaseLocation;
                sortBtn.Click += (sender_, EventArgs) =>
                {
                    SortLabel_Click(
                        sender_,
                        EventArgs,
                        i_ControlGroup,
                        i_NumOfAlbums);
                }; ;
                sortBtn.BackColor = Color.RoyalBlue;
                i_ControlGroup.Controls.Add(sortBtn);
                m_PicLocation = new Point(sortBtn.Location.X, sortBtn.Location.Y + MainFeedForm.LabelMargin);
            }
            else
            {
                m_PicLocation = (Point)i_BaseLocation;
            }

            foreach (Album album in i_Albums)
            {
                if (i_NumOfAlbums <= 0)
                {
                    break;
                }
                i_NumOfAlbums--;

                PictureBox albumPicture = new PictureBox();
                albumPicture.Size = new System.Drawing.Size(150, 150);
                albumPicture.Location = m_PicLocation;
                albumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                albumPicture.LoadAsync(album.PictureAlbumURL);
                i_ControlGroup.Controls.Add(albumPicture);

                Label albumName = new Label();
                albumName.Text = album.Name;
                albumName.ForeColor = Color.Black;
                albumName.Location = new Point(m_PicLocation.X, m_PicLocation.Y - albumName.Size.Height);
                i_ControlGroup.Controls.Add(albumName);

                Point countLabelPoint = new Point(m_PicLocation.X, m_PicLocation.Y + albumPicture.Height);
                Label albumCount = MainOps.CreateNewDefaultLabel(album.Count + " Photos", countLabelPoint, i_ControlGroup as GroupBox);
                i_ControlGroup.Controls.Add(albumCount);

                m_PicLocation = calculateNextAlbumCUverPhotoPosition(m_PicLocation);
            }
        }

        private static void SortLabel_Click(object sender, EventArgs e, Control i_ControlGroup, int i_NumOfAlbums)
        {
            i_ControlGroup.Controls.Clear();

            FacebookObjectCollection<Album> sortedAlbums = GlobalData.User.Albums;

            for (int i = 0; i < sortedAlbums.Count; i++)
            {
                long maxCount = 0;
                int minAlbumIndex = i;

                for (int j=i; j < sortedAlbums.Count; j++)
                {
                    if (sortedAlbums[j].Count > maxCount)
                    {
                        maxCount = (long)sortedAlbums[j].Count;
                        minAlbumIndex = j;
                    }
                }

                sortedAlbums.Move(minAlbumIndex, i);
            }

            addAlbums(null, i_NumOfAlbums, i_ControlGroup, sortedAlbums);
        }

        private static Point calculateNextAlbumCUverPhotoPosition(Point i_prevPoint)
        {
            int x = i_prevPoint.X;
            int y = i_prevPoint.Y;

            x = (x + k_PictureSize) %  (k_PictureSize * NumInArow);
            if (x <= 50)
            {
                y += 220;
            }

            return new Point(x, y);
        }
    }
}
