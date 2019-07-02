using News.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace News.Core.Entity
{
    public class CoreEntity
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedUserName = WindowsIdentity.GetCurrent().Name;
            this.CreatedIP = "";
        }

        public Guid ID { get; set; }
        public Guid MasterID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedUserName { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedIP { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedUserName { get; set; }
        public Guid ModifiedBy { get; set; }
        public string ModifiedIP { get; set; }

        public Status Status { get; set; }
    }
}
