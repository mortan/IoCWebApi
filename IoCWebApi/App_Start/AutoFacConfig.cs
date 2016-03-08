using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using IoCWebApi.Services;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IoCWebApi.App_Start.AutoFacConfig), "PreStart")]

namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class AutoFacConfig
    {
        public static void PreStart()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            var assemblies = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assemblies);
            builder.RegisterControllers(assemblies);

            // Beispiel um DataRepository Klasse an IDataRepository zu binden
            // (Siehe auch http://docs.autofac.org/en/stable/integration/webapi.html#service-registration)
            // Ich würde die Konfiguration des Containers übrigens in eine eigene App_Start Klasse verlegen!
            // Das Konfigurieren von Autofac ist sehr mächtig! Man kann entweder alle Interfaces per Hand binden
            // oder auf einen Convention over Configuration Ansatz greifen wenn das Projekt eine gewisse Größe
            // überschritten hat. Konkret heißt das: Eine geeignete Orderstruktur finden und die Interfaces über
            // Reflection binden, siehe für Beispiel: http://weblogs.asp.net/bsimser/convention-over-configuration-with-mvc-and-autofac
            // Wir registrieren hier ein neues DataRepository für jeden WebRequest (das ist idR. eine gute Idee!), man kann auch
            // Singletons registrieren, die müssen dann aber Thread-Safe sein!
            builder.Register(c => new DataRepository()).As<IDataRepository>();

            var container = builder.Build();
            var autofacWebApiDependencyResolver = new AutofacWebApiDependencyResolver(container);

            // WebApi (ValuesController) DependencyResolver auf unseren Autofac Resolver setzen
            config.DependencyResolver = autofacWebApiDependencyResolver;

            // MVC Controller Factory (HomeController) unseren Autofac Resolver benutzen lassen
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
