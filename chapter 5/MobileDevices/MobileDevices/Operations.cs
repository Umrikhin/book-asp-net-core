using MobileDevices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevices
{
    public class Operations
    {
        public static int Create(MobileDevice mobileDevice)
        {
            int newId = 0;
            using (Repository db = new Repository())
            {
                db.MobileDevices.Add(mobileDevice);
                db.SaveChanges();
                newId = mobileDevice.Id;
            }
            return newId;
        }
        public static IEnumerable<MobileDevice> Read()
        {
            List<MobileDevice> list = new List<MobileDevice>();
            using (Repository db = new Repository())
            {
                list = db.MobileDevices.ToList();
            }
            return list;
        }
        public static MobileDevice? Read(int Id)
        {
            MobileDevice? mobileDevice = null;
            using (Repository db = new Repository())
            {
                mobileDevice = db.Find<MobileDevice>(Id);
            }
            return mobileDevice;
        }
        public static void Update(MobileDevice mobileDevice)
        {
            using (Repository db = new Repository())
            {
                db.MobileDevices.Update(mobileDevice);
                db.SaveChanges();
            }
        }
        public static void Delete(MobileDevice mobileDevice)
        {
            using (Repository db = new Repository())
            {
                db.MobileDevices.Remove(mobileDevice);
                db.SaveChanges();
            }
        }
    }
}
