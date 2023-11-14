using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace IrregularVerbTrainer.Models
{
    public class IrregularVerbCollection : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public readonly ObservableCollection<IrregularVerb> ListIrregularVerbs;

        public IrregularVerbCollection(List<IrregularVerb> ListIrregularVerbs)
        {
            this.ListIrregularVerbs = new ObservableCollection<IrregularVerb>(ListIrregularVerbs);
            OnPropertyChanged(NotifyCollectionChangedAction.Add, new[] { ListIrregularVerbs });
        }

        public IrregularVerbCollection():this(new List<IrregularVerb>()) { }

        public void Add(IrregularVerb irregularVerb)
        {
            ListIrregularVerbs.Add(irregularVerb);
            OnPropertyChanged(NotifyCollectionChangedAction.Add,new[] { irregularVerb });
        }

        public void Remove(IrregularVerb irregularVerb)
        {
            ListIrregularVerbs.Remove(irregularVerb);
            OnPropertyChanged(NotifyCollectionChangedAction.Remove, new[] { irregularVerb });  
        }

        public void ReadFile(string path)
        {
            var document = XDocument.Load(path);
            var xElementsVerbs = document.Descendants("IrregularVerb");
            foreach (var xElementVerb in xElementsVerbs)
            {
                IrregularVerb verb = new IrregularVerb();
                verb.Translation = xElementVerb.Attribute("Translation").Value;
                verb.FirstForm = xElementVerb.Element("FirstForm").Value;
                verb.SecondForm = xElementVerb.Element("SecondForm").Value;
                verb.ThirdForm = xElementVerb.Element("ThirdForm").Value;
                verb.Points = Convert.ToInt32(xElementVerb.Element("Points").Value);
                ListIrregularVerbs.Add(verb);
            }
        }

        public void ToFile(string path)
        {
            var xElementsVerbs = new XElement("IrregularVerbs");

            foreach (var verb in ListIrregularVerbs)
            {
                xElementsVerbs.Add(CreateVerb(verb));
            }

            var document = new XDocument();
            document.Add(xElementsVerbs);
            document.Save(path);
        }

        private XElement CreateVerb(IrregularVerb verb)
        {
            var xElementVerb = new XElement("IrregularVerb");
            xElementVerb.Add(new XAttribute("Translation", verb.Translation));
            xElementVerb.Add(new XElement("FirstForm", verb.FirstForm));
            xElementVerb.Add(new XElement("SecondForm", verb.SecondForm));
            xElementVerb.Add(new XElement("ThirdForm", verb.ThirdForm));
            xElementVerb.Add(new XElement("Points", verb.Points));
            return xElementVerb;
        }

        private void OnPropertyChanged(NotifyCollectionChangedAction action, IList changedItems)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItems));
        }
    }
}
