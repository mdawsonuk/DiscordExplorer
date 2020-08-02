using System.Windows.Forms;

namespace DiscordExplorer.Views
{
    public class EnhancedDataGridView : DataGridView
    {
        private readonly DataGridViewImageAnimator imageAnimator = null;

        public EnhancedDataGridView() : base()
        {
            DoubleBuffered = true;
            imageAnimator = new DataGridViewImageAnimator(this);
        }
    }
}
