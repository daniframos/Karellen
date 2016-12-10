using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Configuration;
using System.Net.Http;

namespace Karellen.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "KARELLENAUTHCOOKIE",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/conta/login")
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            var facebook = new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["facebookappid"],
                AppSecret = ConfigurationManager.AppSettings["facebookappkey"],
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location"
            };

            facebook.Scope.Add("email");
            app.UseFacebookAuthentication(facebook);


            var google = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = ConfigurationManager.AppSettings["googleappid"],
                ClientSecret = ConfigurationManager.AppSettings["googleappkey"],
                Provider = new GoogleOAuth2AuthenticationProvider()
            };
            google.Scope.Add("email");
            app.UseGoogleAuthentication(google);
        }

        public class FacebookBackChannelHandler : HttpClientHandler
        {
            protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Replace the RequestUri so it's not malformed
                if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
                {
                    request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
                }

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}