using DirectShowLib;

namespace TargetVision.Configs
{
    internal class Cams
    {
        private readonly ToolStripComboBox _comboBox;

        private DsDevice[] _cams;

        public Cams(ToolStripComboBox comboBox)
        {
            _comboBox = comboBox ?? throw new ArgumentNullException(nameof(_comboBox));

            GetCams();
        }
           
        // Получает список доступных в системе камер
        private void GetCams()
        {
            _cams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            for (int i = 0; i < _cams.Length; i++)
                _comboBox.Items.Add(_cams[i].Name);
        }
    }
}
