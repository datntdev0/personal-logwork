import { CoreTestingModule } from "@abp/ng.core/testing";
import { ComponentFixture, TestBed, waitForAsync } from "@angular/core/testing";
import { HomeComponent } from "./home.component";
import { AuthService } from '@abp/ng.core';

describe("HomeComponent", () => {
  let fixture: ComponentFixture<HomeComponent>;
  const mockAuthService = new AuthService();
  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [HomeComponent],
        imports: [
          CoreTestingModule.withConfig(),
        ],
        providers: [
          {
            provide: AuthService,
            useValue: mockAuthService
          },
        ],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    fixture.detectChanges();
  });

  it("should be initiated", () => {
    expect(fixture.componentInstance).toBeTruthy();
  });

  describe('when login state is true', () => {
    beforeAll(() => {
      spyOnProperty(mockAuthService, 'isAuthenticated', 'get').and.returnValue(true);
    });

    it("hasLoggedIn should be true", () => {
      expect(fixture.componentInstance.hasLoggedIn).toBeTrue();
    })

    it("button should not be exists", () => {
      const element = fixture.nativeElement
      const button = element.querySelector('[role="button"]');
      expect(button).toBeNull();
    })
  })

  describe('when login state is false', () => {
    beforeAll(() => {
      spyOnProperty(mockAuthService, 'isAuthenticated', 'get').and.returnValue(false);
    });

    it("hasLoggedIn should be false", () => {
      expect(fixture.componentInstance.hasLoggedIn).toBeFalse();
    })

    it("button should be exists", () => {
      const element = fixture.nativeElement;
      const button = element.querySelector('[role="button"]');
      expect(button).toBeDefined();
    })
  })

  describe('when login state is false and button clicked', () => {
    beforeAll(() => {
      spyOn(mockAuthService, 'navigateToLogin');
      spyOnProperty(mockAuthService, 'isAuthenticated', 'get').and.returnValue(false);
    });

    it('navigateToLogin have been called', () => {
      const element = fixture.nativeElement;
      const button = element.querySelector('[role="button"]')
      button.click();
      expect(mockAuthService.navigateToLogin).toHaveBeenCalled();
    })
  })

});
