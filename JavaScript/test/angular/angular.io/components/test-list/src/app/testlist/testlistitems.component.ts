import { Component, OnInit, Input } from '@angular/core';
import { IItem } from '../models/IItem';

@Component({
  selector: 'app-testlistitems',
  templateUrl: './testlistitems.component.html',
  styleUrls: ['./testlistitems.component.css']
})
export class TestlistitemsComponent implements OnInit {
  allChecked = false;
  btnEnabled = false;

  constructor() {
    console.log('.ctor(): this = %o', this);
  }

  @Input() items: IItem[];

  ngOnInit(): void {
    console.log('ngOnInit(): this = %o', this);
  }

  checkBoxAllChange(e: any): void {
    const newVal = typeof e === 'boolean' ? e : e.target.checked;
    this.items.map(item => item.checked = newVal);
    this.setBtnEnabled();
  }

  checkBoxChange(e: any): void {
    this.allChecked = this.items.every(item => item.checked);
    this.setBtnEnabled();
  }

  btnClick(e: any): void {
    const checked = this.items.filter(item => item.checked);
  }

  setBtnEnabled(): void {
    this.btnEnabled = this.items.some(item => item.checked);
  }
}
