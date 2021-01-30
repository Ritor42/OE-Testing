@feature_tag
Feature: BDDTest elvira

@basic
Scenario: Create a search between two cities
	Given I open elvira mav-start page
	# 1. generate missing step definitions
	# 2. implement the steps where you can use the predefined page objects
	When I create a search from Székesfehérvár to Sopron
	And I submit the search from
	Then the search result title should contain Székesfehérvár and Sopron

@tables
Scenario: Create a search between two cities using tables
	Given I open elvira mav-start page
	When I create a search with the following parameters
	| FromCity | ToCity   | ViaCity        |
	| Szolnok  | Debrecen | Hajdúszoboszló |
	And I submit the search from
	Then the search result title should contain the following city names
	| cities         |
	| Szolnok        |
	| Debrecen       |
	| Hajdúszoboszló |

# 3. Create a new scenario based on the second one to run with Szolnok Debrecen Hajdúszoboszló and Budapest Tata Győr towns, too
@tables
Scenario Outline: Create a search between two cities using tables using example table
	Given I open elvira mav-start page
	When I create a search with the following parameters
	| FromCity   | ToCity   | ViaCity   |
	| <FromCity> | <ToCity> | <ViaCity> |
	And I submit the search from
	Then the search result title should contain the following city names
	| cities     |
	| <FromCity> |
	| <ToCity>   |
	| <ViaCity>  |

	Examples:
	| FromCity | ToCity   | ViaCity        |
	| Szolnok  | Debrecen | Hajdúszoboszló |
	| Budapest | Győr     | Tata           |