@Api
Feature: Service status
  The service answers simple status checks.

  @Smoke @2001
  Scenario: The status endpoint answers OK
    When the client calls "/status_codes/200"
    Then the response status is 200

  @2002
  Scenario: A missing page answers not found
    When the client calls "/status_codes/404"
    Then the response status is 404
