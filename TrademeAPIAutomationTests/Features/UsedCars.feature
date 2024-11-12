Feature: Used Cars

A short summary of the feature

@tag1
Scenario: [Verify count of Used Car Brandsavailable]
	Given [user sends Httprequest to Trademe UsedCars Url]
	Then  [status code is 200]
	And   [count of Used Car Brands is 86]
