@feature_tag
Feature: BeadandoTest forms

@tables
Scenario Outline: Fill a microsoft forms survey using examples table
	Given I open microsoft forms survey page
	When I fill the survey with the following parameters
	| FirstAnswer   | SecondAnswer   | ThirdAnswer   | FourthAnswer   | FifthAnswer   | SixthAnswer   |
	| <FirstAnswer> | <SecondAnswer> | <ThirdAnswer> | <FourthAnswer> | <FifthAnswer> | <SixthAnswer> |
	And I submit the survey from
	Then the survey result should contain the tick symbol

	Examples:
	| FirstAnswer                                                        | SecondAnswer | ThirdAnswer | FourthAnswer | FifthAnswer                                               | SixthAnswer |
	| Megismerni a tesztelés világát elméleti és gyakorlati oldalról is. | 4            | 3, 4, 4, 5  | 2            | Pontosan olyan, mint ez a Web UI-s része volt a tárgynak. | 8           |
	| Tesztelni!                                                         | 5            | 5, 5, 5, 5  | 1            | Pontosan olyan, mint ez a Web UI-s része volt a tárgynak. | 9           |
