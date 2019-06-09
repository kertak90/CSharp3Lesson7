using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MailSenderLib.Data.EF;

namespace Lesson1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    using (var db = new MailSenderDBContext())
        //    {
        //        db.Database.Log = str => Debug.WriteLine(str);
        //        foreach(var mail in db.MailMessages)
        //        {
        //            Debug.WriteLine($"Mail: {mail.Subject}");
        //        }
        //    }
        //        base.OnStartup(e);
        //}
    }
}
