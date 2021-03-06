using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace SaveNormalSizeAndPosition
{
    public class LayoutData : ViewModelBase
    {
        private string xml;
        public string Xml
        {
            get
            {
                return this.xml;
            }
            set
            {
                if (this.xml != value)
                {
                    this.xml = value;
                    this.OnPropertyChanged("Xml");
                }
            }
        }
    }
}
