﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShowApplication {
    public class ISensorView<T> : UserControl {
        public virtual void Update(T data) { }
    }
}