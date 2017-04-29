using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace FL.Modules.FileList
{
    class FileListModule: IModule
    {
        private IRegionManager regionManager;

        public FileListModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(View));
        }
    }
}
