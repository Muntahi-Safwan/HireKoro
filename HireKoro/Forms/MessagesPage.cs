using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace HireKoro.Forms
{
    public partial class MessagesPage : UserControl
    {
        public MessagesPage()
        {
            InitializeComponent();
            LoadMessages();
        }

        private void LoadMessages()
        {
            string userId = "1";
            var Query = $@"SELECT M.MessageID, 
                                   M.ReceiverID, 
                                   RU.Name, 
                                   M.Content, 
                                   M.SendAt
                            FROM MESSAGES AS M
                            JOIN USERS AS RU ON RU.UserID = M.ReceiverID
                            JOIN USERS AS SU ON SU.UserID = M.SenderID
                            WHERE M.SenderID = '{userId}'
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
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    MessageContainer newM = new MessageContainer(result.Rows[i][2].ToString(), result.Rows[i][3].ToString(), result.Rows[i][4].ToString());
                    newM.Dock = DockStyle.Top;
                    this.flpMessages.Controls.Add(newM);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
