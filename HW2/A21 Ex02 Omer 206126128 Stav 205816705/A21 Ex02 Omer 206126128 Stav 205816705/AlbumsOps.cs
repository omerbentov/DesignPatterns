using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class AlbumsOps
    {
        private static FacebookObjectCollection<Album> s_Albums;
        private static bool s_IsFetched = false;

        public static void FetchAlbums()
        {
            s_Albums = LoggedInUserData.User.Albums;
            s_IsFetched = true;
        }

        public static void addAlbums(Point i_PicLocation, int i_NumOfAlbums, GroupBox i_feedGroupBox)
        {
            try
            {
                while (!s_IsFetched) ;

                foreach (Album album in s_Albums)
                {
                    if (i_NumOfAlbums <= 0)
                    {
                        break;
                    }
                    i_NumOfAlbums--;

                    PictureBox albumPicture = new PictureBox();
                    albumPicture.Size = new System.Drawing.Size(150, 150);
                    albumPicture.Location = i_PicLocation;
                    albumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    albumPicture.LoadAsync(album.PictureAlbumURL);
                    i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumPicture)));

                    Label albumName = new Label();
                    albumName.Text = album.Name;
                    albumName.ForeColor = Color.Black;
                    albumName.Location = new Point(i_PicLocation.X, i_PicLocation.Y - albumName.Size.Height);
                    i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumName)));

                    Point countLabelPoint = new Point(i_PicLocation.X, i_PicLocation.Y + albumPicture.Height);
                    Label albumCount = MainOps.CreateNewDefaultLabel(album.Count + " Photos", countLabelPoint, i_feedGroupBox);
                    i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumCount)));

                    i_PicLocation = calculateNextAlbumCUverPhotoPosition(i_PicLocation);
                }
            }
            catch (Exception e)
            {
                MainOps.CreateNewErrMessage(i_feedGroupBox);
            }
        }

        private static Point calculateNextAlbumCUverPhotoPosition(Point i_prevPoint)
        {
            int x = i_prevPoint.X;
            int y = i_prevPoint.Y;

            x = (x + 200) % 400;
            if (x <= 50)
            {
                y += 220;
            }

            return new Point(x, y);
        }
    }
}
