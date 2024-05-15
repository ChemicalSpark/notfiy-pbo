﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notfiy.Core
{
    internal class ViewManager
    {
        public MainForm MainForm { get; set; }


        public void HMoveView(Control userControl)
        {

            MainForm.Controls.Clear();

            MainForm.Controls.Add(userControl);

            MainForm.Refresh();
            MainForm.Activate();
        }

        public static void MoveView(Control control)
        {
            System.Instance.ViewManager.HMoveView(control);
        }
    }
}