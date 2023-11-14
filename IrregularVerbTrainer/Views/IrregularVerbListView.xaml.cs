using System.Windows;

namespace IrregularVerbTrainer.Views
{
    /// <summary>
    /// Логика взаимодействия для IrregularVerbListView.xaml
    /// </summary>
    public partial class IrregularVerbListView : Window
    {
        public IrregularVerbListView(Window owner)
        {
            InitializeComponent();
            Owner = owner;
        }
    }
}
