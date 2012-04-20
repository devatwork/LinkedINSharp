LinkedINSharp
=============

LinkedINSharp is .NET SDK for [LinkedIN](http://www.linkedin.com/). Its goals is to help .NET developers build web applications that integrate with LinkedIN.

## Features

The LinkedIN C# SDK currently provides an implemenation of the following APIs offered by LinkedIN:

* [OAuth authorization](https://developer.linkedin.com/documents/authentication)
* [Profile API](https://developer.linkedin.com/documents/profile-api)
* [Connections API](https://developer.linkedin.com/documents/connections-api)

## Work in progress

This library is still in development, please have a little patience. As soon as we have a stable version we will distribute it via Nuget.

## Sample

The sample code belows shows how to create a client and retrieve the member profile of the authorized user.

```csharp
// construct an access token, usally retrieved from OAuth authorization
var accessToken = new AccessToken( "MY_ACCESS_TOKEN", "MY_ACCESS_SECRET" );

// create the client
var client = new LinkedINRestClient("CONSUMER_KEY", "CONSUMER_SECRET", accessToken);

// retrieve the profile
var profile = client.RetrieveCurrentMemberProfile(ProfileField.NameOnly);
```

Note: The sample below will not work because of a bug in [RestSharp](https://github.com/restsharp/RestSharp), see pull-request [Fix for #231 Support for LinkedIn Field-Selector Notation](https://github.com/restsharp/RestSharp/pull/250) for details. To make this SDK work use my fork [https://github.com/trilobyte/RestSharp](https://github.com/trilobyte/RestSharp).

## Documentation

Nothing here yet, we are working on the documentation at the moment. Please visit our [Github Wiki](https://github.com/trilobyte/LinkedINSharp/wiki) for the most up-to-date documentation.

## Help and Support

Create an issue on our [Github project page](https://github.com/trilobyte/LinkedINSharp/issues) if you encounter a problem with the SDK.

## Help out

There are many ways you can contribute to this project. Like most open-source software projects, contributing code is just one of many outlets where you can help improve. Some of the things that you could help out with in this project are:

* Documentation (both code and features)
* Bug reports
* Bug fixes
* Feature requests
* Feature implementations
* Test coverage
* Code quality
* Sample applications

## Copyright

Copyright © 2012 Bert Willems and contributors

## License

This project is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to license.txt for more information.