import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.css']
})
export class Page1Component implements OnInit {
  page2route: string[] = [];
  timeoutId!: number;

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  onClick(pageNumber: number): boolean {
    if (!this.page2route.length) {
      this.timeoutId = window.setTimeout(() => {
        this.page2route.push("/");
        this.page2route.push("page" + pageNumber);
        clearTimeout(this.timeoutId);
        console.log(this.page2route);
        this.router.navigate(this.page2route);
      }, 5000);
      return false;
    }

    return true;
  }
}
