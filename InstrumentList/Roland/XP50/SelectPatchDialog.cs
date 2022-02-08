using System;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    public partial class SelectPatchDialog : Form
    {
        public delegate void OnPatchChanged(object sender, SelectPatchEventArgs e);

        // Fields
        public event OnPatchChanged PathChanged = null;     // Patch selected event
        private readonly byte[] commandBuffer = new byte[4];         // Selected patch buffer
        private bool selecting = false;                     // Selecting outside
        private int currentBankIndex = -1;                  // Current Bank Index
        private int currentPatchIndex = -1;                 // Current Patch Index

        // Access to patch buffer
        public byte[] CommandBuffer
        {
            get => commandBuffer;
            set
            {
                Array.Copy(value, commandBuffer, 4);
            }
        }

        // Constructor
        public SelectPatchDialog()
        {
            InitializeComponent();

            BankNameConvertor.LoadData();

            lv_PatchList.Items.Clear();
            lv_BankNameList.Items.Clear();
            for (int i = 0; i < BankNameConvertor.BankNamesArray.Length; i++)
            {
                lv_BankNameList.Items.Add(BankNameConvertor.BankNamesArray[i]);
            }
        }

        // Closing...
        private void SelectPatchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            this.Hide();
        }

        // Select Bank
        private void lv_BankNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_BankNameList.SelectedIndices.Count > 0)
            {
                lv_PatchList.Items.Clear();
                int index = lv_BankNameList.SelectedIndices[0];
                for (int i = 0; i < BankNameConvertor.NamesArray[index].Length; i++)
                {
                    lv_PatchList.Items.Add(BankNameConvertor.NamesArray[index][i]);
                }
            }
        }

        // Patch was selected
        private void lv_PatchList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (selecting == true) return;  // If outside selection...
            if ((lv_BankNameList.SelectedIndices.Count == 0) || (lv_PatchList.SelectedIndices.Count == 0)) return;

            GetBankPatchIndexesAndBuffer();

            SetFormCaption();

            PathChanged?.Invoke(this, new SelectPatchEventArgs(commandBuffer));
        }

        // Get Bank/Patch indexes
        public void GetBankPatchIndexesAndBuffer()
        {
            currentBankIndex = lv_BankNameList.SelectedIndices[0];
            currentPatchIndex = lv_PatchList.SelectedIndices[0];

            switch (currentBankIndex)
            {
                case 0:
                    commandBuffer[0] = 0;
                    commandBuffer[1] = 1;
                    break;

                case 1:
                    commandBuffer[0] = 0;
                    commandBuffer[1] = 3;
                    break;

                case 2:
                    commandBuffer[0] = 0;
                    commandBuffer[1] = 4;
                    break;

                case 3:
                    commandBuffer[0] = 0;
                    commandBuffer[1] = 5;
                    break;

                case 4:
                    commandBuffer[0] = 0;
                    commandBuffer[1] = 6;
                    break;

                case 5:
                    commandBuffer[0] = 2;
                    commandBuffer[1] = 1;
                    break;

                case 6:
                    commandBuffer[0] = 2;
                    commandBuffer[1] = 4;
                    break;
            }
            commandBuffer[2] = (byte)((currentPatchIndex & 0xF0) >> 4);
            commandBuffer[3] = (byte)(currentPatchIndex & 0xF);
        }

        // Show selected patch
        public void SelectCurrentPatchName()
        {
            currentPatchIndex = (commandBuffer[2] << 4) + commandBuffer[3];
            currentBankIndex = -1;

            switch (commandBuffer[0])
            {
                case 0:
                    switch (commandBuffer[1])
                    {
                        case 1:
                            currentBankIndex = 0;
                            break;

                        case 3:
                            currentBankIndex = 1;
                            break;

                        case 4:
                            currentBankIndex = 2;
                            break;

                        case 5:
                            currentBankIndex = 3;
                            break;

                        case 6:
                            currentBankIndex = 4;
                            break;
                    }
                    break;

                case 2:
                    switch (commandBuffer[1])
                    {
                        case 1:
                            currentBankIndex = 5;
                            break;

                        case 4:
                            currentBankIndex = 6;
                            break;
                    }
                    break;
            }
            selecting = true;
            lv_BankNameList.Items[currentBankIndex].Selected = true;
            lv_PatchList.Items[currentPatchIndex].Selected = true;
            lv_PatchList.Focus();
            selecting = false;
        }

        // Select Patch
        public void SelectPatchName(byte[] buf)
        {
            CommandBuffer = buf;
            SelectCurrentPatchName();
        }

        // Set Form Caption
        private void SetFormCaption()
        {
            string name = BankNameConvertor.GetPatchName(commandBuffer);
            this.Text = string.Format(name);
        }
        
        // Appaerance
        private void SelectPatchDialog_VisibleChanged(object sender, EventArgs e)
        {
            if ((currentBankIndex < 0) || (currentPatchIndex < 0)) return;
            SelectCurrentPatchName();
        }

        // Shown...
        private void SelectPatchDialog_Shown(object sender, EventArgs e)
        {
            SelectCurrentPatchName();
        }
    }

    public class SelectPatchEventArgs : EventArgs
    {
        public readonly byte[] buffer;

        public SelectPatchEventArgs(byte[] arg)
        {
            buffer = new byte[4];
            Array.Copy(arg, buffer, 4);
        }
    }
}
