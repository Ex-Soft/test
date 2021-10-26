import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';
import { TestItemWithEnumComponent } from './test-item-with-enum.component';
import { IItemWithEnumDto, ItemsWithEnumQuery, TestEnum } from 'src/app/core/state/item-with-enum';

const itemsWithEnumQuery = jasmine.createSpyObj('ItemsWithEnumQuery', ['selectAll']);
itemsWithEnumQuery.selectAll.and.returnValue(of([
  { id: 1, value: TestEnum.First } as IItemWithEnumDto
] as IItemWithEnumDto[]));

describe('TestItemWithEnumComponent', () => {
  let component: TestItemWithEnumComponent;
  let fixture: ComponentFixture<TestItemWithEnumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestItemWithEnumComponent ],
      imports: [ HttpClientTestingModule ],
      providers: [
        { provide: ItemsWithEnumQuery, useValue: itemsWithEnumQuery }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestItemWithEnumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
