using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TargetReflection
{
    public class Target
    {
        public string PublicInfo = "PublicData";
        private string PrivateInfo = "SecretData";

        public int PublicId { get; set; }
        private double PrivateBalance { get; set; }

        public Target()
        {
            this.PublicId = 42;
            this.PrivateBalance = 1000.50;
        }

        public string GetPublicInfo()
        {
            return this.PublicInfo;
        }

        private string GetPrivateInfo()
        {
            return this.PrivateInfo;
        }

        private void UpdateBalance(double amount)
        {
            this.PrivateBalance += amount;
        }
    }
}




