using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace HireKoro.Forms
{
    public partial class MessagesPage : UserControl
    {
        internal static string SenderId { get; set; }
        internal static string ReceverID { get; set; } = "0";
        internal static FlowLayoutPanel FLPmessage { get ; set; }
        internal static Label ReceverName { get; set; }

        public MessagesPage()
        {
            InitializeComponent();
            SenderId = Main.CurrentUserId;

            ReceverName = lblReceverNAME;
            FLPmessage = this.flpChats;
            this.LoadMessages();
            Chats();
        }

        private void LoadMessages()
        {
            this.flpMessages.Controls.Clear();

            var Query = $@"SELECT M.MessageID, 
                                   M.ReceiverID, 
                                   RU.Name, 
                                   M.Content, 
                                   M.SendAt
                            FROM MESSAGES AS M
                            JOIN USERS AS RU ON RU.UserID = M.ReceiverID
                            JOIN USERS AS SU ON SU.UserID = M.SenderID
                            WHERE M.SenderID = '{SenderId}'
                            AND M.SendAt = (
                                SELECT MAX(M2.SendAt)
                                FROM MESSAGES AS M2
                                WHERE M2.SenderID = M.SenderID
                                  AND M2.ReceiverID = M.ReceiverID
                            )
                            ORDER BY M.SendAt DESC;";
            try
            {
                var result = Main.DB.ExecuteQueryTable(Query);
                if (result.Rows.Count<1)
                {
                    return;
                }
                ReceverID = result.Rows[0][1].ToString();

                for (int i = 0; i < result.Rows.Count; i++)
                {
                    MessageContainer newM = new MessageContainer(result.Rows[i][1].ToString(),result.Rows[i][2].ToString(), result.Rows[i][3].ToString(), result.Rows[i][4].ToString());
                    newM.Dock = DockStyle.Top;
                    this.flpMessages.Controls.Add(newM);
                }
                this.lblReceverNAME.Text = result.Rows[0][2].ToString().ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private static void ScrollDown()
        {
            FLPmessage.PerformLayout();
            FLPmessage.AutoScrollPosition = new Point(0, FLPmessage.DisplayRectangle.Height);
            if (FLPmessage.Controls.Count > 0)
            {
                FLPmessage.ScrollControlIntoView(FLPmessage.Controls[FLPmessage.Controls.Count - 1]);
            }
        }

        internal static void Chats()
        {
            if (ReceverID == "0")
            {
                return;
            }
            FLPmessage.Controls.Clear();

            var Query = $@"Select M.SenderID,
		                    SU.Name,
		                    M.ReceiverID,
		                    RU.Name,
		                    M.Content,
		                    M.SendAt 
                    from MESSAGES AS M ,
		                    USERS AS SU,
		                    USERS as RU 
                    where Su.UserID = M.SenderID and
		                    Ru.UserID = M.ReceiverID and
		                    ((M.SenderID = {SenderId} or
                            M.SenderID = {ReceverID}) and
                            (M.ReceiverID = {SenderId} or
                            M.ReceiverID = {ReceverID}));";

            try
            {
                var result = Main.DB.ExecuteQueryTable(Query);

                for (int i = 0; i < result.Rows.Count ; i++)
                {
                    ChatBubble chats = new ChatBubble(result.Rows[i][4].ToString(), result.Rows[i][1].ToString(), result.Rows[i][5].ToString());

                    FLPmessage.Controls.Add(chats);
                }
                ScrollDown();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SendM()
        {
            if (this.txtTextMessage.Text == "")
            {
                MessageBox.Show("The Message Box Is Empty");
                return;
            }

            try
            {
                var Query = $@"Insert into MESSAGES (SenderID,ReceiverID,Content,SendAt) Values ( {SenderId} ,{ReceverID} , '{this.txtTextMessage.Text}' , GETDATE())";
                Main.DB.ExecuteDMLQuery(Query);
                this.txtTextMessage.Text = "";
                Chats();
                LoadMessages();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.SendM();
        }

        private void txtTextMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SendM();
                e.SuppressKeyPress = true;
            }
        }
    }
}
