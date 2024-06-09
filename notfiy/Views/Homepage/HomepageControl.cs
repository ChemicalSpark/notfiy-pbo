﻿using Krypton.Toolkit;
using notfiy.Views.Other;
using notfiy.Views.Todolist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using notfiy.Controllers;
using notfiy.Entities;
using StatusHelper = notfiy.Helpers.Status;
using CoreViewManager = notfiy.Core.ViewManager;
using notfiy.Views.NoteHomepagePartial;


namespace notfiy.Views.Homepage
{
    public partial class HomepageControl : UserControl
    {
        NoteController NoteController { get; set; }
        List<HomepageItem> HomepageItems = new List<HomepageItem>();
        int IdLabel;
        FlowLayoutPanel FlowLayoutPanel;
        public HomepageControl(int? idLabel = null)
        {
            if (idLabel == null)
            {
                IdLabel = (int)StatusHelper.Default;
            }
            InitializeComponent();
        }
        private void HomepageControl_Load(object sender, EventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            // Mengatur ukuran FlowLayoutPanel
            flowLayoutPanel.Size = new Size(1288, 584); // Contoh ukuran 500x300 piksel
            flowLayoutPanel.Location = new Point(93, 254); // Mengatur lokasi di dalam form

            // Mengatur properti lain jika diperlukan
            flowLayoutPanel.BackColor = Color.White; // Untuk memastikan terlihat
            flowLayoutPanel.AutoScroll = true;
            FlowLayoutPanel = flowLayoutPanel;
            // Menambahkan FlowLayoutPanel ke Form
            this.Controls.Add(flowLayoutPanel);


        }

        private void SetNoteItems()
        {
            List<Note> notes = NoteController.GetAllNote();

            // Menambahkan beberapa tombol ke dalam FlowLayoutPanel
            foreach (Note note in notes)
            {
                HomepageItem homepageItem = new HomepageItem(note, UpdateNoteArangement);

                // Mengatur margin
                homepageItem.Margin = new Padding(3); // Margin kiri, atas, kanan, bawah sama 10 piksel

                // Menambahkan kontrol ke FlowLayoutPanel
                FlowLayoutPanel.Controls.Add(homepageItem);

                // Menambah Event Handler delegate ketika mengeklick note
                homepageItem.Click += delegate
                {
                    CoreViewManager.MoveView(new HomepageDetail(note));
                };

            }
        }

        private void SearchTextbox_Enter(object sender, EventArgs e)
        {
            if (SearchTextbox.Text == "Search")
            {
                SearchTextbox.Text = "\0";
            }

        }

        public void UpdateNoteArangement()
        {
            List<HomepageItem> homepageItems = new List<HomepageItem>();
            // loop pertama untuk mendapatkan yanng di pinned
            foreach (HomepageItem homepageItem in HomepageItems)
            {
                if (homepageItem.IsPinned)
                {
                    homepageItems.Add(homepageItem);
                    HomepageItems.Remove(homepageItem);
                }
            }
            // loop pertama untuk mendapatkan yanng tdk di pinned
            foreach (HomepageItem homepageItem in HomepageItems)
            {
                homepageItems.Add(homepageItem);
            }

            SetNoteItems();
        }

        private void SearchTextbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextbox.Text))
            {
                SearchTextbox.Text = "Search";
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homepageItem1_Load(object sender, EventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            this.Controls.Add(navbar);
            navbar.BringToFront();
            navbar.BackColor = Color.Transparent;
            navbar.Location = new Point(1000, 0);
        }

        private void homepageItem7_Load(object sender, EventArgs e)
        {
        }

        private void kryptonPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homepageItem10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void homepageItem8_Load(object sender, EventArgs e)
        {

        }

        private void homepageItem2_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // button create

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            CoreViewManager.MoveView(new AddNoteHomepage(IdLabel));
        }
    }
}
