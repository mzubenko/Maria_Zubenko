Feature: JobFeatures

@addjob
Scenario: Add new job
	Given user is on the website
	When user logs into the site
	And user goes to the Job page
	And user adds new job
	Then the new job is added
	When user deletes the job
	Then the job is deleted
