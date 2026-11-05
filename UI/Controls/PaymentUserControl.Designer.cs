using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI
{
    partial class PaymentUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlSummary = new Panel();
            lblSummaryTitle = new Label();
            lblGuestName = new Label();
            txtGuestName = new TextBox();
            lblRoom = new Label();
            txtRoom = new TextBox();
            lblCheckIn = new Label();
            txtCheckIn = new TextBox();
            lblCheckOut = new Label();
            txtCheckOut = new TextBox();
            lblGuests = new Label();
            txtGuests = new TextBox();
            pnlTotalDue = new Panel();
            lblTotalDueText = new Label();
            lblTotalDueValue = new Label();
            pnlPayment = new Panel();
            lblPaymentTitle = new Label();
            lblMethod = new Label();
            rdoCash = new RadioButton();
            rdoCard = new RadioButton();
            lblCashTendered = new Label();
            txtCashTendered = new TextBox();
            lblChangeDue = new Label();
            txtChangeDue = new TextBox();
            lblReference = new Label();
            txtReferenceNumber = new TextBox();
            lblReferenceHint = new Label();
            pnlDivider = new Panel();
            lblAfterTitle = new Label();
            lblResStatusText = new Label();
            lblResFrom = new Label();
            lblArrow1 = new Label();
            lblResTo = new Label();
            lblRoomStatusText = new Label();
            lblRoomFrom = new Label();
            lblArrow2 = new Label();
            lblRoomTo = new Label();
            btnSettlePayment = new Button();
            btnBackToBill = new Button();
            lblErrorMessage = new Label();
            pnlSummary.SuspendLayout();
            pnlTotalDue.SuspendLayout();
            pnlPayment.SuspendLayout();
            pnlDivider.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.Controls.Add(pnlTotalDue);
            pnlSummary.Controls.Add(txtGuests);
            pnlSummary.Controls.Add(lblGuests);
            pnlSummary.Controls.Add(txtCheckOut);
            pnlSummary.Controls.Add(lblCheckOut);
            pnlSummary.Controls.Add(txtCheckIn);
            pnlSummary.Controls.Add(lblCheckIn);
            pnlSummary.Controls.Add(txtRoom);
            pnlSummary.Controls.Add(lblRoom);
            pnlSummary.Controls.Add(txtGuestName);
            pnlSummary.Controls.Add(lblGuestName);
            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Location = new Point(24, 24);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(700, 833);
            pnlSummary.BackColor = Color.White;
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            pnlSummary.TabIndex = 0;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Location = new Point(20, 16);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Text = "Stay Summary";
            lblSummaryTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblSummaryTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.UseMnemonic = false;
            lblSummaryTitle.TabIndex = 0;
            // 
            // lblGuestName
            // 
            lblGuestName.Location = new Point(20, 70);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Text = "Guest Name";
            lblGuestName.ForeColor = Color.FromArgb(44, 62, 80);
            lblGuestName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGuestName.AutoSize = true;
            lblGuestName.UseMnemonic = false;
            lblGuestName.TabIndex = 1;
            // 
            // txtGuestName
            // 
            txtGuestName.Location = new Point(20, 96);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(660, 30);
            txtGuestName.Font = new Font("Segoe UI", 11F);
            txtGuestName.ReadOnly = true;
            txtGuestName.BackColor = Color.FromArgb(236, 239, 241);
            txtGuestName.TabIndex = 2;
            // 
            // lblRoom
            // 
            lblRoom.Location = new Point(20, 160);
            lblRoom.Name = "lblRoom";
            lblRoom.Text = "Room";
            lblRoom.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoom.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRoom.AutoSize = true;
            lblRoom.UseMnemonic = false;
            lblRoom.TabIndex = 3;
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(20, 186);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(660, 30);
            txtRoom.Font = new Font("Segoe UI", 11F);
            txtRoom.ReadOnly = true;
            txtRoom.BackColor = Color.FromArgb(236, 239, 241);
            txtRoom.TabIndex = 4;
            // 
            // lblCheckIn
            // 
            lblCheckIn.Location = new Point(20, 250);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Text = "Check-In";
            lblCheckIn.ForeColor = Color.FromArgb(44, 62, 80);
            lblCheckIn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCheckIn.AutoSize = true;
            lblCheckIn.UseMnemonic = false;
            lblCheckIn.TabIndex = 5;
            // 
            // txtCheckIn
            // 
            txtCheckIn.Location = new Point(20, 276);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.Size = new Size(660, 30);
            txtCheckIn.Font = new Font("Segoe UI", 11F);
            txtCheckIn.ReadOnly = true;
            txtCheckIn.BackColor = Color.FromArgb(236, 239, 241);
            txtCheckIn.TabIndex = 6;
            // 
            // lblCheckOut
            // 
            lblCheckOut.Location = new Point(20, 340);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Text = "Check-Out";
            lblCheckOut.ForeColor = Color.FromArgb(44, 62, 80);
            lblCheckOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCheckOut.AutoSize = true;
            lblCheckOut.UseMnemonic = false;
            lblCheckOut.TabIndex = 7;
            // 
            // txtCheckOut
            // 
            txtCheckOut.Location = new Point(20, 366);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.Size = new Size(660, 30);
            txtCheckOut.Font = new Font("Segoe UI", 11F);
            txtCheckOut.ReadOnly = true;
            txtCheckOut.BackColor = Color.FromArgb(236, 239, 241);
            txtCheckOut.TabIndex = 8;
            // 
            // lblGuests
            // 
            lblGuests.Location = new Point(20, 430);
            lblGuests.Name = "lblGuests";
            lblGuests.Text = "Guests";
            lblGuests.ForeColor = Color.FromArgb(44, 62, 80);
            lblGuests.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGuests.AutoSize = true;
            lblGuests.UseMnemonic = false;
            lblGuests.TabIndex = 9;
            // 
            // txtGuests
            // 
            txtGuests.Location = new Point(20, 456);
            txtGuests.Name = "txtGuests";
            txtGuests.Size = new Size(660, 30);
            txtGuests.Font = new Font("Segoe UI", 11F);
            txtGuests.ReadOnly = true;
            txtGuests.BackColor = Color.FromArgb(236, 239, 241);
            txtGuests.TabIndex = 10;
            // 
            // pnlTotalDue
            // 
            pnlTotalDue.Controls.Add(lblTotalDueValue);
            pnlTotalDue.Controls.Add(lblTotalDueText);
            pnlTotalDue.Location = new Point(20, 540);
            pnlTotalDue.Name = "pnlTotalDue";
            pnlTotalDue.Size = new Size(660, 130);
            pnlTotalDue.BackColor = Color.FromArgb(234, 247, 240);
            pnlTotalDue.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalDue.TabIndex = 11;
            // 
            // lblTotalDueText
            // 
            lblTotalDueText.Location = new Point(20, 14);
            lblTotalDueText.Name = "lblTotalDueText";
            lblTotalDueText.Text = "Total Amount Due";
            lblTotalDueText.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalDueText.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblTotalDueText.AutoSize = true;
            lblTotalDueText.UseMnemonic = false;
            lblTotalDueText.TabIndex = 0;
            // 
            // lblTotalDueValue
            // 
            lblTotalDueValue.Location = new Point(20, 50);
            lblTotalDueValue.Name = "lblTotalDueValue";
            lblTotalDueValue.Size = new Size(618, 64);
            lblTotalDueValue.Text = "₱0.00";
            lblTotalDueValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalDueValue.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            lblTotalDueValue.AutoSize = false;
            lblTotalDueValue.UseMnemonic = false;
            lblTotalDueValue.TextAlign = ContentAlignment.MiddleRight;
            lblTotalDueValue.TabIndex = 1;
            // 
            // pnlPayment
            // 
            pnlPayment.Controls.Add(lblErrorMessage);
            pnlPayment.Controls.Add(btnBackToBill);
            pnlPayment.Controls.Add(btnSettlePayment);
            pnlPayment.Controls.Add(lblRoomTo);
            pnlPayment.Controls.Add(lblArrow2);
            pnlPayment.Controls.Add(lblRoomFrom);
            pnlPayment.Controls.Add(lblRoomStatusText);
            pnlPayment.Controls.Add(lblResTo);
            pnlPayment.Controls.Add(lblArrow1);
            pnlPayment.Controls.Add(lblResFrom);
            pnlPayment.Controls.Add(lblResStatusText);
            pnlPayment.Controls.Add(lblAfterTitle);
            pnlPayment.Controls.Add(pnlDivider);
            pnlPayment.Controls.Add(lblReferenceHint);
            pnlPayment.Controls.Add(txtReferenceNumber);
            pnlPayment.Controls.Add(lblReference);
            pnlPayment.Controls.Add(txtChangeDue);
            pnlPayment.Controls.Add(lblChangeDue);
            pnlPayment.Controls.Add(txtCashTendered);
            pnlPayment.Controls.Add(lblCashTendered);
            pnlPayment.Controls.Add(rdoCard);
            pnlPayment.Controls.Add(rdoCash);
            pnlPayment.Controls.Add(lblMethod);
            pnlPayment.Controls.Add(lblPaymentTitle);
            pnlPayment.Location = new Point(748, 24);
            pnlPayment.Name = "pnlPayment";
            pnlPayment.Size = new Size(1148, 833);
            pnlPayment.BackColor = Color.White;
            pnlPayment.BorderStyle = BorderStyle.FixedSingle;
            pnlPayment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPayment.TabIndex = 1;
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.Location = new Point(20, 16);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Text = "Payment";
            lblPaymentTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblPaymentTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.UseMnemonic = false;
            lblPaymentTitle.TabIndex = 0;
            // 
            // lblMethod
            // 
            lblMethod.Location = new Point(24, 70);
            lblMethod.Name = "lblMethod";
            lblMethod.Text = "Payment Method";
            lblMethod.ForeColor = Color.FromArgb(44, 62, 80);
            lblMethod.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMethod.AutoSize = true;
            lblMethod.UseMnemonic = false;
            lblMethod.TabIndex = 1;
            // 
            // rdoCash
            // 
            rdoCash.Location = new Point(24, 100);
            rdoCash.Name = "rdoCash";
            rdoCash.Size = new Size(150, 30);
            rdoCash.Text = "Cash";
            rdoCash.Checked = true;
            rdoCash.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            rdoCash.AutoSize = true;
            rdoCash.ForeColor = Color.FromArgb(44, 62, 80);
            rdoCash.TabIndex = 2;
            rdoCash.CheckedChanged += PaymentMethod_CheckedChanged;
            // 
            // rdoCard
            // 
            rdoCard.Location = new Point(200, 100);
            rdoCard.Name = "rdoCard";
            rdoCard.Size = new Size(160, 30);
            rdoCard.Text = "Card / QR";
            rdoCard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            rdoCard.AutoSize = true;
            rdoCard.ForeColor = Color.FromArgb(44, 62, 80);
            rdoCard.TabIndex = 3;
            rdoCard.CheckedChanged += PaymentMethod_CheckedChanged;
            // 
            // lblCashTendered
            // 
            lblCashTendered.Location = new Point(24, 160);
            lblCashTendered.Name = "lblCashTendered";
            lblCashTendered.Text = "Cash Tendered";
            lblCashTendered.ForeColor = Color.FromArgb(44, 62, 80);
            lblCashTendered.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCashTendered.AutoSize = true;
            lblCashTendered.UseMnemonic = false;
            lblCashTendered.TabIndex = 4;
            // 
            // txtCashTendered
            // 
            txtCashTendered.Location = new Point(24, 188);
            txtCashTendered.Name = "txtCashTendered";
            txtCashTendered.Size = new Size(440, 30);
            txtCashTendered.Font = new Font("Segoe UI", 11F);
            txtCashTendered.TabIndex = 5;
            txtCashTendered.TextChanged += txtCashTendered_TextChanged;
            // 
            // lblChangeDue
            // 
            lblChangeDue.Location = new Point(504, 160);
            lblChangeDue.Name = "lblChangeDue";
            lblChangeDue.Text = "Change Due";
            lblChangeDue.ForeColor = Color.FromArgb(44, 62, 80);
            lblChangeDue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChangeDue.AutoSize = true;
            lblChangeDue.UseMnemonic = false;
            lblChangeDue.TabIndex = 6;
            // 
            // txtChangeDue
            // 
            txtChangeDue.Location = new Point(504, 188);
            txtChangeDue.Name = "txtChangeDue";
            txtChangeDue.Size = new Size(440, 30);
            txtChangeDue.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtChangeDue.ReadOnly = true;
            txtChangeDue.BackColor = Color.FromArgb(236, 239, 241);
            txtChangeDue.ForeColor = Color.FromArgb(40, 167, 69);
            txtChangeDue.TabIndex = 7;
            // 
            // lblReference
            // 
            lblReference.Location = new Point(24, 250);
            lblReference.Name = "lblReference";
            lblReference.Text = "Reference Number (Card / QR only)";
            lblReference.ForeColor = Color.FromArgb(44, 62, 80);
            lblReference.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblReference.AutoSize = true;
            lblReference.UseMnemonic = false;
            lblReference.TabIndex = 8;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Location = new Point(24, 278);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(440, 30);
            txtReferenceNumber.Font = new Font("Segoe UI", 11F);
            txtReferenceNumber.Enabled = false;
            txtReferenceNumber.TabIndex = 9;
            // 
            // lblReferenceHint
            // 
            lblReferenceHint.Location = new Point(504, 284);
            lblReferenceHint.Name = "lblReferenceHint";
            lblReferenceHint.Text = "Required only when Card / QR is selected.";
            lblReferenceHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblReferenceHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblReferenceHint.AutoSize = true;
            lblReferenceHint.UseMnemonic = false;
            lblReferenceHint.TabIndex = 10;
            // 
            // pnlDivider
            // 
            pnlDivider.Location = new Point(24, 340);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(1100, 1);
            pnlDivider.BackColor = Color.FromArgb(222, 226, 230);
            pnlDivider.TabIndex = 11;
            // 
            // lblAfterTitle
            // 
            lblAfterTitle.Location = new Point(24, 360);
            lblAfterTitle.Name = "lblAfterTitle";
            lblAfterTitle.Text = "After settlement";
            lblAfterTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblAfterTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblAfterTitle.AutoSize = true;
            lblAfterTitle.UseMnemonic = false;
            lblAfterTitle.TabIndex = 12;
            // 
            // lblResStatusText
            // 
            lblResStatusText.Location = new Point(24, 412);
            lblResStatusText.Name = "lblResStatusText";
            lblResStatusText.Text = "Reservation status";
            lblResStatusText.ForeColor = Color.FromArgb(44, 62, 80);
            lblResStatusText.Font = new Font("Segoe UI", 11F);
            lblResStatusText.AutoSize = true;
            lblResStatusText.UseMnemonic = false;
            lblResStatusText.TabIndex = 13;
            // 
            // lblResFrom
            // 
            lblResFrom.Location = new Point(260, 406);
            lblResFrom.Name = "lblResFrom";
            lblResFrom.Size = new Size(140, 34);
            lblResFrom.Text = "Occupied";
            lblResFrom.ForeColor = Color.White;
            lblResFrom.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblResFrom.AutoSize = false;
            lblResFrom.UseMnemonic = false;
            lblResFrom.TextAlign = ContentAlignment.MiddleCenter;
            lblResFrom.BackColor = Color.FromArgb(192, 57, 43);
            lblResFrom.TabIndex = 14;
            // 
            // lblArrow1
            // 
            lblArrow1.Location = new Point(418, 406);
            lblArrow1.Name = "lblArrow1";
            lblArrow1.Text = "→";
            lblArrow1.ForeColor = Color.FromArgb(44, 62, 80);
            lblArrow1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblArrow1.AutoSize = true;
            lblArrow1.UseMnemonic = false;
            lblArrow1.TabIndex = 15;
            // 
            // lblResTo
            // 
            lblResTo.Location = new Point(470, 406);
            lblResTo.Name = "lblResTo";
            lblResTo.Size = new Size(140, 34);
            lblResTo.Text = "Completed";
            lblResTo.ForeColor = Color.White;
            lblResTo.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblResTo.AutoSize = false;
            lblResTo.UseMnemonic = false;
            lblResTo.TextAlign = ContentAlignment.MiddleCenter;
            lblResTo.BackColor = Color.FromArgb(108, 117, 125);
            lblResTo.TabIndex = 16;
            // 
            // lblRoomStatusText
            // 
            lblRoomStatusText.Location = new Point(24, 468);
            lblRoomStatusText.Name = "lblRoomStatusText";
            lblRoomStatusText.Text = "Room status";
            lblRoomStatusText.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomStatusText.Font = new Font("Segoe UI", 11F);
            lblRoomStatusText.AutoSize = true;
            lblRoomStatusText.UseMnemonic = false;
            lblRoomStatusText.TabIndex = 17;
            // 
            // lblRoomFrom
            // 
            lblRoomFrom.Location = new Point(260, 462);
            lblRoomFrom.Name = "lblRoomFrom";
            lblRoomFrom.Size = new Size(140, 34);
            lblRoomFrom.Text = "Occupied";
            lblRoomFrom.ForeColor = Color.White;
            lblRoomFrom.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblRoomFrom.AutoSize = false;
            lblRoomFrom.UseMnemonic = false;
            lblRoomFrom.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomFrom.BackColor = Color.FromArgb(192, 57, 43);
            lblRoomFrom.TabIndex = 18;
            // 
            // lblArrow2
            // 
            lblArrow2.Location = new Point(418, 462);
            lblArrow2.Name = "lblArrow2";
            lblArrow2.Text = "→";
            lblArrow2.ForeColor = Color.FromArgb(44, 62, 80);
            lblArrow2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblArrow2.AutoSize = true;
            lblArrow2.UseMnemonic = false;
            lblArrow2.TabIndex = 19;
            // 
            // lblRoomTo
            // 
            lblRoomTo.Location = new Point(470, 462);
            lblRoomTo.Name = "lblRoomTo";
            lblRoomTo.Size = new Size(140, 34);
            lblRoomTo.Text = "Cleaning";
            lblRoomTo.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomTo.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblRoomTo.AutoSize = false;
            lblRoomTo.UseMnemonic = false;
            lblRoomTo.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomTo.BackColor = Color.Gold;
            lblRoomTo.TabIndex = 20;
            // 
            // btnSettlePayment
            // 
            btnSettlePayment.Location = new Point(24, 560);
            btnSettlePayment.Name = "btnSettlePayment";
            btnSettlePayment.Size = new Size(480, 56);
            btnSettlePayment.Text = "Settle Payment && Check-Out";
            btnSettlePayment.BackColor = Color.FromArgb(40, 167, 69);
            btnSettlePayment.ForeColor = Color.White;
            btnSettlePayment.FlatStyle = FlatStyle.Flat;
            btnSettlePayment.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnSettlePayment.UseVisualStyleBackColor = false;
            btnSettlePayment.Cursor = Cursors.Hand;
            btnSettlePayment.FlatAppearance.BorderSize = 0;
            btnSettlePayment.TabIndex = 21;
            btnSettlePayment.Click += btnSettlePayment_Click;
            // 
            // btnBackToBill
            // 
            btnBackToBill.Location = new Point(524, 560);
            btnBackToBill.Name = "btnBackToBill";
            btnBackToBill.Size = new Size(200, 56);
            btnBackToBill.Text = "Back to Bill";
            btnBackToBill.BackColor = Color.FromArgb(108, 117, 125);
            btnBackToBill.ForeColor = Color.White;
            btnBackToBill.FlatStyle = FlatStyle.Flat;
            btnBackToBill.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnBackToBill.UseVisualStyleBackColor = false;
            btnBackToBill.Cursor = Cursors.Hand;
            btnBackToBill.FlatAppearance.BorderSize = 0;
            btnBackToBill.TabIndex = 22;
            btnBackToBill.Click += btnBackToBill_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Location = new Point(24, 636);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(1000, 30);
            lblErrorMessage.Text = "";
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.AutoSize = false;
            lblErrorMessage.UseMnemonic = false;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.TabIndex = 23;
            // 
            // PaymentUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pnlPayment);
            Controls.Add(pnlSummary);
            Name = "PaymentUserControl";
            Size = new Size(1920, 881);
            Load += PaymentUserControl_Load;
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlTotalDue.ResumeLayout(false);
            pnlTotalDue.PerformLayout();
            pnlPayment.ResumeLayout(false);
            pnlPayment.PerformLayout();
            pnlDivider.ResumeLayout(false);
            pnlDivider.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.TextBox txtCheckOut;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.TextBox txtGuests;
        private System.Windows.Forms.Panel pnlTotalDue;
        private System.Windows.Forms.Label lblTotalDueText;
        private System.Windows.Forms.Label lblTotalDueValue;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdoCard;
        private System.Windows.Forms.Label lblCashTendered;
        private System.Windows.Forms.TextBox txtCashTendered;
        private System.Windows.Forms.Label lblChangeDue;
        private System.Windows.Forms.TextBox txtChangeDue;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label lblReferenceHint;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblAfterTitle;
        private System.Windows.Forms.Label lblResStatusText;
        private System.Windows.Forms.Label lblResFrom;
        private System.Windows.Forms.Label lblArrow1;
        private System.Windows.Forms.Label lblResTo;
        private System.Windows.Forms.Label lblRoomStatusText;
        private System.Windows.Forms.Label lblRoomFrom;
        private System.Windows.Forms.Label lblArrow2;
        private System.Windows.Forms.Label lblRoomTo;
        private System.Windows.Forms.Button btnSettlePayment;
        private System.Windows.Forms.Button btnBackToBill;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}