import { TestBed } from '@angular/core/testing';

import { AppComponent } from './app.component';
import { SignalRService } from './services/signalr-service';
import { SignalrComponent } from './components/signalr/signalr.component';

const signalRService = {
  start: () => {},
  on: () => {},
};

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        SignalrComponent
      ],
      providers: [
        { provide: SignalRService, useValue: signalRService }
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'signalr'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('signalr');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('signalr app is running!');
  });
});
