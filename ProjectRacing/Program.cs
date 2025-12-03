using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectRacing.Repositories;
using ProjectRacing.Repositories.Implementations;
using Serilog;
using Unity;
using Unity.Microsoft.Logging;

namespace ProjectRacing
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(CreateContainer().Resolve<FormRacing>());
        }

        private static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.AddExtension(new LoggingExtension(CreateLoggerFactory()));
            container.RegisterType<ICompetitionsRepository, CompetitionsRepository>();
            container.RegisterType<IHorseRepository, HorseRepository>();
            container.RegisterType<IJockeyRepository, JockeyRepository>();
            container.RegisterType<IOwnerRepository, OwnerRepository>();
            container.RegisterType<IParticipantsRepository, ParticipantsRepository>();
            container.RegisterType < IMedicalExaminationRepository, MedicalExaminationRepository> ();
            container.RegisterType<IConnectionString, ConnectionString>();
            return container;
        }
        private static LoggerFactory CreateLoggerFactory()
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build())
                .CreateLogger());
            return loggerFactory;
        }
    }
}