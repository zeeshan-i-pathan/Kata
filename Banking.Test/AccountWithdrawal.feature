Feature: Withdrawal Service to withdraw money from account

Scenario: Able to withdraw successfully
    Given an account with balance of 2000
    When requesting to withdraw 100
    Then the balance should be 1900
    And withdraw response should be "Accepted"

Scenario: Withdrawal Declined
    Given an account with balance of 1000
    When requesting to withdraw 1100
    Then the balance should be 1000
    And withdraw response should be "Declined"