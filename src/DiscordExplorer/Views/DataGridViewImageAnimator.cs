// Taken from https://stackoverflow.com/questions/4570128/how-to-include-an-animated-gif-in-a-datagridview

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiscordExplorer.Views
{
    public class DataGridViewImageAnimator
    {
        private class RowCol
        {
            public int Column { get; set; }
            public int Row { get; set; }

            public RowCol(int column, int row)
            {
                Column = column;
                Row = row;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                RowCol other = obj as RowCol;
                if (other == null)
                    return false;

                return (other.Column == Column && other.Row == Row);
            }

            public bool Equals(RowCol other)
            {
                if (other == null)
                    return false;

                return (other.Column == Column && other.Row == Row);
            }

            public override int GetHashCode()
            {
                return Column.GetHashCode() ^ Row.GetHashCode();
            }

            public static bool operator ==(RowCol a, RowCol b)
            {
                // If both are null, or both are same instance, return true.
                if (ReferenceEquals(a, b))
                {
                    return true;
                }

                // If one is null, but not both, return false.
                if ((a is null) || (b is null))
                {
                    return false;
                }

                // Return true if the fields match:
                return a.Column == b.Column && a.Row == b.Row;
            }

            public static bool operator !=(RowCol a, RowCol b)
            {
                return !(a == b);
            }
        }

        private class AnimatedImage
        {
            private DataGridView DataGridView { get; set; }
            private readonly HashSet<RowCol> cells = new HashSet<RowCol>();

            public Image Image { get; set; }

            public AnimatedImage(Image image, DataGridView dataGridView)
            {
                Image = image;
                DataGridView = dataGridView;
            }

            public bool IsUsed { get { return cells.Count > 0; } }

            public void AddCell(RowCol rowCol)
            {
                Debug.Assert(!cells.Contains(rowCol));

                if (!cells.Contains(rowCol))
                {
                    cells.Add(rowCol);

                    if (cells.Count == 1)
                    {
                        // this is the first cell we are using this image, so start animation
                        ImageAnimator.Animate(Image, new EventHandler(OnFrameChanged));
                    }
                }
            }

            public void RemoveCell(RowCol rowCol)
            {
                Debug.Assert(cells.Contains(rowCol));

                if (cells.Contains(rowCol))
                {
                    cells.Remove(rowCol);

                    if (cells.Count == 0)
                    {
                        // this was the last cell we were using this image, so stop animation
                        ImageAnimator.StopAnimate(Image, new EventHandler(OnFrameChanged));
                    }
                }
            }

            private void OnFrameChanged(object o, EventArgs e)
            {
                // invalidate each cell in which it's being used
                RowCol[] rcs = new RowCol[cells.Count];
                cells.CopyTo(rcs);
                foreach (RowCol rc in rcs)
                {
                    DataGridView.InvalidateCell(rc.Column, rc.Row);
                }
            }
        }

        private readonly Dictionary<RowCol, Image> values = new Dictionary<RowCol, Image>();
        private readonly Dictionary<Image, AnimatedImage> animatedImages = new Dictionary<Image, AnimatedImage>();
        private readonly DataGridView dataGridView;

        public DataGridViewImageAnimator(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            this.dataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(OnDatagridCellPainting);
        }

        void OnDatagridCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                object value = dataGridView[e.ColumnIndex, e.RowIndex].Value;
                CheckValue(e.ColumnIndex, e.RowIndex, value);
                ImageAnimator.UpdateFrames();
            }
        }

        private void AddImage(RowCol rowCol, Image image)
        {
            values[rowCol] = image;

            if (!animatedImages.TryGetValue(image, out AnimatedImage animatedImage))
            {
                animatedImage = new AnimatedImage(image, dataGridView);
                animatedImages[image] = animatedImage;
            }

            animatedImage.AddCell(rowCol);
        }

        private void RemoveImage(RowCol rowCol, Image image)
        {
            Debug.Assert(values.ContainsKey(rowCol));
            Debug.Assert(animatedImages.ContainsKey(image));

            values.Remove(rowCol);

            if (animatedImages.TryGetValue(image, out AnimatedImage animatedImage))
            {
                animatedImage.RemoveCell(rowCol);
                if (!animatedImage.IsUsed)
                {
                    animatedImages.Remove(image);
                }
            }
        }

        private void CheckValue(int columnIndex, int rowIndex, object value)
        {
            RowCol rowCol = new RowCol(columnIndex, rowIndex);

            // is the new value an Image, and can it be animated?
            Image newImage = value as Image;
            bool newValueIsImage = (newImage != null && ImageAnimator.CanAnimate(newImage));

            // is there a previous image value?
            if (values.TryGetValue(rowCol, out Image oldImage))
            {
                if (newImage == oldImage)
                {
                    // same old image --> nothing else to do
                    return;
                }

                RemoveImage(rowCol, oldImage);
            }

            if (newValueIsImage)
            {
                AddImage(rowCol, newImage);
            }
        }
    }
}