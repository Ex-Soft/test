import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-custom-base',
  templateUrl: './custom-base.component.html',
  styleUrls: ['./custom-base.component.css']
})
export class CustomBaseComponent implements OnInit {
  @Input() pBool: boolean;

  constructor() { }
  ngOnInit(): void { }
}
