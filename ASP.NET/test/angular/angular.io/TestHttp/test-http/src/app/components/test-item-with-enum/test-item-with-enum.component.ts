import { Component, OnDestroy, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { tap } from 'rxjs/operators';

import { IItemWithEnumDto, ItemsWithEnumQuery, ItemWithEnumService, TestEnum } from 'src/app/core/state/item-with-enum';

@UntilDestroy()
@Component({
  selector: 'app-test-item-with-enum',
  templateUrl: './test-item-with-enum.component.html',
  styleUrls: ['./test-item-with-enum.component.css']
})
export class TestItemWithEnumComponent implements OnInit, OnDestroy {
  itemsWithEnum: IItemWithEnumDto[];

  constructor(
    private query: ItemsWithEnumQuery,
    private service: ItemWithEnumService
  ) { }

  ngOnInit(): void {
    this.query
      .selectAll()
      .pipe(
        untilDestroyed(this),
        tap(itemsWithEnum => {
          if (Array.isArray(itemsWithEnum) && itemsWithEnum.length) {
            this.itemsWithEnum = itemsWithEnum;
          } else {
            this.service.getItemsWithEnum();
          }
        })
      )
      .subscribe();
  }

  ngOnDestroy(): void {
  }

  onClickCheck(): void {
    if (window.console && console.log) {
      console.log(this.itemsWithEnum);

      if (Array.isArray(this.itemsWithEnum) && this.itemsWithEnum.length) {
        const check = (v) => TestEnum.Zero === v ? '===' : '!==';

        let testEnumValue: TestEnum;
        let testEnumValue2: TestEnum;
        let testEnumValue3: TestEnum;

        testEnumValue = this.itemsWithEnum[0].value;
        testEnumValue2 = TestEnum[this.itemsWithEnum[0].value];
        testEnumValue3 = TestEnum.Zero;

        console.log(testEnumValue, check(testEnumValue), check(TestEnum[testEnumValue]));
        console.log(testEnumValue2, check(testEnumValue2), check(TestEnum[testEnumValue2]));
        console.log(testEnumValue3, check(testEnumValue3), check(TestEnum[testEnumValue3]));
      }
    }
  }
}
