using System.Windows.Forms;

namespace bobFinal
{
    public class CustomPictureBox : PictureBox
    {
        public bool BuiltUpon { get; set; }
        public bool ConnectedViaPathOrProperty { get; set; }
    }
}