using ShinyFurionExtension.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyFurionExtension
{
    /// <summary>
    /// 日志写入文件扩展
    /// </summary>
    public static class LoggingFileExtensions
    {
        /// <summary>
        /// 添加workerservice项目控制台日志格式化扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder UseLoggingFile(this IHostBuilder builder)
        {
            builder.ConfigureLogging(logging =>
              {
                  logging.ClearProviders();
                  logging.AddConsole(options =>
                  {
                      options.FormatterName = "custom_format";
                  }).AddConsoleFormatter<ConsoleForamt, ConsoleFormatterOptions>();

              });
            builder.ConfigureServices((hostContext, services) =>
             {
                 services.AddComponent<LoggingFileComponent>();
             });
            return builder;
        }


        /// <summary>
        /// 添加api项目控制台日志格式化扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder UseLoggingFile(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole(options =>
            {
                options.FormatterName = "custom_format";
            }).AddConsoleFormatter<ConsoleForamt, ConsoleFormatterOptions>();
            builder.Services.AddComponent<LoggingFileComponent>();
            return builder;
        }
    }
}
