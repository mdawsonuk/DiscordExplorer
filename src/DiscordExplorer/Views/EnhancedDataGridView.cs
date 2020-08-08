using System.Drawing;
using System.Windows.Forms;

namespace DiscordExplorer.Views
{
    public class EnhancedDataGridView : DataGridView
    {
        private readonly DataGridViewImageAnimator imageAnimator = null;

        private readonly CheckedListBox visibleColumnsListBox;

        private readonly ToolStripDropDown visibleColumnsPopup;

        public EnhancedDataGridView() : base()
        {
            DoubleBuffered = true;
            AllowUserToOrderColumns = true;
            imageAnimator = new DataGridViewImageAnimator(this);

            CellMouseClick += OnCellMouseClick;
            visibleColumnsListBox = new CheckedListBox
            {
                CheckOnClick = true
            };
            visibleColumnsListBox.ItemCheck += (s, e) => Columns[e.Index].Visible = (e.NewValue == CheckState.Checked); ;

            visibleColumnsPopup = new ToolStripDropDown
            {
                Padding = Padding.Empty
            };
            visibleColumnsPopup.Items.Add(new ToolStripControlHost(visibleColumnsListBox)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                AutoSize = false
            });

            ColumnAdded += (s, e) => visibleColumnsListBox.Height = (visibleColumnsListBox.Items.Count * 16) + 10;
            ColumnRemoved += (s, e) => visibleColumnsListBox.Height = (visibleColumnsListBox.Items.Count * 16) + 10;
        }

        private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                visibleColumnsListBox.Items.Clear();
                foreach (DataGridViewColumn column in Columns)
                {
                    visibleColumnsListBox.Items.Add(column.HeaderText, column.Visible);
                }
                visibleColumnsListBox.Width = 200;
                visibleColumnsPopup.Show(PointToScreen(new Point(e.X, e.Y)));
            }
        }
    }
}
