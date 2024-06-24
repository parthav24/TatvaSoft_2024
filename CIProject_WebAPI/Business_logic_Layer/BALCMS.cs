using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALCMS
    {
        private readonly DALCMS _dalCMS;
        public BALCMS(DALCMS dalCMS)
        {
            _dalCMS = dalCMS;
        }

        public List<CMS> CMSList()
        {
            return _dalCMS.CMSList();
        }
        public CMS CMSDetailById(int id)
        {
            return _dalCMS.CMSDetailById(id);
        }
        public string AddCMS(CMS cms)
        {
            return _dalCMS.AddCMS(cms);
        }

        public string UpdateCMS(CMS cms)
        {
            return _dalCMS.UpdateCMS(cms);
        }
        public string DeleteCMS(int id)
        {
            return _dalCMS.DeleteCMS(id);
        }
    }
}