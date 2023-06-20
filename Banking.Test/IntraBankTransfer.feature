Feature: Should be able to do Intrabank transfer

@Intrabank
Scenario: Able to transfer successfully
    Given account details 
        | Id | Balance | SortCode | AccountNum |
        | 1 | 2000 | 1 | 100 |
        | 2 | 1000 | 1 | 101 |
    When I transfer 1000 from account 1 to account 2
    Then account 1 balance should be 1000
    And account 2 balance should be 2000