@SignIn
Feature: Sign in
  A registered user signs in to the secure area.

  @Smoke @1001
  Scenario: A registered user signs in
    Given the user is on the sign-in page
    When the user signs in as "tomsmith" with password "SuperSecretPassword!"
    Then the page shows the message "You logged into a secure area!"

  @1002
  Scenario: A wrong password is rejected
    Given the user is on the sign-in page
    When the user signs in as "tomsmith" with password "wrong-password"
    Then the page shows the message "Your password is invalid!"

  # Written for an older version of the page. Left out of the default run.
  @Stale @1003
  Scenario: Sign in shows the old welcome text
    Given the user is on the sign-in page
    When the user signs in as "tomsmith" with password "SuperSecretPassword!"
    Then the page shows the message "Welcome back, Tom!"
