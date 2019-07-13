import { Component, OnInit, Input } from '@angular/core';
import { IData } from '../IData';
import { DataService } from '../data.service';

@Component({
  selector: 'app-testcombobox',
  templateUrl: './testcombobox.component.html',
  styleUrls: ['./testcombobox.component.css']
})
export class TestcomboboxComponent implements OnInit {
  data: IData[];

  constructor(private dataService: DataService) { }

  @Input()
  url: string;

  ngOnInit() {
    this.getData();
  }

  getData(): void {
    this.dataService.getData(this.url)
      .subscribe((data: IData[]) => {
        this.data = data;
      });
  }

  onChange(event: any): void {
    if (window.console && console.log) console.log(event.target.value);
  }
}
