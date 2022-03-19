using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlChannelParametersListEditor : UserControl
    {
        // List
        private readonly List<CtlOneChannelParameters> channelList = new List<CtlOneChannelParameters>();

        // Constructor
        public CtlChannelParametersListEditor()
        {
            InitializeComponent();
        }

        //----------------------------------------------  Events  ------------------------------------------------------------
        // Dropped
        private void Channel_ItemDropped(object sender, EventArgs e)
        {
            CtlOneChannelParameters dragged = (CtlOneChannelParameters)((DragEventArgs)e).Data.GetData(typeof(CtlOneChannelParameters));
            int dragIndex = GetIndex(dragged);
            int dropIndex = GetIndex((CtlOneChannelParameters)sender);

            //MessageBox.Show(string.Format("{0} -> {1}", dragIndex, dropIndex));
            RemoveAt(dragIndex);
            InsertAt(dragged, dropIndex);
        }

        // Selcted Changed
        private void Channel_SelectedChange(object sender, EventArgs e)
        {
            //===============================  Way #1  =====================================
            for (int i = 0; i < channelList.Count; i++)
            {
                channelList[i].Selected = false;
            }
            ((CtlOneChannelParameters)sender).Selected = true;
        }

        //---------------------------------------------  Functions  -----------------------------------------------------------
        // Get Selected Index
        public int GetSelectedIndex()
        {
            int index = -1;
            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i].Selected) index = i;
            }
            return index;
        }

        // Get Index
        public int GetIndex(CtlOneChannelParameters channel)
        {
            int index = -1;
            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i] == channel) index = i;
            }
            return index;
        }

        //--------------------------------------------  List Commands  --------------------------------------------------------
        // Clear List
        public void Clear()
        {
            //===============================  Way #1  =====================================
            foreach (CtlOneChannelParameters channel in channelList)
            {
                //unable event listeners !!!!!!!!!!!!-------------------------------------
                channel.SelectedChange -= Channel_SelectedChange;
                channel.ItemDropped -= Channel_ItemDropped;
                //-------------------------------------------------------------------------

                this.Controls.Remove(channel);
            }
            channelList.Clear();
        }

        // Add New
        public void AddNew()
        {
            //===============================  Way #1  =====================================
            CtlOneChannelParameters channel = new CtlOneChannelParameters();
            Add(channel);
        }

        // Add
        public void Add(CtlOneChannelParameters channel)
        {
            // channel: add event listeners !!!!!!!!!!!!!!!!!!!!!!! -----------------------
            channel.SelectedChange += Channel_SelectedChange;
            channel.ItemDropped += Channel_ItemDropped;
            //-----------------------------------------------------------------------------

            channelList.Add(channel);
            this.Controls.Add(channel);
            MoveItems();
        }

        // Insert At Position
        public void InsertAt(CtlOneChannelParameters channel, int index)
        {
            // channel: add event listeners !!!!!!!!!!!!!!!!!!!!!!! -----------------------
            channel.SelectedChange += Channel_SelectedChange;
            channel.ItemDropped += Channel_ItemDropped;
            //-----------------------------------------------------------------------------

            channelList.Insert(index, channel);
            this.Controls.Add(channel);
            MoveItems();
        }

        // Remove At Position
        public void RemoveAt(int index)
        {
            //unable event listeners !!!!!!!!!!!!-------------------------------------
            channelList[index].SelectedChange -= Channel_SelectedChange;
            channelList[index].ItemDropped -= Channel_ItemDropped;
            //-------------------------------------------------------------------------

            this.Controls.Remove(channelList[index]);
            channelList.RemoveAt(index);
        }

        // Remove Selected
        public void RemoveSelected()
        {
            int sel = GetSelectedIndex();
            if (sel >= 0)
            {
                RemoveAt(sel);
                MoveItems();
            } 
        }

        //------------------------------------------------  Refresh List  -----------------------------------------------------
        // Move Controls
        public void MoveItems()
        {
            for (int i = 0; i < channelList.Count; i++)
            {
                CtlOneChannelParameters channel = channelList[i];
                channel.Location = new Point(0, channel.Height * i);
            }
        }

    }
}
