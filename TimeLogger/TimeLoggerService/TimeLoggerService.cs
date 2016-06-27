using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLoggerService
{
    public class TimeLoggerService
    {
        private static TimeLoggerService _instance;
        private static object syncRoot = new Object();

        private TimeLoggerService()
        {
            
        }

        public static TimeLoggerService GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new TimeLoggerService();
                }
            }
            return _instance;
        }
    }
}
