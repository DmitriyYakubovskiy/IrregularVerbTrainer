using IrregularVerbTrainer.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IrregularVerbTrainer.ViewModels
{
    public class IrregularVerbListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public IReadOnlyCollection<IrregularVerb> ListIrregularVerbs=>verbsCollection.ListIrregularVerbs;

        private readonly IrregularVerbCollection verbsCollection;

        public IrregularVerbListViewModel(IrregularVerbCollection verbsCollection)
        {
            this.verbsCollection = verbsCollection;
            verbsCollection.CollectionChanged += (_, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    OnPropertyChanged(nameof(ListIrregularVerbs));
                }
            };
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
