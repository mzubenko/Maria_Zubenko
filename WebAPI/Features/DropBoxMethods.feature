Feature: DropBox Methods

@upload
Scenario: 1 - Upload file to Dropbox
	When user uploads the file
	Then the file is in the Dropbox


@getmetadata
Scenario: 2 - Get file metadata from Dropbox
	When user tries to get the file metadata
	Then user gets metadata


@delete
Scenario: 3 - Delete file from Dropbox
	When user tries to delete file from dropbox
	Then the file is not in the Dropbox
