import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignalRService } from '../../services/signalr-service';
import { SignalrComponent } from './signalr.component';

const signalRService = {
  start: () => {},
  on: () => {},
};

describe('SignalrComponent', () => {
  let component: SignalrComponent;
  let fixture: ComponentFixture<SignalrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignalrComponent ],
      providers: [
        { provide: SignalRService, useValue: signalRService }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignalrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
