Feature: Search for a house on Trademe website
A short summary of the feature

@tag1
Scenario: [Search for a house in Region Wellington]
	Given [User is on a Trademe Website]
	When [the user inputs "house" and clicks on search]
	And [the user selects Category as "Trade Me Property"]
	And [sets location Region as "Wellington"]
	Then [number of listing displayed is 284]
	When [the user selects the first listing]
	Then [the user verifies the key details]
