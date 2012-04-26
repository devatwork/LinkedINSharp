using System;
using System.Web.Mvc;
using LinkedINSharp.Model.OAuth;
using LinkedINSharp.Model.People;

namespace LinkedINSharp.Sample.MVC.Controllers
{
	public class HomeController : Controller
	{
		private const string consumerKey = "CONSUMER_KEY";
		private const string consumerSecret = "CONSUMER_SECRET";

		public ActionResult Index()
		{
			var accessToken = (AccessToken) Session["accessToken"];
			if (accessToken != null)
			{
				// create the client
				var client = new LinkedINRestClient(consumerKey, consumerSecret, accessToken);

				// retrieve the profile
				try
				{
					var profile = client.RetrieveCurrentMemberProfile(ProfileField.NameOnly);

					// return the view
					return View("Profile", profile);
				}
				catch (LinkedINUnauthorizedException)
				{
					// clear the access token
					Session.Remove("accessToken");

					// return the unauthorized view
					return View("Login");
				}
			}

			// return the unauthorized view
			return View("Login");
		}
		public ActionResult Logout()
		{
			// delete the access token from the session
			Session.Remove("accessToken");

			// redirect to home/index
			return new RedirectResult(Url.RouteUrl("Default", new {Action = "Index"}, Request.Url.Scheme));
		}
		public ActionResult Login()
		{
			// define the callback
			var callbackUri = new Uri(Url.RouteUrl("Default", new {Action = "Callback"}, Request.Url.Scheme));

			// create the client
			var client = new LinkedINRestClient(consumerKey, consumerSecret);

			// Phase 1: acquire request token
			RequestToken requestToken;
			var redirectUri = client.RequestAuthorizationToken(callbackUri, out requestToken);

			// store the request token in the session for later use
			Session["requestToken"] = requestToken;

			// send the redirect
			return new RedirectResult(redirectUri.ToString());
		}
		public ActionResult Callback()
		{
			// get the request uri
			var requestUri = Request.Url;

			// get the request token from the session
			var requestToken = (RequestToken) Session["requestToken"];
			Session.Remove("requestToken");

			// create the client
			var client = new LinkedINRestClient(consumerKey, consumerSecret);

			// Fase 2: acquire access token
			var accessToken = client.ExchangeCodeForAccessToken(requestUri, requestToken);

			// store the access token in the session
			Session["accessToken"] = accessToken;

			// redirect to home/index
			return new RedirectResult(Url.RouteUrl("Default", new {Action = "Index"}, Request.Url.Scheme));
		}
	}
}