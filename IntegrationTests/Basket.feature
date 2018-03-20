Feature: Basket integration test

Scenario: Butter and milk no discount
	Given the basket has 1 bread
	And 1 butter
	And 1 milk
	When I total the basket
	Then the total should be £2.95

Scenario: Butter and bread discount
	Given the basket has 2 butter
	And 2 bread
	When I total the basket
	Then the total should be £3.10

Scenario: Milk discount
	Given the basket has 4 milk
	When I total the basket
	Then the total should be £3.45

Scenario: Two milk discount
	Given the basket has 2 butter
	And 1 bread
	And 8 milk
	When I total the basket
	Then the total should be £9.00  
