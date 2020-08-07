import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';

@Component({
  selector: 'app-test-input-output',
  templateUrl: './test-input-output.component.html',
  styleUrls: ['./test-input-output.component.css']
})
export class TestInputOutputComponent implements OnInit {
  @Input() allChecked: boolean;
  @Output() allCheckedChangeEvent = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  allCheckedChange(): void {
    this.allCheckedChangeEvent.emit(this.allChecked);
  }
}
