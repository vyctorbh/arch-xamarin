﻿using Mobile.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mobile.View
{
    public partial class AccordionCell : ViewCell
    {

        public void hide()
        {
            this.Height = 20;
        }

        public void show()
        {
            this.Height = 100;
        }

        public AccordionCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var item = BindingContext as AccordionItem;
            if (item != null)
            {
                item.Cell = this;
            }
        }

        protected override void OnTapped()
        {
            base.OnTapped();

            var accordion = Parent as InfiniteListView;
            if (accordion != null)
            {
                accordion.Toggle(this);
            }
        }

        #region IsSelected

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create<AccordionCell, bool>(p => p.IsSelected, default(bool), BindingMode.TwoWay, null, OnIsSelectedChanged);

        private static void OnIsSelectedChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            var source = bindable as AccordionCell;
            if (source == null)
            {
                return;
            }
            source.OnIsSelectedChanged();
        }

        private void OnIsSelectedChanged()
        {
            OnPropertyChanged("IsSelected");
        }

        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        #endregion IsSelected
    }
}
