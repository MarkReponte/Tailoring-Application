using MaterialSkin.Controls;

namespace Dashboard
{
    public partial class dashboardPanel : MaterialForm
    {
        public dashboardPanel()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            this.DrawerTabControl = materialTabControl;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerUseColors = true;
            this.materialTabControl.ImageList = imageList;
            this.materialTabControl.TabPages[0].ImageKey = "dashboard.png";
            this.materialTabControl.TabPages[1].ImageKey = "order.png";

            materialTabControl.BringToFront();


        }

       

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }


       
     

    
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
