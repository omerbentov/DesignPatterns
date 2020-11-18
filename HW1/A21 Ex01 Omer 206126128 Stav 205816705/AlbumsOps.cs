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
        public static void addAlbums(Point i_PicLocation, int i_NumOfAlbums, GroupBox i_feedGroupBox)
        {
            FacebookObjectCollection<Album> albums = LoggedInUserData.User.Albums;

            foreach (Album album in albums)
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
                i_feedGroupBox.Controls.Add(albumPicture);

                Label albumName = new Label();
                albumName.Text = album.Name;
                albumName.ForeColor = Color.Black;
                albumName.Location = new Point(i_PicLocation.X, i_PicLocation.Y - albumName.Size.Height);
                i_feedGroupBox.Controls.Add(albumName);

                Point countLabelPoint = new Point(i_PicLocation.X, i_PicLocation.Y + albumPicture.Height);
                Label albumCount = MainOps.CreateNewDefaultLabel(album.Count + " Photos", countLabelPoint, i_feedGroupBox);
                i_feedGroupBox.Controls.Add(albumCount);

                i_PicLocation = calculateNextAlbumCUverPhotoPosition(i_PicLocation);
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
