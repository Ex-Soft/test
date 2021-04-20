import { Component, OnInit } from '@angular/core';

import { Option, OptionType } from './testradiobutton.type';
import { radiobuttonOptions } from './testradiobutton.constants';

@Component({
  selector: 'app-testradiobutton',
  templateUrl: './testradiobutton.component.html',
  styleUrls: ['./testradiobutton.component.css']
})
export class TestRadiobuttonComponent implements OnInit {
  selected: OptionType = OptionType.OptionType1;
  options: Option[] = radiobuttonOptions;
  filter = (item: Option) => item.type !== OptionType.OptionType4;

  constructor() { }

  ngOnInit(): void {
  }
}
