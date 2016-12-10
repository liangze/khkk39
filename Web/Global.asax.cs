using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Library;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //1000*60*5，5分钟执行一次  300000
            //1000*60*60*12，12个小时执行一次
            //System.Timers.Timer myTimer = new System.Timers.Timer(86400000);//1000*60*60*24，24小时执行一次 86400000
            ////关联事件 
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(ImportMallPoints);
            //myTimer.AutoReset = true;
            //myTimer.Enabled = true;

            string s = "程序启动";
            Library.LogHelper.SaveLog(s, "Application_Start");
            // 在应用程序启动时运行的代码
            //QuartzStart.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            Exception ex = Server.GetLastError().GetBaseException();
            if (ex != null)
            {
                string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "出错时间" + DateTime.Now.ToString() + "\r\n";
                // 错误的信息
                s = s + "错误的信息:" + ex.ToString() + "\r\n";
                // 错误的描述
                s = s + "错误:" + ex.StackTrace + "\r\n";
                // 错误的描述
                s = s + "错误的描述:" + ex.Message + "\r\n";
                // 出错的方法名
                s = s + "出错的方法名:" + ex.TargetSite.Name + "\r\n";
                // 出错的类名
                s = s + "出错的类名:" + ex.TargetSite.DeclaringType.FullName + "\r\n";
                System.IO.File.AppendAllText(Server.MapPath("~/log/log.log"), s);
            }

            // 清空最后的错误
            //Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void ImportMallPoints(object sender, System.Timers.ElapsedEventArgs e)
        {
            //string s = "导入商城积分" + DateTime.Now.ToString() + "\r\n";
            //System.IO.File.AppendAllText(Server.MapPath("~/msync.txt"), s);

            //MallPoints msync = new MallPoints();
            ////导入商城积分
            //if (msync.Import())
            //{
            //    s = "计算推广佣金" + DateTime.Now.ToString() + "\r\n";
            //    System.IO.File.AppendAllText(Server.MapPath("~/msync.txt"), s);
            //    //计算推广佣金
            //    if (msync.Calc())
            //    {
            //        s = "将计算好的虚拟币（亿币）写回商城" + DateTime.Now.ToString() + "\r\n";
            //        System.IO.File.AppendAllText(Server.MapPath("~/msync.txt"), s);
            //        //将计算好的虚拟币（亿币）写回商城
            //        msync.Sync();
            //    }
            //}
          
        }
    }
}