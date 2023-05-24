/// <reference types="cypress" />

const { configurations } = require("../../support/e2e");

describe('homepage redirects login page', () => {
  beforeEach(() => {
    cy.clearCookies();
    cy.visit(Cypress.config("baseUrl"));
  });

  it('topbar login button should navigate to login page', () => {
    cy.get("app-home a[role='button']").click();
    cy.on("url:changed", (newUrl) => {
      expect(newUrl).to.contain("Account/Login");
    });
  });

  it('homepage login button should navigate to login page', () => {
    cy.get("#main-navbar a[role='button']").click();
    cy.origin(configurations.serverBaseUrl, () => {
      cy.get("#LoginInput_UserNameOrEmailAddress").should('not.be.NaN');
      cy.get("#LoginInput_Password").should('not.be.NaN');
      cy.get("button[type='submit']").should('not.be.NaN');
    });
  });
})

describe('single sign on page', () => {
  beforeEach(() => {
    cy.clearCookies();
    cy.visit(Cypress.config("baseUrl"));
    cy.get("#main-navbar a[role='button']").click();
  });

  it('after login succesfully, redirect to angular page', () => {
    cy.origin(configurations.serverBaseUrl, { args: configurations }, () => {
      cy.get("#LoginInput_UserNameOrEmailAddress").type("admin");
      cy.get("#LoginInput_Password").type("1q2w3E*");
      cy.get("button[type='submit']").click();
    });
    cy.on("url:changed", (newUrl) => {
      expect(newUrl).to.contain(configurations.clientBaseUrl);
    });
  });
})

