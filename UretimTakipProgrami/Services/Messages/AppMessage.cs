
using UretimTakipProgrami.Services.Messages.MessageForms;

namespace UretimTakipProgrami.Business.Services.Messages
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
