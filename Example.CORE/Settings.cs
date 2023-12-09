using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Settings
{

    private static Settings Instance_ { get; set; }
    public static Settings Instance => GetInstance();
    private static object Lock = new object();
    private static Settings GetInstance()
    {
        if (Instance_ == null)
        {
            lock (Lock)
            {
                if (Instance_ != null) return Instance_;
                Instance_ = new Settings();

            }

        }
        return Instance_;
    }

    public string ConnectionString { get; set; }
}

