using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WeighingScaleMiddleware
{
    public partial class Component2 : Component
    {
        public Component2()
        {
            InitializeComponent();
        }

        public Component2(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
