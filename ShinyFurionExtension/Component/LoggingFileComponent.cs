using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyFurionExtension.Component
{
    /// <summary>
    /// 日志写入文件的组件
    /// </summary>
    public sealed class LoggingFileComponent : IServiceComponent
    {
        public void Load(IServiceCollection services, ComponentContext componentContext)
        {
            //每天创建一个日志文件
            var rootPath = App.HostEnvironment.ContentRootPath;
            services.AddFileLogging("logs/application-{0:yyyy}-{0:MM}-{0:dd}.log", options =>
            {
                options.FileNameRule = fileName =>
                {
                    return rootPath + "\\" + string.Format(fileName, DateTime.UtcNow);
                };

                options.MessageFormat = (logMsg) =>
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("【日志级别】：" + logMsg.LogLevel);
                    stringBuilder.AppendLine("【日志时间】：" + DateTime.Now.ToString("yyyy:MM:dd:HH:mm:ss"));
                    stringBuilder.AppendLine("【日志内容】：" + logMsg.Message);
                    if (logMsg.Exception != null)
                    {
                        stringBuilder.AppendLine("【异常信息】：" + logMsg.Exception);
                    }
                    return stringBuilder.ToString();
                };
            });
        }
    }
}
