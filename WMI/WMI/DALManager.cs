using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMI
{
    public class DALManager
    {
        public static ManagementObjectCollection UserInfo()
        {
            return DAL.UserInfo();
        }
        public static ManagementObjectCollection BootDevice()
        {
            return DAL.BootDevice();
        }
        public static List<string> PopulateDisk()
        {
            return DAL.PopulateDisk();
        }
        public static ManagementObjectCollection MainStorage()
        {
            return DAL.MainStorage();
        }
        public static ManagementObjectCollection DiskMetaData()
        {
            return DAL.DiskMetaData();
        }
        public static string HardDiskSerialNumber()
        {
            return DAL.HardDiskSerialNumber();
        }
        public static ManagementObjectCollection ListAllServices()
        {
            return DAL.ListAllServices();
        }
        public static ManagementObjectSearcher ProcessorTime()
        {
            return DAL.ProcessorTime();
        }
    }
}
