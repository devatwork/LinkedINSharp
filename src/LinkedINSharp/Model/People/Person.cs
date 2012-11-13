using System.Collections.ObjectModel;

namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Represents an LinkedIn profile.
	/// </summary>
	public class Person
	{
		#region Constants
		/// <summary>
		/// Selects only the names of the fields.
		/// </summary>
		public const string NameOnlyFields = ":(id,first-name,last-name)";
		/// <summary>
		/// Selects all the fields available on the profile. 
		/// </summary>
		/// <seealso href="https://developer.linkedin.com/documents/profile-fields"/>
		public const string AllFields = ":(id,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location:(name,country:(code)),industry,distance,relation-to-viewer:(distance),last-modified-timestamp,current-share,network,connections,num-connections,num-connections-capped,summary,specialties,proposal-comments,associations,honors,interests,positions,publications,patents,languages,skills,certifications,educations,courses,volunteer,three-current-positions,three-past-positions,num-recommenders,recommendations-received,phone-numbers,im-accounts,twitter-accounts,primary-twitter-account,bound-account-types,mfeed-rss-url,following,job-bookmarks,group-memberships,suggestions,date-of-birth,main-address,member-url-resources,picture-url,public-profile-url,related-profile-views)";
		#endregion
		#region Properties
		/// <summary>
		/// A unique identifier token for this member
		/// </summary>
		/// <remarks>
		/// This field might return a value of private for users other than the currently logged-in user depending on the member's privacy settings.
		/// </remarks>
		public string Id { get; set; }
		/// <summary>
		/// The member's first name
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results depending on the member's privacy settings.
		/// </remarks>
		public string FirstName { get; set; }
		/// <summary>
		/// The member's last name.
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results or return a value of private, depending on the member's privacy settings.
		/// </remarks>
		public string LastName { get; set; }
		/// <summary>
		/// The member's maiden name.
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results or return a value of private, depending on the member's privacy settings.
		/// </remarks>
		public string MaidenName { get; set; }
		/// <summary>
		/// The member's name formatted based on language.
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results or return a value of private, depending on the member's privacy settings.
		/// </remarks>
		public string FormattedName { get; set; }
		/// <summary>
		/// The member's first name spelled phonetically
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results depending on the member's privacy settings.
		/// </remarks>
		public string PhoneticFirstName { get; set; }
		/// <summary>
		/// The member's last name spelled phonetically.
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results depending on the member's privacy settings.
		/// </remarks>
		public string PhoneticLastName { get; set; }
		/// <summary>
		/// The member's name spelled phonetically and formatted based on language.
		/// </summary>
		/// <remarks>
		/// This field might be omitted from some results or return a value of private, depending on the member's privacy settings.
		/// </remarks>
		public string FormattedPhoneticName { get; set; }
		/// <summary>
		/// The member's headline (often "Job Title at Company")
		/// </summary>
		public string Headline { get; set; }
		/// <summary>
		/// Generic <see cref="Location"/> of the LinkedIn member.
		/// </summary>
		public Location Location { get; set; }
		/// <summary>
		/// The industry the LinkedIn member has indicated their profile belongs to.
		/// </summary>
		/// <remarks>
		/// See https://developer.linkedin.com/node/1011 for all the codes.
		/// </remarks>
		public string Industry { get; set; }
		/// <summary>
		/// The degree distance of the fetched profile from the member who fetched the profile.
		/// </summary>
		public int Distance { get; set; }
		/// <summary>
		/// TODO: The degree distance of the fetched profile from the member who fetched the profile.
		/// </summary>
		public int RelationToViewer { get; set; }
		/// <summary>
		/// The timestamp, in milliseconds, when the member's profile was last edited.
		/// </summary>
		public long LastModifiedTimestamp { get; set; }
		/// <summary>
		/// The member's current share, if set.
		/// </summary>
		/// <remarks>
		/// Overloaded to also return "current-status" (if there is no URL shared). (Status and share are the same.)
		/// </remarks>
		public string CurrentShare { get; set; }
		/// <summary>
		/// TODO: The member's network statistics and updates.
		/// </summary>
		public string Network { get; set; }
		/// <summary>
		/// An empty collection, indicating the # of connections the member has with a total attribute.
		/// </summary>
		/// <summary>
		/// LinkedIn will not report whether a user has more than 500 connections.
		/// </summary>
		public Connections Connections { get; set; }
		/// <summary>
		/// The # of connections the member has.
		/// </summary>
		/// <remarks>
		/// Available in some places, such as /people/~/connections, when connections is not. More efficient than checking the total attribute of connections even when connections is available.
		/// </remarks>
		public int NumberOfConnections { get; set; }
		/// <summary>
		/// True if the value of num-connections has been capped at 500. false otherwise.
		/// </summary>
		/// <remarks>
		/// Allows you to distinguish whether num-connections = 500 because the member has exactly 500 connections or actually 500+ because we're hiding the true value.
		/// </remarks>
		public bool NumberOfConnectionsCapped { get; set; }
		/// <summary>
		/// A long-form text area where the member describes their professional profile.
		/// </summary>
		public string Summary { get; set; }
		/// <summary>
		/// A short-form text area where the member enumerates their specialties
		/// </summary>
		/// <remarks>
		/// Not available via connections.
		/// </remarks>
		public string Specialties { get; set; }
		/// <summary>
		/// A short-form text area describing how the member approaches proposals.
		/// </summary>
		public string ProposalComments { get; set; }
		/// <summary>
		/// A short-form text area enumerating the Associations a member has.
		/// </summary>
		public string Associations { get; set; }
		/// <summary>
		/// A short-form text area describing what Honors the member may have.
		/// </summary>
		public string Honors { get; set; }
		/// <summary>
		/// A short-form text area describing the member's interests.
		/// </summary>
		public string Interests { get; set; }
		/// <summary>
		/// A collection of <see cref="Position"/>s a member has had, the total indicated by a total attribute.
		/// </summary>
		public Collection< Position > Positions { get; set; }
		/// <summary>
		/// A collection of <see cref="Publication"/>s authored by this member
		/// </summary>
		public Collection< Publication > Publications { get; set; }
		/// <summary>
		/// A collection of <see cref="Patent"/>s applications held by this member.
		/// </summary>
		public Collection< Patent > Patents { get; set; }
		/// <summary>
		/// A collection of <see cref="Language"/>s and the level of the member's proficiency for each.
		/// </summary>
		public Collection< Language > Languages { get; set; }
		/// <summary>
		/// A collection of <see cref="SkillItem"/>s and the level of the member's proficiency for each.
		/// </summary>
		public Collection< SkillItem > Skills { get; set; }
		/// <summary>
		/// A collection of <see cref="Certification"/>s earned by this member.
		/// </summary>
		public Collection< Certification > Certifications { get; set; }
		/// <summary>
		/// A collection of education institutions a member has attended, the total indicated by a total attribute.
		/// </summary>
		public Collection< Education > Educations { get; set; }
		/// <summary>
		/// A collection of <see cref="Course"/>s a member has taken, the total indicated by a total attribute.
		/// </summary>
		public Collection< Course > Courses { get; set; }
		/// <summary>
		/// A collection of volunteering experiences a member has participated in, including organizations and causes, the totals indicated by a total attribute
		/// </summary>
		public Collection< Volunteer > Volunteers { get; set; }
		/// <summary>
		/// A collection of positions a member currently holds, limited to three and indicated by a total attribute.
		/// 
		/// You can use the &lt;positions&gt; collection to get the full set or use this collection to limit the return to just the first three positions.
		/// </summary>
		public Collection< Position > ThreeCurrentPositions { get; set; }
		/// <summary>
		/// A collection of positions a member formerly held, limited to the three most recent and indicated by a total attribute.
		/// 
		/// You can use the &lt;positions&gt; collection to get the full set or use  this collection to limit the return to just the first three positions.
		/// </summary>
		public Collection< Position > ThreePastPositions { get; set; }
		/// <summary>
		/// The number of recommendations the member has.
		/// </summary>
		public int NumRecommenders { get; set; }
		/// <summary>
		/// A collection of <see cref="Recommendation"/>. a member has received.
		/// </summary>
		public Collection< Recommendation > RecommendationsReceived { get; set; }
		/// <summary>
		/// a collection of phone numbers.
		/// </summary>
		public Collection< TelephoneNumber > PhoneNumbers { get; set; }
		/// <summary>
		/// a collection of instant messenger accounts.
		/// </summary>
		public Collection< IMAccount > IMAccounts { get; set; }
		/// <summary>
		/// a collection of twitter accounts.
		/// </summary>
		public Collection< TwitterAccount > TwitterAccounts { get; set; }
		/// <summary>
		/// the primary twitter account for the member.
		/// </summary>
		public TwitterAccount PrimaryTwitterAccount { get; set; }
		/// <summary>
		/// a collection of accounts bound by the member.
		/// </summary>
		public Collection< BoundAccountType > BoundAccountTypes { get; set; }
		/// <summary>
		/// a URL for the member's multiple feeds.
		/// </summary>
		public string MfeedRssUrl { get; set; }
		/// <summary>
		/// a collection of people, company, and industries that the member is following.
		/// </summary>
		public Collection< Person > Following { get; set; }
		/// <summary>
		/// a collection of jobs that the member is following.
		/// </summary>
		public Collection< JobBookmark > JobBookmarks { get; set; }
		/// <summary>
		/// a collection of groups that the member is following.
		/// </summary>
		public Collection< GroupMembership > GroupMemberships { get; set; }
		/// <summary>
		/// a collection of people, company, and industries suggested for the member to follow.
		/// </summary>
		public Collection< Suggestion > Suggestions { get; set; }
		/// <summary>
		/// member's birth date.
		/// </summary>
		/// <remarks>
		/// May return only month and day, but not year, or all three, depending on information provided.
		/// </remarks>
		public Date DateOfBirth { get; set; }
		/// <summary>
		/// address.
		/// </summary>
		/// <remarks>
		/// Could be home, work, etc. We do not identify which one.
		/// </remarks>
		public string MainAddress { get; set; }
		/// <summary>
		/// A collection of URLs the member has chosen to share on their LinkedIn profile.
		/// </summary>
		public Collection< MemberUrlResource > MemberUrlResources { get; set; }
		/// <summary>
		/// A URL to the profile picture, if the member has associated one with their profile and it is visible to the requestor.
		/// </summary>
		public string PictureUrl { get; set; }
		/// <summary>
		/// A URL to the member's public profile, if enabled.
		/// </summary>
		/// <remarks>
		/// This field is only available when requested using a field selector in a profile or connections call.
		/// </remarks>
		public string PublicProfileUrl { get; set; }
		/// <summary>
		/// A collection of related profiles that were viewed before or after the member's profile.
		/// </summary>
		public Collection< Person > RelatedProfileViews { get; set; }
		#endregion
	}
}