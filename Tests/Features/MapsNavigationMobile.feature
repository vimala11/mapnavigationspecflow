Feature: Mobile Maps Navigation

    @mobile
    Scenario: Navigate from London Bridge to Solirius Office on Mobile
        Given I have opened Google Maps on my Android device
        When I click on directions button on map
        When I enter "London Bridge" as the mobile starting point
        And I enter "65-68 Leadenhall Street, EC3A 2AD" as the mobile destination
        Then I should see available modes of travel to the Solirius Office


    @mobileiOS
    Scenario: Navigate directions from iOS Maps
        Given I have opened Google Maps on my Android device
        When I enter "65-68 Leadenhall Street, EC3A 2AD" as the mobile destination
        And I click on directions button on map
        When I enter "London Bridge station" as the mobile starting point
        And I click the first option displayed
        Then I should see available modes of travel to the Solirius Office


