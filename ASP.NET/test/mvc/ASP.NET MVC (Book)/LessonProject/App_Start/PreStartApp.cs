using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LessonProject.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace LessonProject.App_Start
{
    public class PreStartApp
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Start()
        {
            logger.Info("Application PreStart");
        }
    }
}