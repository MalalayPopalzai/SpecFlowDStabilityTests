Feature: Calculator

#Background: 
#Given  Open new project in D-GEO Suite D-Stability


@USFE-3
Scenario: Undo-Redo for modification of scenario properties
	When I open new project in D-GEO Suite D-Stability
	Then the selection button has the name 'Scenario 1 - Stage 1'
	When I change the scenario:
		| ScenarioName | ScenarioIndex |
		| Scenario 1   | 1             |
	Then there are the following properties:
		| SelectionName | Notes | PropertyPanelCaption |
		| Scenario 1    |       | Scenario             |
	When I modifythere the following properties:
		| SelectionName   | Notes           |
		| Test scenario 1 | Note scenario 1 |
	Then the selection button has the name 'Test scenario 1 - Stage 1'
	When I change the scenario:
		| ScenarioName    | ScenarioIndex |
		| Test scenario 1 | 1             |
	Then there are the following properties:
		| SelectionName   | Notes           | PropertyPanelCaption |
		| Test scenario 1 | Note scenario 1 | Scenario             |
	When I undo the geometry changes
	And I undo the geometry changes
	Then the selection button has the name 'Scenario 1 - Stage 1'
	When I change the scenario:
		| ScenarioName | ScenarioIndex |
		| Scenario 1   | 1             |
	Then there are the following properties:
		| SelectionName | Notes | PropertyPanelCaption |
		| Scenario 1    |       | Scenario             |
	When I redo the geometry changes
	And I redo the geometry changes
	Then the selection button has the name 'Test scenario 1 - Stage 1'
	When I change the scenario:
		| ScenarioName    | ScenarioIndex |
		| Test scenario 1 | 1             |
   	Then there are the following properties:
		| SelectionName   | Notes           | PropertyPanelCaption |
		| Test scenario 1 | Note scenario 1 | Scenario             |
	Then I save the scenario 'my first test' in the folder 'TestFiles\FunctionalityTests'
	
	





