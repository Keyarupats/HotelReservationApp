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
            pnlTotalDue = new Panel();
            lblTotalDueValue = new Label();
            lblTotalDueText = new Label();
            txtGuests = new TextBox();
            lblGuests = new Label();
            txtCheckOut = new TextBox();
            lblCheckOut = new Label();
            txtCheckIn = new TextBox();
            lblCheckIn = new Label();
            txtRoom = new TextBox();
            lblRoom = new Label();
            txtGuestName = new TextBox();
            lblGuestName = new Label();
            lblSummaryTitle = new Label();
            pnlPayment = new Panel();
            lblErrorMessage = new Label();
            btnBackToBill = new Button();
            btnSettlePayment = new Button();
            lblRoomTo = new Label();
            lblArrow2 = new Label();
            lblRoomFrom = new Label();
            lblRoomStatusText = new Label();
            lblResTo = new Label();
            lblArrow1 = new Label();
            lblResFrom = new Label();
            lblResStatusText = new Label();
            lblAfterTitle = new Label();
            pnlDivider = new Panel();
            lblReferenceHint = new Label();
            txtReferenceNumber = new TextBox();
            lblReference = new Label();
            txtChangeDue = new TextBox();
            lblChangeDue = new Label();
            txtCashTendered = new TextBox();
            lblCashTendered = new Label();
            rdoCard = new RadioButton();
            rdoCash = new RadioButton();
            lblMethod = new Label();
            lblPaymentTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlTotalDue.SuspendLayout();
            pnlPayment.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSummary.BackColor = Color.White;
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
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
            pnlSummary.TabIndex = 0;
            // 
            // pnlTotalDue
            // 
            pnlTotalDue.BackColor = Color.FromArgb(234, 247, 240);
            pnlTotalDue.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalDue.Controls.Add(lblTotalDueValue);
            pnlTotalDue.Controls.Add(lblTotalDueText);
            pnlTotalDue.Location = new Point(20, 540);
            pnlTotalDue.Name = "pnlTotalDue";
            pnlTotalDue.Size = new Size(660, 130);
            pnlTotalDue.TabIndex = 11;
            // 
            // lblTotalDueValue
            // 
            lblTotalDueValue.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            lblTotalDueValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalDueValue.Location = new Point(20, 50);
            lblTotalDueValue.Name = "lblTotalDueValue";
            lblTotalDueValue.Size = new Size(618, 64);
            lblTotalDueValue.TabIndex = 1;
            lblTotalDueValue.Text = "₱0.00";
            lblTotalDueValue.TextAlign = ContentAlignment.MiddleRight;
            lblTotalDueValue.UseMnemonic = false;
            // 
            // lblTotalDueText
            // 
            lblTotalDueText.AutoSize = true;
            lblTotalDueText.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblTotalDueText.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalDueText.Location = new Point(20, 14);
            lblTotalDueText.Name = "lblTotalDueText";
            lblTotalDueText.Size = new Size(195, 30);
            lblTotalDueText.TabIndex = 0;
            lblTotalDueText.Text = "Total Amount Due";
            lblTotalDueText.UseMnemonic = false;
            // 
            // txtGuests
            // 
            txtGuests.BackColor = Color.FromArgb(236, 239, 241);
            txtGuests.Font = new Font("Segoe UI", 11F);
            txtGuests.Location = new Point(20, 456);
            txtGuests.Name = "txtGuests";
            txtGuests.ReadOnly = true;
            txtGuests.Size = new Size(660, 32);
            txtGuests.TabIndex = 10;
            // 
            // lblGuests
            // 
            lblGuests.AutoSize = true;
            lblGuests.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGuests.ForeColor = Color.FromArgb(44, 62, 80);
            lblGuests.Location = new Point(20, 430);
            lblGuests.Name = "lblGuests";
            lblGuests.Size = new Size(61, 23);
            lblGuests.TabIndex = 9;
            lblGuests.Text = "Guests";
            lblGuests.UseMnemonic = false;
            // 
            // txtCheckOut
            // 
            txtCheckOut.BackColor = Color.FromArgb(236, 239, 241);
            txtCheckOut.Font = new Font("Segoe UI", 11F);
            txtCheckOut.Location = new Point(20, 366);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.ReadOnly = true;
            txtCheckOut.Size = new Size(660, 32);
            txtCheckOut.TabIndex = 8;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCheckOut.ForeColor = Color.FromArgb(44, 62, 80);
            lblCheckOut.Location = new Point(20, 340);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(92, 23);
            lblCheckOut.TabIndex = 7;
            lblCheckOut.Text = "Check-Out";
            lblCheckOut.UseMnemonic = false;
            // 
            // txtCheckIn
            // 
            txtCheckIn.BackColor = Color.FromArgb(236, 239, 241);
            txtCheckIn.Font = new Font("Segoe UI", 11F);
            txtCheckIn.Location = new Point(20, 276);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.ReadOnly = true;
            txtCheckIn.Size = new Size(660, 32);
            txtCheckIn.TabIndex = 6;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCheckIn.ForeColor = Color.FromArgb(44, 62, 80);
            lblCheckIn.Location = new Point(20, 250);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(78, 23);
            lblCheckIn.TabIndex = 5;
            lblCheckIn.Text = "Check-In";
            lblCheckIn.UseMnemonic = false;
            // 
            // txtRoom
            // 
            txtRoom.BackColor = Color.FromArgb(236, 239, 241);
            txtRoom.Font = new Font("Segoe UI", 11F);
            txtRoom.Location = new Point(20, 186);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(660, 32);
            txtRoom.TabIndex = 4;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRoom.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoom.Location = new Point(20, 160);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(56, 23);
            lblRoom.TabIndex = 3;
            lblRoom.Text = "Room";
            lblRoom.UseMnemonic = false;
            // 
            // txtGuestName
            // 
            txtGuestName.BackColor = Color.FromArgb(236, 239, 241);
            txtGuestName.Font = new Font("Segoe UI", 11F);
            txtGuestName.Location = new Point(20, 96);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.ReadOnly = true;
            txtGuestName.Size = new Size(660, 32);
            txtGuestName.TabIndex = 2;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGuestName.ForeColor = Color.FromArgb(44, 62, 80);
            lblGuestName.Location = new Point(20, 70);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(105, 23);
            lblGuestName.TabIndex = 1;
            lblGuestName.Text = "Guest Name";
            lblGuestName.UseMnemonic = false;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblSummaryTitle.Location = new Point(20, 16);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(179, 35);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Stay Summary";
            lblSummaryTitle.UseMnemonic = false;
            // 
            // pnlPayment
            // 
            pnlPayment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPayment.BackColor = Color.White;
            pnlPayment.BorderStyle = BorderStyle.FixedSingle;
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
            pnlPayment.TabIndex = 1;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(24, 636);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(1000, 30);
            lblErrorMessage.TabIndex = 23;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.UseMnemonic = false;
            // 
            // btnBackToBill
            // 
            btnBackToBill.BackColor = Color.FromArgb(108, 117, 125);
            btnBackToBill.Cursor = Cursors.Hand;
            btnBackToBill.FlatAppearance.BorderSize = 0;
            btnBackToBill.FlatStyle = FlatStyle.Flat;
            btnBackToBill.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnBackToBill.ForeColor = Color.White;
            btnBackToBill.Location = new Point(524, 560);
            btnBackToBill.Name = "btnBackToBill";
            btnBackToBill.Size = new Size(200, 56);
            btnBackToBill.TabIndex = 22;
            btnBackToBill.Text = "Back to Bill";
            btnBackToBill.UseVisualStyleBackColor = false;
            btnBackToBill.Click += btnBackToBill_Click;
            // 
            // btnSettlePayment
            // 
            btnSettlePayment.BackColor = Color.FromArgb(40, 167, 69);
            btnSettlePayment.Cursor = Cursors.Hand;
            btnSettlePayment.FlatAppearance.BorderSize = 0;
            btnSettlePayment.FlatStyle = FlatStyle.Flat;
            btnSettlePayment.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnSettlePayment.ForeColor = Color.White;
            btnSettlePayment.Location = new Point(24, 560);
            btnSettlePayment.Name = "btnSettlePayment";
            btnSettlePayment.Size = new Size(480, 56);
            btnSettlePayment.TabIndex = 21;
            btnSettlePayment.Text = "Settle Payment && Check-Out";
            btnSettlePayment.UseVisualStyleBackColor = false;
            btnSettlePayment.Click += btnSettlePayment_Click;
            // 
            // lblRoomTo
            // 
            lblRoomTo.BackColor = Color.Gold;
            lblRoomTo.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblRoomTo.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomTo.Location = new Point(470, 462);
            lblRoomTo.Name = "lblRoomTo";
            lblRoomTo.Size = new Size(140, 34);
            lblRoomTo.TabIndex = 20;
            lblRoomTo.Text = "Cleaning";
            lblRoomTo.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomTo.UseMnemonic = false;
            // 
            // lblArrow2
            // 
            lblArrow2.AutoSize = true;
            lblArrow2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblArrow2.ForeColor = Color.FromArgb(44, 62, 80);
            lblArrow2.Location = new Point(418, 462);
            lblArrow2.Name = "lblArrow2";
            lblArrow2.Size = new Size(40, 37);
            lblArrow2.TabIndex = 19;
            lblArrow2.Text = "→";
            lblArrow2.UseMnemonic = false;
            // 
            // lblRoomFrom
            // 
            lblRoomFrom.BackColor = Color.FromArgb(192, 57, 43);
            lblRoomFrom.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblRoomFrom.ForeColor = Color.White;
            lblRoomFrom.Location = new Point(260, 462);
            lblRoomFrom.Name = "lblRoomFrom";
            lblRoomFrom.Size = new Size(140, 34);
            lblRoomFrom.TabIndex = 18;
            lblRoomFrom.Text = "Occupied";
            lblRoomFrom.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomFrom.UseMnemonic = false;
            // 
            // lblRoomStatusText
            // 
            lblRoomStatusText.AutoSize = true;
            lblRoomStatusText.Font = new Font("Segoe UI", 11F);
            lblRoomStatusText.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomStatusText.Location = new Point(24, 468);
            lblRoomStatusText.Name = "lblRoomStatusText";
            lblRoomStatusText.Size = new Size(114, 25);
            lblRoomStatusText.TabIndex = 17;
            lblRoomStatusText.Text = "Room status";
            lblRoomStatusText.UseMnemonic = false;
            // 
            // lblResTo
            // 
            lblResTo.BackColor = Color.FromArgb(108, 117, 125);
            lblResTo.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblResTo.ForeColor = Color.White;
            lblResTo.Location = new Point(470, 406);
            lblResTo.Name = "lblResTo";
            lblResTo.Size = new Size(140, 34);
            lblResTo.TabIndex = 16;
            lblResTo.Text = "Completed";
            lblResTo.TextAlign = ContentAlignment.MiddleCenter;
            lblResTo.UseMnemonic = false;
            // 
            // lblArrow1
            // 
            lblArrow1.AutoSize = true;
            lblArrow1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblArrow1.ForeColor = Color.FromArgb(44, 62, 80);
            lblArrow1.Location = new Point(418, 406);
            lblArrow1.Name = "lblArrow1";
            lblArrow1.Size = new Size(40, 37);
            lblArrow1.TabIndex = 15;
            lblArrow1.Text = "→";
            lblArrow1.UseMnemonic = false;
            // 
            // lblResFrom
            // 
            lblResFrom.BackColor = Color.FromArgb(192, 57, 43);
            lblResFrom.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblResFrom.ForeColor = Color.White;
            lblResFrom.Location = new Point(260, 406);
            lblResFrom.Name = "lblResFrom";
            lblResFrom.Size = new Size(140, 34);
            lblResFrom.TabIndex = 14;
            lblResFrom.Text = "Occupied";
            lblResFrom.TextAlign = ContentAlignment.MiddleCenter;
            lblResFrom.UseMnemonic = false;
            // 
            // lblResStatusText
            // 
            lblResStatusText.AutoSize = true;
            lblResStatusText.Font = new Font("Segoe UI", 11F);
            lblResStatusText.ForeColor = Color.FromArgb(44, 62, 80);
            lblResStatusText.Location = new Point(24, 412);
            lblResStatusText.Name = "lblResStatusText";
            lblResStatusText.Size = new Size(163, 25);
            lblResStatusText.TabIndex = 13;
            lblResStatusText.Text = "Reservation status";
            lblResStatusText.UseMnemonic = false;
            // 
            // lblAfterTitle
            // 
            lblAfterTitle.AutoSize = true;
            lblAfterTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblAfterTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblAfterTitle.Location = new Point(24, 360);
            lblAfterTitle.Name = "lblAfterTitle";
            lblAfterTitle.Size = new Size(177, 30);
            lblAfterTitle.TabIndex = 12;
            lblAfterTitle.Text = "After settlement";
            lblAfterTitle.UseMnemonic = false;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(222, 226, 230);
            pnlDivider.Location = new Point(24, 340);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(1100, 1);
            pnlDivider.TabIndex = 11;
            // 
            // lblReferenceHint
            // 
            lblReferenceHint.AutoSize = true;
            lblReferenceHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblReferenceHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblReferenceHint.Location = new Point(504, 284);
            lblReferenceHint.Name = "lblReferenceHint";
            lblReferenceHint.Size = new Size(315, 23);
            lblReferenceHint.TabIndex = 10;
            lblReferenceHint.Text = "Required only when Card / QR is selected.";
            lblReferenceHint.UseMnemonic = false;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Enabled = false;
            txtReferenceNumber.Font = new Font("Segoe UI", 11F);
            txtReferenceNumber.Location = new Point(24, 278);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(440, 32);
            txtReferenceNumber.TabIndex = 9;
            txtReferenceNumber.TextChanged += txtReferenceNumber_TextChanged;
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblReference.ForeColor = Color.FromArgb(44, 62, 80);
            lblReference.Location = new Point(24, 250);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(287, 23);
            lblReference.TabIndex = 8;
            lblReference.Text = "Reference Number (Card / QR only)";
            lblReference.UseMnemonic = false;
            // 
            // txtChangeDue
            // 
            txtChangeDue.BackColor = Color.FromArgb(236, 239, 241);
            txtChangeDue.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtChangeDue.ForeColor = Color.FromArgb(40, 167, 69);
            txtChangeDue.Location = new Point(504, 188);
            txtChangeDue.Name = "txtChangeDue";
            txtChangeDue.ReadOnly = true;
            txtChangeDue.Size = new Size(440, 32);
            txtChangeDue.TabIndex = 7;
            // 
            // lblChangeDue
            // 
            lblChangeDue.AutoSize = true;
            lblChangeDue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChangeDue.ForeColor = Color.FromArgb(44, 62, 80);
            lblChangeDue.Location = new Point(504, 160);
            lblChangeDue.Name = "lblChangeDue";
            lblChangeDue.Size = new Size(105, 23);
            lblChangeDue.TabIndex = 6;
            lblChangeDue.Text = "Change Due";
            lblChangeDue.UseMnemonic = false;
            // 
            // txtCashTendered
            // 
            txtCashTendered.Font = new Font("Segoe UI", 11F);
            txtCashTendered.Location = new Point(24, 188);
            txtCashTendered.Name = "txtCashTendered";
            txtCashTendered.Size = new Size(440, 32);
            txtCashTendered.TabIndex = 5;
            txtCashTendered.TextChanged += txtCashTendered_TextChanged;
            // 
            // lblCashTendered
            // 
            lblCashTendered.AutoSize = true;
            lblCashTendered.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCashTendered.ForeColor = Color.FromArgb(44, 62, 80);
            lblCashTendered.Location = new Point(24, 160);
            lblCashTendered.Name = "lblCashTendered";
            lblCashTendered.Size = new Size(122, 23);
            lblCashTendered.TabIndex = 4;
            lblCashTendered.Text = "Cash Tendered";
            lblCashTendered.UseMnemonic = false;
            // 
            // rdoCard
            // 
            rdoCard.AutoSize = true;
            rdoCard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            rdoCard.ForeColor = Color.FromArgb(44, 62, 80);
            rdoCard.Location = new Point(200, 100);
            rdoCard.Name = "rdoCard";
            rdoCard.Size = new Size(117, 29);
            rdoCard.TabIndex = 3;
            rdoCard.Text = "Card / QR";
            rdoCard.CheckedChanged += PaymentMethod_CheckedChanged;
            // 
            // rdoCash
            // 
            rdoCash.AutoSize = true;
            rdoCash.Checked = true;
            rdoCash.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            rdoCash.ForeColor = Color.FromArgb(44, 62, 80);
            rdoCash.Location = new Point(24, 100);
            rdoCash.Name = "rdoCash";
            rdoCash.Size = new Size(74, 29);
            rdoCash.TabIndex = 2;
            rdoCash.TabStop = true;
            rdoCash.Text = "Cash";
            rdoCash.CheckedChanged += PaymentMethod_CheckedChanged;
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMethod.ForeColor = Color.FromArgb(44, 62, 80);
            lblMethod.Location = new Point(24, 70);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(144, 23);
            lblMethod.TabIndex = 1;
            lblMethod.Text = "Payment Method";
            lblMethod.UseMnemonic = false;
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblPaymentTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblPaymentTitle.Location = new Point(20, 16);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(114, 35);
            lblPaymentTitle.TabIndex = 0;
            lblPaymentTitle.Text = "Payment";
            lblPaymentTitle.UseMnemonic = false;
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