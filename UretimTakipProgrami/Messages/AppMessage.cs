using UretimTakipProgrami.Messages.MessageForms;

namespace UretimTakipProgrami.Messages
{
    public class AppMessage
    {
        public void SaveSuccessMessage()
        {
            FrmSaveMessage frmSaveMessage = new FrmSaveMessage();
            frmSaveMessage.ShowDialog();
        }

        public void UpdateSuccessMessage()
        {
            FrmUpdateMessage frmUpdateMessage = new FrmUpdateMessage();
            frmUpdateMessage.ShowDialog();
        }
    }
}
