import { Component, OnInit, Input } from '@angular/core';
import { IItem } from '../models/IItem';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-testlistitems',
  templateUrl: './testlistitems.component.html',
  styleUrls: ['./testlistitems.component.css']
})
export class TestlistitemsComponent implements OnInit {
  allChecked = false;
  btnEnabled = false;

  name = new FormControl('');
  
  constructor() { }

  @Input() items: IItem[];

  ngOnInit(): void {
    console.log(this);
  }

  checkBoxAllChange(e: any): void {
    this.items.map(item => item.checked = e.target.checked);
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
