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
        ContextMenu cm = new ContextMenu();

        // Override Property
        public override byte ByteValue
        {
            get { return (byte)(base.ByteValue - (byte)shift); }
            set => base.ByteValue = (byte)(value + (byte)shift);
        }

        // Constructor
        public CtlUniversalComboBoxField()
        {
            InitializeComponent();

            caption = "Command:";
            min = 1;
            max = 10;
            shift = 1;
            _value = 1;

            capacity = max - min + 1;
            list = new List<string>();
            for (int i = 0; i < capacity; i++)
            {
                list.Add("");
            }
            loaded = true;
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
            
            cm.MenuItems.Clear();
            capacity = max - min + 1;
            for (int i = 0; i < capacity; i++)
            {
                MenuItem item = cm.MenuItems.Add((i + shift).ToString() + " - " + list[i]);
                item.Click += Item_Click;
                item.OwnerDraw = true;
                item.DrawItem += Item_DrawItem;
            }
            cm.Show(this, e.Location);

        }

        // Owner draw
        private void Item_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.FillRectangle(Picrutes.VisualOptions.backgroundBrush, e.Bounds);
            e.Graphics.DrawRectangle(Picrutes.VisualOptions.borderPen, e.Bounds);
            e.Graphics.DrawString(((MenuItem)sender).Text, Picrutes.VisualOptions.mainFont, Picrutes.VisualOptions.mainBrush, e.Bounds, sf);
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
                MenuItem item = cm.MenuItems[i];
                item.Click -= Item_Click;
                item.DrawItem -= Item_DrawItem;
                if (item.Text == ((MenuItem)sender).Text) selIndex = i;
            }

            if (selIndex >= 0) _value = ValidateValue(selIndex + shift);

            this.Invalidate();
        }
    }
}
