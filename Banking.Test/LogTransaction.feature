@FromDb
Feature: Should maintain all transactions done by me

Scenario: Initialize transcations
    Given account details in DB
        | Id | Balance | SortCode | AccountNum |
        | 1 | 2000 | 1 | 100 |
        | 2 | 100 | 1 | 100 |
    Then the DB should have 2 records
    Scenario: Do a Few Transactions
        When I withdraw 200
        And I transfer 1000 from my account to account 2
        And deposit 400
        Then my account balance should be 1200
        And I should have 3 transactions