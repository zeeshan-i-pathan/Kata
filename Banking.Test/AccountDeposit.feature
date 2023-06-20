Feature: Deposit Service to deposit money to account

Scenario: Able to deposit successfully
    Given an account with balance of 2000
    When requesting to deposit 100
    Then the balance should be 2100
    And deposit response should be "Accepted"