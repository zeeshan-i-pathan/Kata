Feature: Time taken for gossip to circulate
    As a Bus Driver
    I want to know after driving around for how long will i know all the latest gossip

Scenario: Three Drivers with Overlapping routes
    Given 3 Bus Drivers
    When Driver 1's routes as [3, 1, 2, 3]
    And Driver 2's routes as [3, 2, 3, 1]
    And Driver 3's routes as [4, 2, 3, 4, 5]
    Then All the Gossip should go around after 5 stops

Scenario: Two Drivers never Manage to Gossip
    Given 2 Bus Drivers
    When Driver 1's routes as [2, 1, 2]
    And Driver 2's routes as [5, 2, 8]
    Then The go around 481 stops with no gossip
