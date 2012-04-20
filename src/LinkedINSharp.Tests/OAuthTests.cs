using System;
using System.Diagnostics;
using LinkedINSharp.Model.OAuth;
using NUnit.Framework;

namespace LinkedINSharp.Tests
{
	[TestFixture]
	public class OAuthTests
	{
		[Test]
		public void CanAuthenticateWithOAuth()
		{
			var consumerKey = "CONSUMER_KEY";
			var consumerSecret = "CONSUMER_SECRET";
			var callbackUri = new Uri("http://localhost");

			// create the client
			var client = new LinkedINRestClient(consumerKey, consumerSecret);

			// Fase 1: request access token
			RequestToken requestToken;
			var redirectUri = client.RequestAuthorizationToken( callbackUri, out requestToken );
			Assert.That( requestToken, Is.Not.Null );
			Assert.That( requestToken.Token, Is.Not.Empty );
			Assert.That( requestToken.Secret, Is.Not.Empty );
			Assert.That( redirectUri, Is.Not.Null );

			// start the browser and redirect it to, wait for the user to 
			Process.Start(redirectUri.ToString());
			var requestUrl = "TODO: put browser URL here";
			if (!Debugger.IsAttached)
				Debugger.Launch();
			Debugger.Break();
			var requestUri = new Uri(requestUrl);
			
			// Fase 2: acquire access token
			var accessToken = client.ExchangeCodeForAccessToken( requestUri, requestToken );
			Assert.That( accessToken, Is.Not.Null );
			Assert.That( accessToken.Token, Is.Not.Empty );
			Assert.That( accessToken.Secret, Is.Not.Empty );
		}
	}
}