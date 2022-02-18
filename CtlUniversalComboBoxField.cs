using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class CtlUniversalComboBoxField : CtlByteField
    {
        public event EventHandler CommandChanged = null;

        // Fields
        private readonly int shift;
        private readonly List<string> list;
        private int capacity = 0;
        private bool loaded = false;
        ContextMenuStrip contextMenu = new ContextMenuStrip();

        // Override Property
        public override byte ByteValue
        {
            get { return (byte)(base.ByteValue - (byte)shift); }
            set => base.ByteValue = (byte)(value + (byte)shift);
        }

        // Constructor
        public CtlUniversalComboBoxField()
        {
            caption = "Command:";
            min = 1;
            max = 10;
            shift = 1;
            _value = 1;
            capacity = max - min + 1;
            list = new List<string>();

            InitializeComponent();

            ValueChanged += CtlUniversalComboBoxField_ValueChanged;


            for (int i = 0; i < capacity; i++)
            {
                list.Add("");
            }
            loaded = true;
        }

        private void CtlUniversalComboBoxField_ValueChanged(object sender, EventArgs e)
        {
            CommandChanged?.Invoke(sender, e);
        }

        // Set String Value at Index Position
        public void SetStringValue(int intValue, string strValue)
        {
            int index = ValidateValue(intValue) - shift;
            list[intValue] = strValue;
        }

        // Validate Override
        protected override int ValidateValue(int argument)
        {
            return base.ValidateValue(argument);
        }

        // Override Calculation Bounds
        protected override void CalculateBounds()
        {
            base.CalculateBounds();
        }

        // Override Draw function
        public override void Drawing(Graphics gr)
        {
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            if (loaded)
            {
                string text = "";
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        text = _value.ToString() + " - " + list[_value - shift];
                    }
                    gr.DrawString(text, Font, new SolidBrush(ForeColor), rect, sf);
                }
            }
        }

        // Override Begin Edit function
        public override void BeginEdit()
        {
            tbEnter.Text = list[_value - shift];
            tbEnter.Location = rect.Location;
            this.Controls.Add(tbEnter);
            tbEnter.Focus();
        }

        // Override End Edit function
        public override void EndEdit(object sender, KeyEventArgs e)
        {
            list[_value - shift] = tbEnter.Text;
            this.Controls.Remove(tbEnter);
            this.Invalidate();
            e.Handled = true;
            CommandChanged?.Invoke(sender, e);
        }

        // Show Context Menu with Commsnd List
        public override void RightClick(object sender, MouseEventArgs e)
        {

            contextMenu.Items.Clear();
            capacity = max - min + 1;
            for (int i = 0; i < capacity; i++)
            {
                ToolStripItem item = contextMenu.Items.Add((i + shift).ToString() + " - " + list[i]);

                item.Click += Item_Click;
                item.Paint += Item_Paint;

                contextMenu.Items.Add(item);
            }
            contextMenu.Show(this, e.Location);
            
        }

        // Context Menu Item Paint
        private void Item_Paint(object sender, PaintEventArgs e)
        {
            ToolStripItem customItem = (ToolStripItem)sender;
            customItem.BackColor = Picrutes.VisualOptions.backgroundColor;
            customItem.ForeColor = Picrutes.VisualOptions.mainTextColor;
        }

        // Select Command in Context Menu
        private void Item_Click(object sender, EventArgs e)
        {
            SelectionChanged(sender, e);
        }

        // TO DO when selection in Context Menu Changed
        public virtual void SelectionChanged(object sender, EventArgs e)
        {
            int selIndex = -1;
            for (int i = 0; i < capacity; i++)
            {
                ToolStripItem item = contextMenu.Items[i];
                item.Click -= Item_Click;
                item.Paint -= Item_Paint;
                if (item.Text == ((ToolStripItem)sender).Text) selIndex = i;
            }

            if (selIndex >= 0) Value = ValidateValue(selIndex + shift);

            this.Invalidate();

            CommandChanged?.Invoke(sender, e);
        }
    }
}
